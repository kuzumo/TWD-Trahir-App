using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public void QuitApplication()
    {
        #if UNITY_EDITOR
            // If we are in the editor, stop playing the game
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            // If we are running the game, quit the application
            Application.Quit();
        #endif
    }
}