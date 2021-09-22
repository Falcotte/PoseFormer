using UnityEngine;
using AngryKoala.PoseFormer;

public class BlendDemo : MonoBehaviour
{
    [SerializeField] private PoseForm poseFormT;
    [SerializeField] private PoseForm poseFormIdle;

    [Space]
    [SerializeField] private float percentage;

    public void TransitionFromPoseFormTToPoseFormIdle()
    {
        PoseFormer.Blend(transform, poseFormT, poseFormIdle, percentage);
    }
}
