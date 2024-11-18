using UnityEngine;
using UnityEngine.UI;

public class DiceRollerUI : MonoBehaviour
{
    [SerializeField] Button _rollButton;
    [SerializeField] Text _resultsText; // Removed doublesText as requested
    [SerializeField] DiceRoller2D _diceRoller;
    
    // References to the dice prefabs
    [SerializeField] GameObject die1Prefab;
    [SerializeField] GameObject die2Prefab;

    void OnEnable()
    {
        _rollButton.onClick.AddListener(RollDice);
        _diceRoller.OnRoll += HandleRoll;
    }
    
    void OnDisable()
    {
        _rollButton.onClick.RemoveListener(RollDice);
        _diceRoller.OnRoll -= HandleRoll;
    }

    void HandleRoll(int obj)
    {
        _resultsText.text = $"Your team             rolled {obj}!";
        BringDiceToFront(); // Call to ensure dice are at the front
    }

    void RollDice()
    {
        ClearResults();
        _diceRoller.RollDice();
    }

    void ClearResults()
    {
        _resultsText.text = "";
    }

    void BringDiceToFront()
    {
        // Make sure the dice are active and in front
        die1Prefab.transform.SetAsLastSibling();
        die2Prefab.transform.SetAsLastSibling();
    }
}
