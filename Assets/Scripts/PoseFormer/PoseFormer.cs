using UnityEngine;
using DG.Tweening;

namespace AngryKoala.PoseFormer
{
    public static class PoseFormer
    {
        public const string PathKey = "PoseFormPath";
        public static string PoseFormPath => PlayerPrefs.GetString(PathKey, "Assets");

        private static PoseForm copiedPoseForm;
        public static PoseForm CopiedPoseForm => copiedPoseForm;

        /// <summary>
        /// Creating poseforms with base transform values may not always be desirable. Use the optional parameter if you want the initial node of your poseform to have the default values.
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="includeBaseTransformValues"></param>
        /// <returns></returns>
        public static PoseForm Create(Transform transform, bool includeBaseTransformValues = true)
        {
            PoseForm poseForm = ScriptableObject.CreateInstance<PoseForm>();

            poseForm.SetNodes(transform, includeBaseTransformValues);

            return poseForm;
        }

        public static PoseForm CreatePoseForm(this Transform transform, bool includeBaseTransformValues = true)
        {
            PoseForm poseForm = ScriptableObject.CreateInstance<PoseForm>();

            poseForm.SetNodes(transform, includeBaseTransformValues);

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

        /// <summary>
        /// Applying poseforms base transform values may not always be desirable. Use the optional parameter if you don't want to apply base transform values of your poseform to the transform.
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="includeBaseTransformValues"></param>
        /// <returns></returns>
        public static void Apply(Transform transform, PoseForm poseForm, bool includeBaseTransformValues = true)
        {
            if(CheckNodes(transform, poseForm))
            {
                Transform[] transforms = transform.GetComponentsInChildren<Transform>();

                for(int i = 0; i < transforms.Length; i++)
                {
                    DOTween.Kill(transforms[i]);

                    if(i == 0)
                    {
                        transforms[i].localPosition = includeBaseTransformValues ? poseForm.Nodes[i].LocalPosition : transforms[i].localPosition;
                        transforms[i].localRotation = includeBaseTransformValues ? poseForm.Nodes[i].LocalRotation : transforms[i].localRotation;
                        transforms[i].localScale = includeBaseTransformValues ? poseForm.Nodes[i].LocalScale : transforms[i].localScale;
                    }
                    else
                    {
                        transforms[i].localPosition = poseForm.Nodes[i].LocalPosition;
                        transforms[i].localRotation = poseForm.Nodes[i].LocalRotation;
                        transforms[i].localScale = poseForm.Nodes[i].LocalScale;
                    }
                }
            }
        }

        public static void ApplyPoseForm(this Transform transform, PoseForm poseForm, bool includeBaseTransformValues = true)
        {
            if(CheckNodes(transform, poseForm))
            {
                Transform[] transforms = transform.GetComponentsInChildren<Transform>();

                for(int i = 0; i < transforms.Length; i++)
                {
                    DOTween.Kill(transforms[i]);

                    if(i == 0)
                    {
                        transforms[i].localPosition = includeBaseTransformValues ? poseForm.Nodes[i].LocalPosition : transforms[i].localPosition;
                        transforms[i].localRotation = includeBaseTransformValues ? poseForm.Nodes[i].LocalRotation : transforms[i].localRotation;
                        transforms[i].localScale = includeBaseTransformValues ? poseForm.Nodes[i].LocalScale : transforms[i].localScale;
                    }
                    else
                    {
                        transforms[i].localPosition = poseForm.Nodes[i].LocalPosition;
                        transforms[i].localRotation = poseForm.Nodes[i].LocalRotation;
                        transforms[i].localScale = poseForm.Nodes[i].LocalScale;
                    }
                }
            }
        }

        /// <summary>
        /// Blending between poseforms with base transform values may not always be desirable. Use the optional parameter if you don't want to blend base transform values of your poseforms.
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="initialPoseForm"></param>
        /// <param name="finalPoseForm"></param>
        /// <param name="percentage"></param>
        /// <param name="includeBaseTransformValues"></param>
        public static void Blend(Transform transform, PoseForm initialPoseForm, PoseForm finalPoseForm, float percentage, bool includeBaseTransformValues = true)
        {
            if(CheckNodes(transform, initialPoseForm) && CheckNodes(transform, finalPoseForm))
            {
                percentage = Mathf.Clamp01(percentage);

                Transform[] transforms = transform.GetComponentsInChildren<Transform>();

                for(int i = 0; i < transforms.Length; i++)
                {
                    DOTween.Kill(transforms[i]);

                    if(i == 0)
                    {
                        transforms[i].localPosition = includeBaseTransformValues ? Vector3.Lerp(initialPoseForm.Nodes[i].LocalPosition, finalPoseForm.Nodes[i].LocalPosition, percentage) : transforms[i].localPosition;
                        transforms[i].localRotation = includeBaseTransformValues ? Quaternion.Lerp(initialPoseForm.Nodes[i].LocalRotation, finalPoseForm.Nodes[i].LocalRotation, percentage) : transforms[i].localRotation;
                        transforms[i].localScale = includeBaseTransformValues ? Vector3.Lerp(initialPoseForm.Nodes[i].LocalScale, finalPoseForm.Nodes[i].LocalScale, percentage) : transforms[i].localScale;
                    }
                    else
                    {
                        transforms[i].localPosition = Vector3.Lerp(initialPoseForm.Nodes[i].LocalPosition, finalPoseForm.Nodes[i].LocalPosition, percentage);
                        transforms[i].localRotation = Quaternion.Lerp(initialPoseForm.Nodes[i].LocalRotation, finalPoseForm.Nodes[i].LocalRotation, percentage);
                        transforms[i].localScale = Vector3.Lerp(initialPoseForm.Nodes[i].LocalScale, finalPoseForm.Nodes[i].LocalScale, percentage);
                    }
                }
            }
        }

        public static void BlendPoseForms(this Transform transform, PoseForm initialPoseForm, PoseForm finalPoseForm, float percentage, bool includeBaseTransformValues = true)
        {
            if(CheckNodes(transform, initialPoseForm) && CheckNodes(transform, finalPoseForm))
            {
                percentage = Mathf.Clamp01(percentage);

                Transform[] transforms = transform.GetComponentsInChildren<Transform>();

                for(int i = 0; i < transforms.Length; i++)
                {
                    DOTween.Kill(transforms[i]);

                    if(i == 0)
                    {
                        transforms[i].localPosition = includeBaseTransformValues ? Vector3.Lerp(initialPoseForm.Nodes[i].LocalPosition, finalPoseForm.Nodes[i].LocalPosition, percentage) : transforms[i].localPosition;
                        transforms[i].localRotation = includeBaseTransformValues ? Quaternion.Lerp(initialPoseForm.Nodes[i].LocalRotation, finalPoseForm.Nodes[i].LocalRotation, percentage) : transforms[i].localRotation;
                        transforms[i].localScale = includeBaseTransformValues ? Vector3.Lerp(initialPoseForm.Nodes[i].LocalScale, finalPoseForm.Nodes[i].LocalScale, percentage) : transforms[i].localScale;
                    }
                    else
                    {
                        transforms[i].localPosition = Vector3.Lerp(initialPoseForm.Nodes[i].LocalPosition, finalPoseForm.Nodes[i].LocalPosition, percentage);
                        transforms[i].localRotation = Quaternion.Lerp(initialPoseForm.Nodes[i].LocalRotation, finalPoseForm.Nodes[i].LocalRotation, percentage);
                        transforms[i].localScale = Vector3.Lerp(initialPoseForm.Nodes[i].LocalScale, finalPoseForm.Nodes[i].LocalScale, percentage);
                    }
                }
            }
        }

        public static void CopyPoseForm(PoseForm poseForm)
        {
            copiedPoseForm = poseForm;
        }

        public static void PastePoseForm(Transform transform)
        {
            if(copiedPoseForm == null)
                return;

            if(CheckNodes(transform, copiedPoseForm))
            {
                Transform[] transforms = transform.GetComponentsInChildren<Transform>();

                for(int i = 0; i < transforms.Length; i++)
                {
                    if(i != 0)
                    {
                        transforms[i].localPosition = copiedPoseForm.Nodes[i].LocalPosition;
                        transforms[i].localRotation = copiedPoseForm.Nodes[i].LocalRotation;
                        transforms[i].localScale = copiedPoseForm.Nodes[i].LocalScale;
                    }
                }
            }
        }

        #region DOTween

        // This should go without saying, but these methods are not intended to be called repeatedly (as in Update())

        public static void Apply(Transform transform, PoseForm poseForm, float duration, float delay = 0f, Ease ease = Ease.Linear, bool includeBaseTransformValues = true)
        {
            if(CheckNodes(transform, poseForm))
            {
                Transform[] transforms = transform.GetComponentsInChildren<Transform>();

                for(int i = 0; i < transforms.Length; i++)
                {
                    if(i == 0)
                    {
                        AdjustTransform(transforms[i], includeBaseTransformValues ? poseForm.Nodes[i].LocalPosition : transforms[i].localPosition, includeBaseTransformValues ? poseForm.Nodes[i].LocalRotation : transforms[i].localRotation, includeBaseTransformValues ? poseForm.Nodes[i].LocalScale : transforms[i].localScale, duration, i * delay, ease);
                    }
                    else
                    {
                        AdjustTransform(transforms[i], poseForm.Nodes[i].LocalPosition, poseForm.Nodes[i].LocalRotation, poseForm.Nodes[i].LocalScale, duration, i * delay, ease);
                    }
                }
            }
        }

        public static void ApplyPoseForm(this Transform transform, PoseForm poseForm, float duration, float delay = 0f, Ease ease = Ease.Linear, bool includeBaseTransformValues = true)
        {
            if(CheckNodes(transform, poseForm))
            {
                Transform[] transforms = transform.GetComponentsInChildren<Transform>();

                for(int i = 0; i < transforms.Length; i++)
                {
                    if(i == 0)
                    {
                        AdjustTransform(transforms[i], includeBaseTransformValues ? poseForm.Nodes[i].LocalPosition : transforms[i].localPosition, includeBaseTransformValues ? poseForm.Nodes[i].LocalRotation : transforms[i].localRotation, includeBaseTransformValues ? poseForm.Nodes[i].LocalScale : transforms[i].localScale, duration, i * delay, ease);
                    }
                    else
                    {
                        AdjustTransform(transforms[i], poseForm.Nodes[i].LocalPosition, poseForm.Nodes[i].LocalRotation, poseForm.Nodes[i].LocalScale, duration, i * delay, ease);
                    }
                }
            }
        }

        public static void Blend(Transform transform, PoseForm initialPoseForm, PoseForm finalPoseForm, float percentage, float duration, float delay = 0f, Ease ease = Ease.Linear, bool includeBaseTransformValues = true)
        {
            if(CheckNodes(transform, initialPoseForm) && CheckNodes(transform, finalPoseForm))
            {
                percentage = Mathf.Clamp01(percentage);

                Transform[] transforms = transform.GetComponentsInChildren<Transform>();

                for(int i = 0; i < transforms.Length; i++)
                {
                    DOTween.Kill(transforms[i]);

                    if(i == 0)
                    {
                        AdjustTransform(transforms[i], includeBaseTransformValues ? Vector3.Lerp(initialPoseForm.Nodes[i].LocalPosition, finalPoseForm.Nodes[i].LocalPosition, percentage) : transforms[i].localPosition,
                            includeBaseTransformValues ? Quaternion.Lerp(initialPoseForm.Nodes[i].LocalRotation, finalPoseForm.Nodes[i].LocalRotation, percentage) : transforms[i].localRotation,
                            includeBaseTransformValues ? Vector3.Lerp(initialPoseForm.Nodes[i].LocalScale, finalPoseForm.Nodes[i].LocalScale, percentage) : transforms[i].localScale,
                            duration, i * delay, ease);
                    }
                    else
                    {
                        AdjustTransform(transforms[i], Vector3.Lerp(initialPoseForm.Nodes[i].LocalPosition, finalPoseForm.Nodes[i].LocalPosition, percentage),
                            Quaternion.Lerp(initialPoseForm.Nodes[i].LocalRotation, finalPoseForm.Nodes[i].LocalRotation, percentage),
                            Vector3.Lerp(initialPoseForm.Nodes[i].LocalScale, finalPoseForm.Nodes[i].LocalScale, percentage),
                            duration, i * delay, ease);
                    }
                }
            }
        }

        public static void BlendPoseForms(this Transform transform, PoseForm initialPoseForm, PoseForm finalPoseForm, float percentage, float duration, float delay = 0f, Ease ease = Ease.Linear, bool includeBaseTransformValues = true)
        {
            if(CheckNodes(transform, initialPoseForm) && CheckNodes(transform, finalPoseForm))
            {
                percentage = Mathf.Clamp01(percentage);

                Transform[] transforms = transform.GetComponentsInChildren<Transform>();

                for(int i = 0; i < transforms.Length; i++)
                {
                    DOTween.Kill(transforms[i]);

                    if(i == 0)
                    {
                        AdjustTransform(transforms[i], includeBaseTransformValues ? Vector3.Lerp(initialPoseForm.Nodes[i].LocalPosition, finalPoseForm.Nodes[i].LocalPosition, percentage) : transforms[i].localPosition,
                            includeBaseTransformValues ? Quaternion.Lerp(initialPoseForm.Nodes[i].LocalRotation, finalPoseForm.Nodes[i].LocalRotation, percentage) : transforms[i].localRotation,
                            includeBaseTransformValues ? Vector3.Lerp(initialPoseForm.Nodes[i].LocalScale, finalPoseForm.Nodes[i].LocalScale, percentage) : transforms[i].localScale,
                            duration, i * delay, ease);
                    }
                    else
                    {
                        AdjustTransform(transforms[i], Vector3.Lerp(initialPoseForm.Nodes[i].LocalPosition, finalPoseForm.Nodes[i].LocalPosition, percentage),
                            Quaternion.Lerp(initialPoseForm.Nodes[i].LocalRotation, finalPoseForm.Nodes[i].LocalRotation, percentage),
                            Vector3.Lerp(initialPoseForm.Nodes[i].LocalScale, finalPoseForm.Nodes[i].LocalScale, percentage),
                            duration, i * delay, ease);
                    }
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
