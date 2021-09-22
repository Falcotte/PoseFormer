using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BlendDemo))]
public class BlendDemoEditor : Editor
{
    public override void OnInspectorGUI()
    {
        BlendDemo poseFormerDemo = (BlendDemo)target;

        DrawDefaultInspector();

        if(GUILayout.Button("Transition PoseForm T -> PoseForm Idle"))
        {
            poseFormerDemo.TransitionFromPoseFormTToPoseFormIdle();
        }
    }
}
