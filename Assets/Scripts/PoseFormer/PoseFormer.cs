using UnityEngine;
using DG.Tweening;

namespace AngryKoala.PoseFormer
{
    public static class PoseFormer
    {
        public const string PathKey = "PoseFormPath";
        public static string PoseFormPath => PlayerPrefs.GetString(PathKey, "Assets");

        public static PoseForm Create(this Transform transform)
        {
            PoseForm poseForm = ScriptableObject.CreateInstance<PoseForm>();

            poseForm.SetNodes(transform);

            return poseForm;
        }

        private static bool CheckNodes(Transform transform, PoseForm poseForm)
        {
            Transform[] transforms = transform.GetComponentsInChildren<Transform>();

            for(int i = 0; i < transforms.Length; i++)
            {
                if(transforms[i].childCount != poseForm.Nodes[i].ChildCount)
                {
                    Debug.LogError($"Pose not compatible with {transform.name} hierarchy");
                    return false;
                }
            }
            return true;
        }

        public static void Apply(Transform transform, PoseForm poseForm)
        {
            if(CheckNodes(transform, poseForm))
            {
                Transform[] transforms = transform.GetComponentsInChildren<Transform>();

                for(int i = 0; i < transforms.Length; i++)
                {
                    DOTween.Kill(transforms[i]);

                    transforms[i].localPosition = poseForm.Nodes[i].LocalPosition;
                    transforms[i].localRotation = poseForm.Nodes[i].LocalRotation;
                    transforms[i].localScale = poseForm.Nodes[i].LocalScale;
                }
            }
        }

        public static void Blend(Transform transform, PoseForm initialPoseForm, PoseForm finalPoseForm, float percentage)
        {
            if(CheckNodes(transform, initialPoseForm) && CheckNodes(transform, finalPoseForm))
            {
                percentage = Mathf.Clamp01(percentage);

                Transform[] transforms = transform.GetComponentsInChildren<Transform>();

                for(int i = 0; i < transforms.Length; i++)
                {
                    DOTween.Kill(transforms[i]);

                    transforms[i].localPosition = Vector3.Lerp(initialPoseForm.Nodes[i].LocalPosition, finalPoseForm.Nodes[i].LocalPosition, percentage);
                    transforms[i].localRotation = Quaternion.Lerp(initialPoseForm.Nodes[i].LocalRotation, finalPoseForm.Nodes[i].LocalRotation, percentage);
                    transforms[i].localScale = Vector3.Lerp(initialPoseForm.Nodes[i].LocalScale, finalPoseForm.Nodes[i].LocalScale, percentage);
                }
            }
        }

        #region DOTween

        // This should go without saying, but these methods are not intended to be called repeatedly (as in Update())

        public static void Apply(Transform transform, PoseForm poseForm, float duration, float delay = 0f, Ease ease = Ease.Linear)
        {
            if(CheckNodes(transform, poseForm))
            {
                Transform[] transforms = transform.GetComponentsInChildren<Transform>();

                for(int i = 0; i < transforms.Length; i++)
                {
                    AdjustTransform(transforms[i], poseForm.Nodes[i].LocalPosition, poseForm.Nodes[i].LocalRotation, poseForm.Nodes[i].LocalScale, duration, i * delay, ease);
                }
            }
        }

        public static void Blend(Transform transform, PoseForm initialPoseForm, PoseForm finalPoseForm, float percentage, float duration, float delay = 0f, Ease ease = Ease.Linear)
        {
            if(CheckNodes(transform, initialPoseForm) && CheckNodes(transform, finalPoseForm))
            {
                percentage = Mathf.Clamp01(percentage);

                Transform[] transforms = transform.GetComponentsInChildren<Transform>();

                for(int i = 0; i < transforms.Length; i++)
                {
                    DOTween.Kill(transforms[i]);

                    AdjustTransform(transforms[i], Vector3.Lerp(initialPoseForm.Nodes[i].LocalPosition, finalPoseForm.Nodes[i].LocalPosition, percentage),
                        Quaternion.Lerp(initialPoseForm.Nodes[i].LocalRotation, finalPoseForm.Nodes[i].LocalRotation, percentage),
                        Vector3.Lerp(initialPoseForm.Nodes[i].LocalScale, finalPoseForm.Nodes[i].LocalScale, percentage),
                        duration, i * delay, ease);
                }
            }
        }

        private static void AdjustTransform(Transform transform, Vector3 localPosition, Quaternion localRotation, Vector3 localScale, float duration, float delay, Ease ease)
        {
            DOTween.Kill(transform);

            transform.DOLocalMove(localPosition, duration).SetDelay(delay).SetEase(ease);
            transform.DOLocalRotateQuaternion(localRotation, duration).SetDelay(delay).SetEase(ease);
            transform.DOScale(localScale, duration).SetDelay(delay).SetEase(ease);
        }

        #endregion
    }
}
