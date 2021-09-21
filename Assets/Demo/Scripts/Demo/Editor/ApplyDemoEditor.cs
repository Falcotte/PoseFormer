using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ApplyDemo))]
public class ApplyDemoEditor : Editor
{
    public override void OnInspectorGUI()
    {
        ApplyDemo poseFormerDemo = (ApplyDemo)target;

        DrawDefaultInspector();

        if(GUILayout.Button("Go To PoseForm T"))
        {
            poseFormerDemo.ApplyPoseFormT();
        }

        if(GUILayout.Button("Go To PoseForm Idle"))
        {
            poseFormerDemo.ApplyPoseFormIdle();
        }
    }
}
