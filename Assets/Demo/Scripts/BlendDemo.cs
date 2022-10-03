using UnityEngine;
using UnityEngine.UI;
using AngryKoala.PoseFormer;

public class BlendDemo : MonoBehaviour
{
    [SerializeField] private Transform guardLeft;
    [SerializeField] private Transform guardRight;
    [SerializeField] private Transform guardCenter;

    [SerializeField] private PoseForm poseForm0;
    [SerializeField] private PoseForm poseForm1;

    [Space]
    [SerializeField] private Slider slider;

    private float percentage;
    private float currentPercentage;

    private void Start()
    {
        PoseFormer.Apply(guardLeft, poseForm0, false);
        PoseFormer.Apply(guardRight, poseForm1, false);

        PoseFormer.Apply(guardCenter, poseForm0, false);
    }

    private void Update()
    {
        currentPercentage = Mathf.MoveTowards(currentPercentage, percentage, Time.deltaTime * 5f);
        PoseFormer.Blend(guardCenter, poseForm0, poseForm1, currentPercentage, false);
    }

    public void SetBlendPercentage(float percentage)
    {
        this.percentage = percentage;
    }
}
