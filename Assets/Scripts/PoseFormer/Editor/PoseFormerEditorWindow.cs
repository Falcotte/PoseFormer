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
            path = PlayerPrefs.GetString(PoseFormCreator.PathKey, "Assets");
        }

        private void OnGUI()
        {
            EditorGUILayout.HelpBox("The path where newly created PoseForms will be saved, if the path is invalid," +
                " PoseForms will be saved in the /Assets folder", MessageType.Info);

            path = EditorGUILayout.TextField("PoseForm Path", path);

            if(GUILayout.Button("Set Path"))
            {
                PlayerPrefs.SetString(PoseFormCreator.PathKey, path);

                Debug.Log($"PoseForm path set to -> {path}");
            }

            GUI.enabled = PoseFormerEditor.CreatePoseFormValidation();

            if(GUILayout.Button("Create PoseForm", GUILayout.Height(42)))
            {
                PoseFormerEditor.CreatePoseForm();
            }
        }
    }
}
