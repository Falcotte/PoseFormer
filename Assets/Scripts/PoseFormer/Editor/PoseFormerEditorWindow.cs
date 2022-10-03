using UnityEngine;
using UnityEditor;

namespace AngryKoala.PoseFormer
{
    public class PoseFormerEditorWindow : EditorWindow
    {
        [SerializeField] private string path;

        [MenuItem("Angry Koala/PoseFormer")]
        private static void OpenWindow()
        {
            GetWindow<PoseFormerEditorWindow>(title: "PoseFormer").Show();
        }

        private void Awake()
        {
            path = PlayerPrefs.GetString(PoseFormer.PathKey, "Assets");
        }

        private void OnGUI()
        {
            EditorGUILayout.HelpBox("The path where newly created PoseForms will be saved, if the path is invalid," +
                " PoseForms will be saved in the /Assets folder", MessageType.Info);

            path = EditorGUILayout.TextField("PoseForm Path", path);

            if(GUILayout.Button("Set Path"))
            {
                PlayerPrefs.SetString(PoseFormer.PathKey, path);

                Debug.Log($"PoseForm path set to -> {path}");
            }

            GUI.enabled = PoseFormerEditor.SavePoseFormValidation();

            if(GUILayout.Button("Save PoseForm", GUILayout.Height(42)))
            {
                PoseFormerEditor.SavePoseForm();
            }

            GUI.enabled = PoseFormerEditor.SavePoseFormWithoutBaseTransformValuesValidation();

            if(GUILayout.Button("Save PoseForm Without Base Transform Values", GUILayout.Height(42)))
            {
                PoseFormerEditor.SavePoseFormWithoutBaseTransformValues();
            }
        }
    }
}
