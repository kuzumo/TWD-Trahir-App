using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager_Cards : MonoBehaviour 
{
	Random_ButThat randomButThat;

	public int cardsPerPlayer = 1;

	public Button button_playersNumberSubmit;
    public Button button_SpawnCards;
    

    //public Text selectUsersText;
    public Text warningText;

    public Transform playersParent;

    public int allAvailableCards_Number;
    public int checkedNumberOfCards = 0;

    public GameObject winnerPanel;
    public GameObject exitPanel;


    void Start()
	{
		randomButThat = FindObjectOfType<Random_ButThat> ();

        button_playersNumberSubmit.onClick.AddListener (OnSubmit);
        button_playersNumberSubmit.transform.parent.gameObject.SetActive (true);


        button_SpawnCards.gameObject.SetActive(false);
        randomButThat.ShuffleCards(); // Shuffle the cards before distributing

        

        button_Player1.onClick.AddListener(() => SetPlayerCount(1));
        button_Player2.onClick.AddListener(() => SetPlayerCount(2));
        button_Player3.onClick.AddListener(() => SetPlayerCount(3));
        button_Player4.onClick.AddListener(() => SetPlayerCount(4));

	}


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FindObjectOfType<ExitGameHandler>().TogglePanel(exitPanel);
        }
    }

    public void ResetGame()
	{
        Time.timeScale = 1;
        SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	void OnSubmit()
	{
		string inputText = button_playersNumberSubmit.transform.parent.GetComponentInChildren<InputField> ().text;

        if (int.Parse(inputText) <= 4 && int.Parse(inputText) >= 1)
        {
            int playerInput = int.Parse(inputText);

            int arraySize = playerInput * cardsPerPlayer;
            randomButThat.CreateCardsArray(arraySize);

            // Shuffle the cards before dealing them
        ShuffleDeck();

            for (int i = 0; i < playerInput; i++)
            {
                playersParent.GetChild(i).gameObject.SetActive(true);
            }


            Destroy(button_playersNumberSubmit.transform.parent.gameObject);

            button_SpawnCards.gameObject.SetActive(true);
            //selectUsersText.gameObject.SetActive(false);
        }
        else
        {
            ShowWarning("Players must be between 1 to 4");
        }
	}

    // Shuffle method to randomize the card order
    void ShuffleDeck()
    {
        System.Random rng = new System.Random();
        int n = randomButThat.cardIds.Length;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            int value = randomButThat.cardIds[k];
            randomButThat.cardIds[k] = randomButThat.cardIds[n];
            randomButThat.cardIds[n] = value;
        }
    }


    void ShowWarning(string warningMessage)
    {
        warningText.gameObject.SetActive(true);
        warningText.text = warningMessage;

        Invoke("DisableWarning", 2);
    }

    void DisableWarning()
    {
        warningText.gameObject.SetActive(false);
    }

    public Button button_Player1;
    public Button button_Player2;
    public Button button_Player3;
    public Button button_Player4;
    public GameObject headerText;


    public void SetPlayerCount(int playerCount)
{
    if (playerCount <= 4 && playerCount >= 1)
    {
        int arraySize = playerCount * cardsPerPlayer;
        randomButThat.CreateCardsArray(arraySize);

        ShuffleDeck();

        for (int i = 0; i < playerCount; i++)
        {
            playersParent.GetChild(i).gameObject.SetActive(true);
        }

        button_SpawnCards.gameObject.SetActive(true);
        HidePlayerButtons();

        // Hide the headerText
        headerText.SetActive(false);
    }
    else
    {
        ShowWarning("Players must be between 1 to 4");
    }
    }

    void HidePlayerButtons()
    {
        button_Player1.gameObject.SetActive(false);
        button_Player2.gameObject.SetActive(false);
        button_Player3.gameObject.SetActive(false);
        button_Player4.gameObject.SetActive(false);
    }




}
