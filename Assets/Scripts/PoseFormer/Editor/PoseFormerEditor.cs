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

        [MenuItem("GameObject/Angry Koala/PoseForm/Copy PoseForm", false, 12)]
        public static void CopyPoseForm()
        {
            var selectedObjects = Selection.transforms;

            foreach(var selectedObject in selectedObjects)
            {
                PoseForm poseForm = PoseFormer.Create(selectedObject.transform);
                PoseFormer.CopyPoseForm(poseForm);
            }
        }

        [MenuItem("GameObject/Angry Koala/PoseForm/Copy PoseForm", true)]
        public static bool CopyPoseFormValidation()
        {
            var selectedObjects = Selection.transforms;

            if(selectedObjects.Length == 0 || selectedObjects.Length > 1)
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

        [MenuItem("GameObject/Angry Koala/PoseForm/Paste PoseForm", false, 12)]
        public static void PastePoseForm()
        {
            var selectedObjects = Selection.transforms;

            foreach(var selectedObject in selectedObjects)
            {
                PoseFormer.PastePoseForm(selectedObject);
            }
        }

        [MenuItem("GameObject/Angry Koala/PoseForm/Paste PoseForm", true)]
        public static bool PastePoseFormValidation()
        {
            var selectedObjects = Selection.transforms;

            if(selectedObjects.Length == 0 || selectedObjects.Length > 1 || PoseFormer.CopiedPoseForm == null)
            {
                return false;
            }

            foreach(var selectedObject in selectedObjects)
            {
                if(selectedObject == null)
                {
                    return false;
                }

                Transform[] transforms = selectedObject.GetComponentsInChildren<Transform>();

                for(int i = 0; i < transforms.Length; i++)
                {
                    if(transforms[i].childCount != PoseFormer.CopiedPoseForm.Nodes[i].ChildCount)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
