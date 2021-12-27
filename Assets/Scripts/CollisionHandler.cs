using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {

            case "Friendly":
                Debug.Log("This thing is friendly!");
                break;

            case "Finish":
                NextLevel();
                break;

            case "Fuel":
                Debug.Log("You've recharged the fuel!");
                break;

            default:
                ReloadLevel();
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
}
