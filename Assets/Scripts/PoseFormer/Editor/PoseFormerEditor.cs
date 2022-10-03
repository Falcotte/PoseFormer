using UnityEditor;

namespace AngryKoala.PoseFormer
{
    [CustomEditor(typeof(PoseFormCreator))]
    public class PoseFormerEditor : Editor
    {
        [MenuItem("GameObject/Angry Koala/PoseForm/Create PoseForm", false, 12)]
        public static void CreatePoseForm()
        {
            var selectedObjects = Selection.transforms;

            foreach(var selectedObject in selectedObjects)
            {
                PoseFormCreator.CreatePoseForm(selectedObject.transform);
            }
        }

        [MenuItem("GameObject/Angry Koala/PoseForm/Create PoseForm", true)]
        public static bool CreatePoseFormValidation()
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
