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
                    AdjustTransform(transforms[i], Nodes[i], duration, i * delay, ease);
                }
            }
        }

        private void AdjustTransform(Transform transform, Node node, float duration, float delay, Ease ease)
        {
            DOTween.Kill(transform);

            transform.DOLocalMove(node.LocalPosition, duration).SetDelay(delay).SetEase(ease);
            transform.DOLocalRotateQuaternion(node.LocalRotation, duration).SetDelay(delay).SetEase(ease);
            transform.DOScale(node.LocalScale, duration).SetDelay(delay).SetEase(ease);
        }

        #endregion
    }
}
