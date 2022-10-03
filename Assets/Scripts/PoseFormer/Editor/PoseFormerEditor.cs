using UnityEditor;
using UnityEngine;

namespace AngryKoala.PoseFormer
{
    [CustomEditor(typeof(PoseFormer))]
    public class PoseFormerEditor : Editor
    {
        [MenuItem("GameObject/Angry Koala/PoseForm/Save PoseForm", false, 12)]
        public static void SavePoseForm()
        {
            var selectedObjects = Selection.transforms;

            foreach(var selectedObject in selectedObjects)
            {
                PoseForm poseForm = PoseFormer.Create(selectedObject.transform);

                string path = "";

                if(System.IO.Directory.Exists(PoseFormer.PoseFormPath))
                {
                    path = AssetDatabase.GenerateUniqueAssetPath($"{PoseFormer.PoseFormPath}/{selectedObject.transform.name}_PoseForm.asset");
                }
                else
                {
                    Debug.LogWarning($"{PoseFormer.PoseFormPath} does not exist, saving PoseForm to /Assets folder");
                    path = AssetDatabase.GenerateUniqueAssetPath($"Assets/{selectedObject.transform.name}_PoseForm.asset");
                }

                AssetDatabase.CreateAsset(poseForm, path);
                AssetDatabase.SaveAssets();

                EditorUtility.FocusProjectWindow();

                Selection.activeObject = poseForm;
            }
        }

        [MenuItem("GameObject/Angry Koala/PoseForm/Save PoseForm", true)]
        public static bool SavePoseFormValidation()
        {
            var selectedObjects = Selection.transforms;

            if(selectedObjects.Length == 0)
            {
                return false;
            }

            foreach(var selectedObject in selectedObjects)
            {
                if(selectedObject == null)
                {
                    return false;
                }
            }
            return true;
        }

        [MenuItem("GameObject/Angry Koala/PoseForm/Save PoseForm Without Base Transform Values", false, 12)]
        public static void SavePoseFormWithoutBaseTransformValues()
        {
            var selectedObjects = Selection.transforms;

            foreach(var selectedObject in selectedObjects)
            {
                PoseForm poseForm = PoseFormer.Create(selectedObject.transform, false);

                string path = "";

                if(System.IO.Directory.Exists(PoseFormer.PoseFormPath))
                {
                    path = AssetDatabase.GenerateUniqueAssetPath($"{PoseFormer.PoseFormPath}/{selectedObject.transform.name}_PoseForm.asset");
                }
                else
                {
                    Debug.LogWarning($"{PoseFormer.PoseFormPath} does not exist, saving PoseForm to /Assets folder");
                    path = AssetDatabase.GenerateUniqueAssetPath($"Assets/{selectedObject.transform.name}_PoseForm.asset");
                }

                AssetDatabase.CreateAsset(poseForm, path);
                AssetDatabase.SaveAssets();

                EditorUtility.FocusProjectWindow();

                Selection.activeObject = poseForm;
            }
        }

        [MenuItem("GameObject/Angry Koala/PoseForm/Save PoseForm Without Base Transform Values", true)]
        public static bool SavePoseFormWithoutBaseTransformValuesValidation()
        {
            var selectedObjects = Selection.transforms;

            if(selectedObjects.Length == 0)
            {
                return false;
            }

            foreach(var selectedObject in selectedObjects)
            {
                if(selectedObject == null)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
