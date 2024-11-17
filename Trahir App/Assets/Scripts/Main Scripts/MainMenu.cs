using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour
{
    // Stack to keep track of scene history
    private static Stack<int> sceneHistory = new Stack<int>();

    // Play the game and push the initial scene to history
    public void RollDice() { //will go to roll dice
        AudioManager.Instance.PlayButtonClickSound();
        PushCurrentSceneToHistory();
        SceneManager.LoadSceneAsync(43);
    }

    public void EndRound() {
        AudioManager.Instance.PlayButtonClickSound();
        PushCurrentSceneToHistory();
        SceneManager.LoadSceneAsync(41);
    }

    public void DrawRound() {
        AudioManager.Instance.PlayButtonClickSound();
        PushCurrentSceneToHistory();
        SceneManager.LoadSceneAsync(42);
    }

    public void MainMenuScene() {
        AudioManager.Instance.PlayButtonClickSound();
        PushCurrentSceneToHistory();
        SceneManager.LoadSceneAsync(0);
    }

    public void InputTeamNames() {
        AudioManager.Instance.PlayButtonClickSound();
        PushCurrentSceneToHistory();
        SceneManager.LoadSceneAsync(45);
    }

    public void Leaderboard() {
        AudioManager.Instance.PlayButtonClickSound();
        PushCurrentSceneToHistory();
        SceneManager.LoadSceneAsync(44);
    }

    public void DistributeSpecialCards() {
        AudioManager.Instance.PlayButtonClickSound();
        PushCurrentSceneToHistory();
        SceneManager.LoadSceneAsync(46);
    }

    public void ChooseUserMode() {
        AudioManager.Instance.PlayButtonClickSound();
        PushCurrentSceneToHistory();
        SceneManager.LoadSceneAsync(47);
    }

    // This method handles going to the next round based on the round index
    public void NextRound(int roundIndex) {
        AudioManager.Instance.PlayButtonClickSound();
        PushCurrentSceneToHistory();
        SceneManager.LoadSceneAsync(roundIndex);
    }

    // Individual methods for each round
    public void NextRound1() { NextRound(1); }
    public void NextRound2() { NextRound(2); }
    public void NextRound3() { NextRound(3); }
    public void NextRound4() { NextRound(4); }
    public void NextRound5() { NextRound(5); }
    public void NextRound6() { NextRound(6); }
    public void NextRound7() { NextRound(7); }
    public void NextRound8() { NextRound(8); }
    public void NextRound9() { NextRound(9); }
    public void NextRound10() { NextRound(10); }
    public void NextRound11() { NextRound(11); }
    public void NextRound12() { NextRound(12); }
    public void NextRound13() { NextRound(13); }
    public void NextRound14() { NextRound(14); }
    public void NextRound15() { NextRound(15); }
    public void NextRound16() { NextRound(16); }
    public void NextRound17() { NextRound(17); }
    public void NextRound18() { NextRound(18); }
    public void NextRound19() { NextRound(19); }
    public void NextRound20() { NextRound(20); }
    public void NextRound21() { NextRound(21); }
    public void NextRound22() { NextRound(22); }
    public void NextRound23() { NextRound(23); }
    public void NextRound24() { NextRound(24); }
    public void NextRound25() { NextRound(25); }
    public void NextRound26() { NextRound(26); }
    public void NextRound27() { NextRound(27); }
    public void NextRound28() { NextRound(28); }
    public void NextRound29() { NextRound(29); }
    public void NextRound30() { NextRound(30); }
    public void NextRound31() { NextRound(31); }
    public void NextRound32() { NextRound(32); }
    public void NextRound33() { NextRound(33); }
    public void NextRound34() { NextRound(34); }
    public void NextRound35() { NextRound(35); }
    public void NextRound36() { NextRound(36); }
    public void NextRound37() { NextRound(37); }
    public void NextRound38() { NextRound(38); }
    public void NextRound39() { NextRound(39); }
    public void NextRound40() { NextRound(40); }

    private void PushCurrentSceneToHistory() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        sceneHistory.Push(currentSceneIndex);
    }

    public void QuitGame() {
        AudioManager.Instance.PlayButtonClickSound();
        Application.Quit();
    }

    public void GoBack() {
        if (sceneHistory.Count > 0) {
            int lastSceneIndex = sceneHistory.Pop(); // Get the last scene index
            SceneManager.LoadSceneAsync(lastSceneIndex); // Load the previous scene
        } else {
            Debug.Log("No previous scenes to go back to!");
        }
    }
}
