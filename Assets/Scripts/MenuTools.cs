using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR

namespace EditorTools
{
    public class MenuTools
    {
        [MenuItem("Tools/Delete Save")]
        private static void DeleteSave()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
    }
}

#endif