using UnityEngine;
using AngryKoala.PoseFormer;

public class ApplyDemo : MonoBehaviour
{
    [SerializeField] private Transform visual;
    [SerializeField] private Transform otherVisual;

    [SerializeField] private PoseForm otherVisualInitialPose;

    private void Start()
    {
        PoseFormer.Apply(otherVisual, otherVisualInitialPose, false);
    }

    public void ApplyPoseForm()
    {
        PoseForm poseForm = PoseFormer.Create(visual, false);

        PoseFormer.Apply(otherVisual, poseForm, .05f, includeBaseTransformValues: false);
    }
}
