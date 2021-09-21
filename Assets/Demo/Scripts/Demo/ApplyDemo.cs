using UnityEngine;
using AngryKoala.PoseFormer;

public class ApplyDemo : MonoBehaviour
{
    [SerializeField] private PoseForm poseFormT;
    [SerializeField] private PoseForm poseFormIdle;

    public void ApplyPoseFormT()
    {
        PoseFormer.Apply(transform, poseFormT);
    }

    public void ApplyPoseFormIdle()
    {
        PoseFormer.Apply(transform, poseFormIdle);
    }
}
