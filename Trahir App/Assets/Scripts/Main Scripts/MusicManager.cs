using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioClip startGameBG;
    public AudioClip normalRoundBG;
    public AudioClip ultRoundBG;
    public AudioClip specialRoundBG;
    public AudioClip specialRoundBG2;
    public AudioClip endRoundBG;
    public AudioClip chooseUserModeBG;
    public AudioClip DistributeSpCardsBG;
    public AudioClip RollDiceBG;
    private AudioSource audioSource;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // Try to get the AudioSource component
        audioSource = GetComponent<AudioSource>();

        // Check if the AudioSource is attached before proceeding
        if (audioSource == null)
        {
            Debug.LogError("No AudioSource found on the MusicManager GameObject. Please add one in the Inspector.");
            return; // Exit if there's no AudioSource to avoid further errors
        }

        PlayMusicForScene(SceneManager.GetActiveScene().name);

        SceneManager.activeSceneChanged += OnSceneChanged;
    }

    void OnDestroy()
    {
        SceneManager.activeSceneChanged -= OnSceneChanged;
    }

    void OnSceneChanged(Scene previousScene, Scene newScene)
    {
        PlayMusicForScene(newScene.name);
    }

    void PlayMusicForScene(string sceneName)
    {
        if (audioSource == null)
            return;

        AudioClip musicToPlay = null;

        switch (sceneName)
        {
            case "Start":
                musicToPlay = startGameBG;
                break;

            case "RollDice":
                musicToPlay = RollDiceBG;
                break;

            case "DistributeSpCards":
                musicToPlay = DistributeSpCardsBG;
                break;

            case "ChooseUserMode":
            case "QuitConfirm":
            //case "ConfirmWitch":
            //case "ConfirmTracker":
                musicToPlay = chooseUserModeBG;
                break;

            case "Round 1":
            case "Round 2":
            case "Round 3":
            case "Round 4":

            case "Round 8":
            case "Round 9":

            case "Round 12":
            case "Round 13":

            case "Round 16":

            case "Round 19":
            case "Round 20":

            case "Round 23":
            case "Round 24":
            
            case "Round 27":
            case "Round 28":

            case "Round 31":
            case "Round 32":

            case "Round 35":
            case "Round 36":

            case "Round 39":
            case "Round 40":
                musicToPlay = normalRoundBG;
                break;

            case "Round 5":
                musicToPlay = ultRoundBG;
                break;

            case "Round 6":
            case "Round 7":

            case "Round 10":
            case "Round 11":

            case "Round 14":
            case "Round 15":

            case "Round 17":
            case "Round 18":

            case "Round 21":
            case "Round 22":
                musicToPlay = specialRoundBG;
                break;

            case "Round 25":
            case "Round 26":

            case "Round 29":
            case "Round 30":
            
            case "Round 33":
            case "Round 34":

            case "Round 37":
            case "Round 38":
                musicToPlay = specialRoundBG2;
                break;
                
            case "End Round":
            case "End Game PLAYER":
            case "End Game TRACKER":
            case "Draw Round":
                musicToPlay = endRoundBG;
                break;
        }

        if (musicToPlay != null && musicToPlay != audioSource.clip)
        {
            audioSource.clip = musicToPlay;
            audioSource.Play();
        }
    }
}