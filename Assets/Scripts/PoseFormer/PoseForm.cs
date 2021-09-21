using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace AngryKoala.PoseFormer
{
    public class PoseForm : ScriptableObject
    {
        [SerializeField] private List<Node> nodes = new List<Node>();
        public List<Node> Nodes => nodes;

        public void SetNodes(Transform transform)
        {
            nodes.Clear();

            foreach(var child in transform.GetComponentsInChildren<Transform>())
            {
                Node node = new Node();
                node.SetNode(child);
                nodes.Add(node);
            }
        }

        private bool CheckNodes(Transform transform, PoseForm poseForm)
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

        public void Transition(Transform transform, PoseForm poseForm, float percentage)
        {
            if(CheckNodes(transform, this) && CheckNodes(transform, poseForm))
            {
                percentage = Mathf.Clamp01(percentage);

                Transform[] transforms = transform.GetComponentsInChildren<Transform>();

                for(int i = 0; i < transforms.Length; i++)
                {
                    DOTween.Kill(transforms[i]);

                    transforms[i].localPosition = Vector3.Lerp(Nodes[i].LocalPosition, poseForm.Nodes[i].LocalPosition, percentage);
                    transforms[i].localRotation = Quaternion.Lerp(Nodes[i].LocalRotation, poseForm.Nodes[i].LocalRotation, percentage);
                    transforms[i].localScale = Vector3.Lerp(Nodes[i].LocalScale, poseForm.Nodes[i].LocalScale, percentage);
                }
            }
        }

        public void Apply(Transform transform)
        {
            if(CheckNodes(transform, this))
            {
                Transform[] transforms = transform.GetComponentsInChildren<Transform>();

                for(int i = 0; i < transforms.Length; i++)
                {
                    DOTween.Kill(transforms[i]);

                    transforms[i].localPosition = Nodes[i].LocalPosition;
                    transforms[i].localRotation = Nodes[i].LocalRotation;
                    transforms[i].localScale = Nodes[i].LocalScale;
                }
            }
        }

        #region DOTween

        public void Apply(Transform transform, float duration, float delay = 0f, Ease ease = Ease.Linear)
        {
            if(CheckNodes(transform, this))
            {
                Transform[] transforms = transform.GetComponentsInChildren<Transform>();

                for(int i = 0; i < transforms.Length; i++)
                {
                    AdjustTransform(transforms[i], Nodes[i].LocalPosition, Nodes[i].LocalRotation, Nodes[i].LocalScale, duration, i * delay, ease);
                }
            }
        }

        public void Transition(Transform transform, PoseForm poseForm, float percentage, float duration, float delay = 0f, Ease ease = Ease.Linear)
        {
            if(CheckNodes(transform, this) && CheckNodes(transform, poseForm))
            {
                percentage = Mathf.Clamp01(percentage);

                Transform[] transforms = transform.GetComponentsInChildren<Transform>();

                for(int i = 0; i < transforms.Length; i++)
                {
                    DOTween.Kill(transforms[i]);

                    AdjustTransform(transforms[i], Vector3.Lerp(Nodes[i].LocalPosition, poseForm.Nodes[i].LocalPosition, percentage),
                        Quaternion.Lerp(Nodes[i].LocalRotation, poseForm.Nodes[i].LocalRotation, percentage),
                        Vector3.Lerp(Nodes[i].LocalScale, poseForm.Nodes[i].LocalScale, percentage),
                        duration, i * delay, ease);
                }
            }
        }

        private void AdjustTransform(Transform transform, Vector3 localPosition, Quaternion localRotation, Vector3 localScale, float duration, float delay, Ease ease)
        {
            DOTween.Kill(transform);

            transform.DOLocalMove(localPosition, duration).SetDelay(delay).SetEase(ease);
            transform.DOLocalRotateQuaternion(localRotation, duration).SetDelay(delay).SetEase(ease);
            transform.DOScale(localScale, duration).SetDelay(delay).SetEase(ease);
        }

        #endregion
    }
}
