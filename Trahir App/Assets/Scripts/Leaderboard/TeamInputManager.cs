using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TeamInputManager : MonoBehaviour
{
    public TMP_InputField teamNameWonInput;
    public TMP_InputField teamNameLostInput;
    public Button submitButton;

    public static string teamNameWon = "";
    public static string teamNameLost = "";

    void Start()
    {
        submitButton.onClick.AddListener(OnSubmit);
    }

    void OnSubmit()
    {
        teamNameWon = teamNameWonInput.text;
        teamNameLost = teamNameLostInput.text;
        
        if (string.IsNullOrEmpty(teamNameWon) || string.IsNullOrEmpty(teamNameLost))
        {
            Debug.Log("Both team names must be entered!");
            return;
        }

        // Load the next scene (Scene 46, leaderboard)
        UnityEngine.SceneManagement.SceneManager.LoadScene("Leaderboard");
    }
}
