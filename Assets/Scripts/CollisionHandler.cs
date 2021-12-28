using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionHandler : MonoBehaviour
{

    private float delay = 1;
    private AudioSource audioSource;

    public AudioClip crashAudio;
    public AudioClip finishAudio;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }



    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {

            case "Friendly":
                Debug.Log("This thing is friendly!");
                break;

            case "Finish":
                FinishedLevel();
                break;

            default:
                StartCrashSequence();
                break;
        }
    }

    

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }

    void StartCrashSequence()
    {
        // todo add particle effect to crash
        audioSource.PlayOneShot(crashAudio);
        GetComponent<Movement>().enabled = false;
        Invoke ("ReloadLevel", delay);
    }

    void FinishedLevel()
    {
        audioSource.PlayOneShot(finishAudio);
        GetComponent<Movement>().enabled = false;
        Invoke("NextLevel", delay);
    }
}

