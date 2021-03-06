using System.Collections.Generic;
using UnityEngine;

namespace AngryKoala.PoseFormer
{
    public class PoseForm : ScriptableObject
    {
        [SerializeField] private List<Node> nodes = new List<Node>();
        public List<Node> Nodes => nodes;

        public void SetNodes(Transform transform)
        {
            nodes.Clear();

            foreach(var child in transform.GetComponentsInChildren<Transform>(true))
            {
                Node node = new Node();
                node.SetNode(child);
                nodes.Add(node);
            }
        }
    }
}
