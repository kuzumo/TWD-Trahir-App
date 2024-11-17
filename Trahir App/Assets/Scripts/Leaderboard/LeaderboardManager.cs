using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class LeaderboardManager : MonoBehaviour
{
    public GameObject leaderboardRowPrefab;  // The prefab for a leaderboard row (assigned in Inspector)
    public Transform leaderboardContainer;   // The container for leaderboard rows (assigned in Inspector)
    
    private List<Team> leaderboard = new List<Team>();  // List of teams for the leaderboard

    // A simple class to represent each team
    [System.Serializable]
    public class Team
    {
        public string teamName;  // Team name
        public int wins;  // Number of wins
        public int losses;  // Number of losses
    }

    void Start()
    {
        // Sample data to start with (you can remove or replace with dynamic data)
        leaderboard.Add(new Team { teamName = "Team A", wins = 5, losses = 3 });

        DisplayLeaderboard();  // Display leaderboard when the game starts
    }

    // Method to display the leaderboard
    void DisplayLeaderboard()
    {
        leaderboard = leaderboard.OrderByDescending(t => t.wins).ThenBy(t => t.losses).ToList();

        // Clear previous rows
        foreach (Transform child in leaderboardContainer)
        {
            Destroy(child.gameObject);  // Delete previous rows
        }

        // Create the leaderboard rows
        for (int i = 0; i < Mathf.Min(5, leaderboard.Count); i++) // Only show top 5
        {
            // Instantiate a new row from the prefab
            GameObject row = Instantiate(leaderboardRowPrefab, leaderboardContainer);

            // Get the LeaderboardRow component to set data
            LeaderboardRow rowScript = row.GetComponent<LeaderboardRow>();
            rowScript.SetRowData(i + 1, leaderboard[i].teamName, leaderboard[i].wins, leaderboard[i].losses);
        }
    }


    // Method to add a result (use this method when a match is over)
    public void AddMatchResult(string winningTeamName, string losingTeamName)
    {
        Team winningTeam = leaderboard.FirstOrDefault(t => t.teamName == winningTeamName);
        Team losingTeam = leaderboard.FirstOrDefault(t => t.teamName == losingTeamName);

        if (winningTeam == null)
        {
            winningTeam = new Team { teamName = winningTeamName, wins = 0, losses = 0 };
            leaderboard.Add(winningTeam);
        }

        if (losingTeam == null)
        {
            losingTeam = new Team { teamName = losingTeamName, wins = 0, losses = 0 };
            leaderboard.Add(losingTeam);
        }

        // Update the win/loss counts
        winningTeam.wins++;
        losingTeam.losses++;

        // Re-display the leaderboard with the updated data
        DisplayLeaderboard();
    }
}
