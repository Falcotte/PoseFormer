using UnityEngine;
using AngryKoala.PoseFormer;

public class TransitionDemo : MonoBehaviour
{
    [SerializeField] private PoseForm poseFormT;
    [SerializeField] private PoseForm poseFormIdle;

    [Space]
    [SerializeField] private float percentage;

    public void TransitionFromPoseFormTToPoseFormIdle()
    {
        PoseFormer.Transition(transform, poseFormT, poseFormIdle, percentage);
    }
}
