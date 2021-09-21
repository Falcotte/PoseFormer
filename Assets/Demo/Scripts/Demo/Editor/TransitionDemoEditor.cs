using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TransitionDemo))]
public class TransitionDemoEditor : Editor
{
    public override void OnInspectorGUI()
    {
        TransitionDemo poseFormerDemo = (TransitionDemo)target;

        DrawDefaultInspector();

        if(GUILayout.Button("Transition PoseForm T -> PoseForm Idle"))
        {
            poseFormerDemo.TransitionFromPoseFormTToPoseFormIdle();
        }
    }
}
