using UnityEngine;
using UnityEditor;

namespace AngryKoala.PoseForm
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(PoseFormer))]
    public class PoseFormerEditor : Editor
    {
        [MenuItem("GameObject/PoseForm/Create PoseForm", false, 12)]
        private static void CreatePoseForm()
        {
            foreach(var selected in Selection.gameObjects)
            {
                PoseFormer poseFormer = selected.AddComponent<PoseFormer>();

                poseFormer.CreatePoseForm();
                DestroyImmediate(poseFormer);
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
