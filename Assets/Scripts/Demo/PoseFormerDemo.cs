using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AngryKoala.PoseFormer;

public class PoseFormerDemo : MonoBehaviour
{
    [SerializeField] private PoseForm defaultPose;
    [SerializeField] private PoseForm idlePose;
    [SerializeField] [Range(0, 1)] private float percentage;

    private void Update()
    {
        //defaultPose.Transition(transform, idlePose, percentage);
    }

    public void GoToDefaultPose()
    {
        defaultPose.Apply(transform);
    }

    public void GoToIdlePose()
    {
        defaultPose.Transition(transform, idlePose, .5f, 2f);
    }
}
