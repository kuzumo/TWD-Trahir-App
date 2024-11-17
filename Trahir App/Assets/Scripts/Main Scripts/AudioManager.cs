using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance; // Singleton instance
    public AudioClip buttonClickSound;
    private AudioSource audioSource;

    void Awake()
    {
        // Check if there is already an instance of AudioManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Make this object persistent across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayButtonClickSound()
    {
        if (audioSource != null && buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound);
        }
        else
        {
            Debug.LogError("AudioSource or buttonClickSound is not assigned!");
        }
    }
}