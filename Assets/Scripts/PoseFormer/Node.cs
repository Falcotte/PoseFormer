using UnityEngine;

namespace AngryKoala.PoseFormer
{
    [System.Serializable]
    public class Node
    {
        [SerializeField] [HideInInspector] private string name;

        // Node class can be extended to hold all kinds of variables other than these
        [SerializeField] private Vector3 localPosition;
        public Vector3 LocalPosition => localPosition;
        [SerializeField] private Quaternion localRotation;
        public Quaternion LocalRotation => localRotation;
        [SerializeField] private Vector3 localScale;
        public Vector3 LocalScale => localScale;

        // Child count is kept as a way to check if the PoseForm compatible with the transform hierarchy
        [SerializeField] [HideInInspector] private int childCount;
        public int ChildCount => childCount;

        public void SetNode(Transform transform, bool setValues = true)
        {
            name = transform.name;

            localPosition = setValues ? transform.localPosition : Vector3.zero;
            localRotation = setValues ? transform.localRotation : Quaternion.identity;
            localScale = setValues ? transform.localScale : Vector3.one;

            childCount = transform.childCount;
        }
    }
}