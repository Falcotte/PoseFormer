using System.Collections.Generic;
using UnityEngine;

namespace AngryKoala.PoseFormer
{
    public class PoseForm : ScriptableObject
    {
        [SerializeField] private List<Node> nodes = new List<Node>();
        public List<Node> Nodes => nodes;

        public void SetNodes(Transform transform, bool setValues)
        {
            nodes.Clear();

            Transform[] transforms = transform.GetComponentsInChildren<Transform>(true);

            for(int i = 0; i < transforms.Length; i++)
            {
                Node node = new Node();

                if(i == 0)
                {
                    node.SetNode(transforms[i], setValues);
                }
                else
                {
                    node.SetNode(transforms[i]);
                }

                nodes.Add(node);
            }
        }
    }
}
