using UnityEngine;
using UnityEditor;
using NaughtyAttributes;

namespace AngryKoala.PoseForm
{
    public class PoseFormer : MonoBehaviour
    {
        [SerializeField]
        private PoseForm poseForm;

        [SerializeField] private string poseFormPath = "Assets";

        [Button]
        public void CreatePoseForm()
        {
            PoseForm poseForm = ScriptableObject.CreateInstance<PoseForm>();

            poseForm.SetNodes(transform);

            string path = UnityEditor.AssetDatabase.GenerateUniqueAssetPath($"{poseFormPath}/PoseForm.asset");

            AssetDatabase.CreateAsset(poseForm, path);
            AssetDatabase.SaveAssets();

            EditorUtility.FocusProjectWindow();

            Selection.activeObject = poseForm;
        }

        [Button]
        public void ApplyPoseForm()
        {
            Transform[] transforms = GetComponentsInChildren<Transform>();

            for(int i = 0; i < transforms.Length; i++)
            {
                transforms[i].localPosition = poseForm.Nodes[i].LocalPosition;
                transforms[i].localRotation = poseForm.Nodes[i].LocalRotation;
                transforms[i].localScale = poseForm.Nodes[i].LocalScale;
            }
        }
    }
}
