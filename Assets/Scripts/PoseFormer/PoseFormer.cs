using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace AngryKoala.PoseForm
{
    public class PoseFormer : MonoBehaviour
    {
        [SerializeField] private string poseFormPath = "Assets";

        public void CreatePoseForm()
        {
            PoseForm poseForm = ScriptableObject.CreateInstance<PoseForm>();

            string path = UnityEditor.AssetDatabase.GenerateUniqueAssetPath($"{poseFormPath}/PoseForm.asset");

            AssetDatabase.CreateAsset(poseForm, path);
            AssetDatabase.SaveAssets();

            EditorUtility.FocusProjectWindow();

            Selection.activeObject = poseForm;
        }
    }
}
