using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AngryKoala.PoseFormer;

public class PoseFormerDemo : MonoBehaviour
{
    [SerializeField] private PoseForm defaultPose;
    [SerializeField] private PoseForm idlePose;

    public void GoToDefaultPose()
    {
        defaultPose.Apply(transform);
    }

    public void GoToIdlePose()
    {
        idlePose.Apply(transform, 1f);
    }
}
