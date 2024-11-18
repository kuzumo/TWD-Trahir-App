using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int playerID; // Add playerID to identify the player

    public bool canTakeCards = true;
    public Color[] toggleColors;

    public SpriteRenderer toggleImage;
    public Transform cardSpawnPosTransform;

    [SerializeField]

    [HideInInspector]
    public int i = 0;

    private int cardsOnFace = 0;
    public int CardsOnFace { get { return cardsOnFace; } set { cardsOnFace = value; } }

    //bool hasCheckedWin = false;

    public void ToggleCanTakeCard()
    {
        i++;
        toggleImage.color = toggleColors[i % 2];

        canTakeCards = !canTakeCards;
    }
}
