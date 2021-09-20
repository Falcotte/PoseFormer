using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PoseFormerDemo))]
public class PoseFormerDemoEditor : Editor
{
    public override void OnInspectorGUI()
    {
        PoseFormerDemo poseFormerDemo = (PoseFormerDemo)target;

        DrawDefaultInspector();

        if(GUILayout.Button("Go To Default Pose"))
        {
            poseFormerDemo.GoToDefaultPose();
        }

        if(GUILayout.Button("Go To Idle Pose"))
        {
            poseFormerDemo.GoToIdlePose();
        }
    }
}
