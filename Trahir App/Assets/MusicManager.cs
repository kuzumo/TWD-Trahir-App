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
            case "Round 1":
            case "Round 8":
            case "Round 12":
            case "Round 16":
            case "Round 19":
            case "Round 23":
            case "Round 27":
            case "Round 31":
            case "Round 35":
            case "Round 39":
                musicToPlay = normalRoundBG;
                break;
            case "Round 5":
                musicToPlay = ultRoundBG;
                break;
            case "Round 6":
            case "Round 10":
            case "Round 14":
            case "Round 17":
            case "Round 21":
                musicToPlay = specialRoundBG;
                break;
            case "Round 25":
            case "Round 29":
            case "Round 33":
            case "Round 37":
                musicToPlay = specialRoundBG2;
                break;
            case "End Round":
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