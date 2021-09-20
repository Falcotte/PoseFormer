using System.Collections.Generic;
using UnityEngine;

namespace AngryKoala.PoseForm
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

        private bool CheckNodes(Transform transform)
        {
            Transform[] transforms = transform.GetComponentsInChildren<Transform>();

            for(int i = 0; i < transforms.Length; i++)
            {
                if(transforms[i].childCount != Nodes[i].ChildCount)
                {
                    Debug.LogError($"Pose not compatible with {transform.name}");
                    return false;
                }
            }
            return true;
        }

        public void Apply(Transform transform)
        {
            if(CheckNodes(transform))
            {
                Transform[] transforms = transform.GetComponentsInChildren<Transform>();

                for(int i = 0; i < transforms.Length; i++)
                {
                    transforms[i].localPosition = Nodes[i].LocalPosition;
                    transforms[i].localRotation = Nodes[i].LocalRotation;
                    transforms[i].localScale = Nodes[i].LocalScale;
                }
            }
        }
    }
}
