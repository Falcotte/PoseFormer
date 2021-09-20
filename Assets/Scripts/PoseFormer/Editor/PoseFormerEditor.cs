using UnityEngine;
using UnityEditor;

namespace AngryKoala.PoseFormer
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(PoseFormCreator))]
    public class PoseFormerEditor : Editor
    {
        [MenuItem("GameObject/PoseForm/Create PoseForm", false, 12)]
        private static void CreatePoseForm()
        {
            foreach(var selected in Selection.gameObjects)
            {
                PoseFormCreator poseFormCreator = selected.AddComponent<PoseFormCreator>();

                poseFormCreator.CreatePoseForm();
                DestroyImmediate(poseFormCreator);
            }
        }

        [MenuItem("GameObject/PoseForm/Create PoseForm", true)]
        private static bool CreatePoseFormValidation()
        {
            foreach(var selected in Selection.gameObjects)
            {
                if(selected.GetComponent<Transform>() == null)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
