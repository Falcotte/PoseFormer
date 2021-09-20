using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace AngryKoala.PoseForm
{
    [CustomEditor(typeof(PoseFormer))]
    public class PoseFormerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            PoseFormer poseFormer = (PoseFormer)target;

            if(GUILayout.Button("Get PoseForm"))
            {
                poseFormer.CreatePoseForm();
            }
        }
    }
}
