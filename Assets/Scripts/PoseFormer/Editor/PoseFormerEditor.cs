using UnityEngine;
using UnityEditor;

namespace AngryKoala.PoseFormer
{
    [CustomEditor(typeof(PoseFormCreator))]
    public class PoseFormerEditor : Editor
    {
        [MenuItem("GameObject/PoseForm/Create PoseForm", false, 12)]
        private static void CreatePoseForm()
        {
            var selected = Selection.activeGameObject;

            PoseFormCreator poseFormCreator = selected.AddComponent<PoseFormCreator>();

            poseFormCreator.CreatePoseForm();
            DestroyImmediate(poseFormCreator);
        }

        [MenuItem("GameObject/PoseForm/Create PoseForm", true)]
        private static bool CreatePoseFormValidation()
        {
            if(Selection.gameObjects.Length > 1)
            {
                return false;
            }

            var selected = Selection.activeGameObject;

            if(selected == null || selected.GetComponent<Transform>() == null)
            {
                return false;
            }
            return true;
        }
    }
}
