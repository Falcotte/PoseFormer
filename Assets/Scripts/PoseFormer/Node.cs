using UnityEngine;

namespace AngryKoala.PoseForm
{
    [System.Serializable]
    public class Node
    {
        [SerializeField] [HideInInspector] private string name;

        [SerializeField] private Vector3 localPosition;
        public Vector3 LocalPosition => localPosition;
        [SerializeField] private Quaternion localRotation;
        public Quaternion LocalRotation => localRotation;
        [SerializeField] private Vector3 localScale;
        public Vector3 LocalScale => localScale;

        public void SetNode(Transform transform)
        {
            name = transform.name;

            localPosition = transform.localPosition;
            localRotation = transform.localRotation;
            localScale = transform.localScale;
        }
    }
}