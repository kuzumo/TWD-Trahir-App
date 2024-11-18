using UnityEngine;
using UnityEngine.UI;

public enum CardType
{
    Special
}

public class Card : MonoBehaviour
{
    GameManager_Cards gameManager;

    public int cardID;
    public int cardNumber;
    public CardType cardType;
    public Sprite cardSprite;

    public Sprite defaultSprite;

    public float flipBackTime = 0.5f;
    public bool hasBeenChacked = false;

    private bool isFaceUp = false; // Tracks if the card is face-up

    // private Vector3 originalScale = new Vector3(0.04545455f, -0.04545455f, 0.3636363f); // Store the original scale 
    // private Vector3 largeScale = new Vector3(0.1818182f * 1.75f, 0.1818182f * 1.75f, 0.3636363f * 1.75f); // Enlarged size (3x)

    private Vector3 originalScale = new Vector3(0.1f, 0.1f, 0.3636363f); // Store the original scale

    //private Vector3 originalScale = new Vector3(0.4545455f, -0.4545455f, 0.3636363f); // Store the original scale
    private Vector3 largeScale = new Vector3(0.1818182f * 2.75f, 0.1818182f * 2.75f, 0.3636363f * 2.75f); // Enlarged size (7x)


    private float clickTime = 0; // Tracks the last click time
    private float clickDelay = 0.3f; // Time window for detecting double click

    private Vector3 player1OriginalPosition = new Vector3(-0.001637565f, 0.0003074111f, 0.1366218f);
    private Vector3 player2OriginalPosition = new Vector3(0.001637565f, 0.0003074108f, 0.1366218f);
    private Vector3 player3OriginalPosition = new Vector3(-0.001637565f, -0.00626562f, 0.1366218f);
    private Vector3 player4OriginalPosition = new Vector3(0.001637565f, -0.00626562f, 0.1366218f);
    
    private bool isLarge = false; // Tracks if the card is enlarged
    private Vector3 originalPosition; // To store the original position when card is created




    void Start()
    {
        originalPosition = transform.localPosition; // Store the original local position (relative to the parent)

        Debug.Log("Original Local Position Set: " + originalPosition); // Debugging position


        gameManager = FindObjectOfType<GameManager_Cards>();
        GetComponent<SpriteRenderer>().sprite = defaultSprite; // Show default sprite before flip

        // Store the original position of the card based on the player it's associated with
        if (gameObject.transform.parent != null)
        {
            PlayerController playerController = gameObject.transform.parent.GetComponent<PlayerController>();
            if (playerController != null)
            {
                // Assign the original position based on the player
                if (playerController.playerID == 1)
                {
                    originalPosition = player1OriginalPosition;
                }
                else if (playerController.playerID == 2)
                {
                    originalPosition = player2OriginalPosition;
                }
                else if (playerController.playerID == 3)
                {
                    originalPosition = player3OriginalPosition;
                }
                else if (playerController.playerID == 4)
                {
                    originalPosition = player4OriginalPosition;
                }

                Debug.Log("Player's Original Position: " + originalPosition); // Debug to check if the player position is set correctly
                transform.position = originalPosition; // Set initial position
            }
        }
    }


    private void ResetPosition()
    {
        transform.position = originalPosition; // Return to the original position
    }

    public void InitCard(int id)
    {
        if (AllCards_Detail.instance.cards != null)
        {
            cardID = AllCards_Detail.instance.cards[id].cardId;
            cardNumber = AllCards_Detail.instance.cards[id].cardNumber;
            cardType = AllCards_Detail.instance.cards[id].cardType;

            cardSprite = AllCards_Detail.instance.cards[id].cardSprite;
        }
        else
        {
            print("Something bad happened! Please Reset the Game");
        }
    }

    private void OnMouseDown()
    {
        // Handle single or double click
        if (Time.time - clickTime < clickDelay)
        {
            // Double-click logic
            HandleDoubleClick();
        }
        else
        {
            // Single-click logic
            HandleSingleClick();
        }

        clickTime = Time.time; // Update the last click time
    }


    private void HandleSingleClick()
    {
        Debug.Log("SingleClick");
        if (isLarge) return; // Ignore single click when enlarged

        if (isFaceUp)
        {
            FlipCardBack(); // Flip back if face-up
            isFaceUp = false;
        }
        else
        {
            FlipCardFace(); // Flip face-up
            isFaceUp = true;
        }
    }


    private void HandleDoubleClick()
    {
        Debug.Log("DoubleClick");
        if (isLarge)
        {
            // If already large, return to original size and position
            ResizeCard(originalScale); // Resize back to original size (Vector3)
            RotateCard(180f, 180f); // Rotate by 180 degrees on Y and Z axis
            //RotateCard(0, 0);
            SetCardSortingOrder(0); // Reset sorting order
            isLarge = false;
            MoveCardToOriginalPosition();
        }
        else
        {
            // Enlarge the card and rotate it
            ResizeCard(largeScale); // Resize to large (Vector3)
            RotateCard(180f, 180f); // Rotate by 180 degrees on Y and Z axis
            SetCardSortingOrder(10); 
            isLarge = true;
            MoveCardToCenter();
        }
    }

    private void SetCardSortingOrder(int order)
    {
        // Get the SpriteRenderer component of the card and set the sorting order
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.sortingOrder = order;
        }
    }


    private void MoveCardToCenter()
    {
        // Set the card position to the center of the screen (canvas)
        Vector3 centerPosition = new Vector3(0f, 1.6f, transform.position.z); // Assuming the card is 2D, we set x and y to 0
        transform.position = centerPosition;
    }

    public void FlipCardFace()
    {
        GetComponent<SpriteRenderer>().sprite = cardSprite; // Change sprite to face-up
        //isFaceUp = false;
    }

    public void FlipCardBack()
    {
        GetComponent<SpriteRenderer>().sprite = defaultSprite; // Change sprite to face-down
        //isFaceUp = true;
    }


    private void ResizeCard(Vector3 newScale)
    {
        transform.localScale = newScale; // Apply the new scale (either large or original)
    }


    private void RotateCard(float yRotation, float zRotation)  // Rotates by specified angles
    {
        transform.rotation = Quaternion.Euler(0, yRotation, zRotation); // Apply rotation to Y and Z axes
    }

    private void MoveCardToOriginalPosition()
    {
        // Move the card back to its original local position
        transform.localPosition = originalPosition;  // Set the local position back to the saved original position
    }
}