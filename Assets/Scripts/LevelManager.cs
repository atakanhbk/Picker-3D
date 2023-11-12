using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviourSingleton<LevelManager>
{
    public void LoadLevelWithUnload(int levelNumber)
    {
        if (levelNumber > 1)
        {
            StartCoroutine(LoadNextLevel(levelNumber));
        }
        else
        {
            SceneManager.LoadScene("Level " + levelNumber);
        }
    }

    public void LoadLevel(int levelNumber)
    {
        SceneManager.LoadScene("MainScene");
        SceneManager.LoadScene("Level " + levelNumber,LoadSceneMode.Additive);
   
    }

   
    public void RestartGameFunction(int loadLevel)
    {
        StartCoroutine(RestartGame(loadLevel));
    }

    IEnumerator LoadNextLevel(int loadLevel)
    {
        AsyncOperation test = SceneManager.UnloadSceneAsync("Level " + (loadLevel - 1));
        test.allowSceneActivation = false;
        while (test.progress != 1)
        {
            yield return new WaitForSeconds(.1f);
        }
        test.allowSceneActivation = true;
        SceneManager.LoadScene("Level " + loadLevel,LoadSceneMode.Additive);
    }

    IEnumerator RestartGame(int loadLevel)
    {
        AsyncOperation test = SceneManager.UnloadSceneAsync("Level " + (loadLevel));
        test.allowSceneActivation = false;
        while (test.progress != 1)
        {
            yield return new WaitForSeconds(.1f);
        }
        test.allowSceneActivation = true;
        SceneManager.LoadScene("Level " + loadLevel, LoadSceneMode.Additive);
    }
}
