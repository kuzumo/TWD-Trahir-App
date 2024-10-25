using UnityEngine;

public class BackButtonManager : MonoBehaviour
{
    public void GoBack() {
        // Call the GoBack method from the MainMenu class
        MainMenu mainMenu = FindObjectOfType<MainMenu>();
        if (mainMenu != null) {
            mainMenu.GoBack();
        } else {
            Debug.LogError("MainMenu not found in the scene!");
        }
    }
}
