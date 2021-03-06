using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace AngryKoala.PoseFormer
{
    public class PoseFormCreator : MonoBehaviour
    {
        public static string PathKey = "PoseFormPath";

        private string PoseFormPath => PlayerPrefs.GetString(PathKey, "Assets");

        // Can also be extended to create PoseForms at runtime
        public void CreatePoseForm()
        {
#if UNITY_EDITOR
            PoseForm poseForm = ScriptableObject.CreateInstance<PoseForm>();

            poseForm.SetNodes(transform);

            string path = "";

            if(System.IO.Directory.Exists(PoseFormPath))
            {
                path = UnityEditor.AssetDatabase.GenerateUniqueAssetPath($"{PoseFormPath}/{transform.name}_PoseForm.asset");
            }
            else
            {
                Debug.LogWarning("Invalid path, saving PoseForm to /Assets folder");
                path = UnityEditor.AssetDatabase.GenerateUniqueAssetPath($"Assets/{transform.name}_PoseForm.asset");
            }

            AssetDatabase.CreateAsset(poseForm, path);
            AssetDatabase.SaveAssets();

            EditorUtility.FocusProjectWindow();

            Selection.activeObject = poseForm;
#endif
        }
    }
}
