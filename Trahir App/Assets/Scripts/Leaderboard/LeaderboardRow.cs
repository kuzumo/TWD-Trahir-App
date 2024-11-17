using UnityEngine;
using UnityEngine.UI;

public class LeaderboardRow : MonoBehaviour
{
    public Text rankText;    // Reference to the Rank text
    public Text teamNameText;  // Reference to the Team Name text
    public Text winScoreText;  // Reference to the Win Score text
    public Text lossScoreText;  // Reference to the Loss Score text

    // Method to set the data in the row
    public void SetRowData(int rank, string teamName, int winScore, int lossScore)
    {
        rankText.text = rank.ToString();  // Set rank
        teamNameText.text = teamName;  // Set team name
        winScoreText.text = winScore.ToString();  // Set win score
        lossScoreText.text = lossScore.ToString();  // Set loss score
    }
}
