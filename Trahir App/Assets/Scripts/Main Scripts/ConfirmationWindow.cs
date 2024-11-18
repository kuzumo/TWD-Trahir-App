using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;  // This is necessary for UnityEditor functionality

public class MainMenuScript : MonoBehaviour
{
    public Image confirmPanelBackground;

    public void QuitApplication()
    {
        #if UNITY_EDITOR
        // If we are in the Unity Editor, stop play mode
        EditorApplication.isPlaying = false;
        #else
        // If not in the Unity Editor, quit the application
        Application.Quit();
        #endif
    }
}