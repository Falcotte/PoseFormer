using UnityEngine;
using UnityEngine.UI;
using AngryKoala.PoseFormer;

public class BlendDemo : MonoBehaviour
{
    [SerializeField] private Transform characterLeft;
    [SerializeField] private Transform characterRight;
    [SerializeField] private Transform character;

    [SerializeField] private PoseForm poseForm0;
    [SerializeField] private PoseForm poseForm1;

    [Space]
    [SerializeField] private Slider slider;

    private float percentage;
    private float currentPercentage;

    private void Start()
    {
        PoseFormer.Apply(characterLeft, poseForm0, false);
        PoseFormer.Apply(characterRight, poseForm1, false);

        PoseFormer.Apply(character, poseForm0, false);
    }

    private void Update()
    {
        currentPercentage = Mathf.MoveTowards(currentPercentage, percentage, Time.deltaTime * 5f);
        PoseFormer.Blend(character, poseForm0, poseForm1, currentPercentage, false);
    }

    public void SetBlendPercentage(float percentage)
    {
        this.percentage = percentage;
    }
}
