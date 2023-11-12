using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviourSingleton<UIController>
{

    [SerializeField] GameObject loseScreen;
    [SerializeField] GameObject winScreen;
    [SerializeField] List<Image> stageProcessList = new List<Image>();
    public void TapToStart()
    {
        GameManager.Instance.TapToStartEvent.Invoke();
    }

    public void LoseScreen()
    {
        loseScreen.SetActive(true);
    }

    public void WinScreen()
    {
        winScreen.SetActive(true);
    }

     void PrepareNextLevel()
    {
        for (int i = 0; i < stageProcessList.Count; i++)
        {
            stageProcessList[i].color = Color.white;
        }
    }

    public void NextLevel()
    {
        int newCurrentLevel = SaveManager.Instance.GetCurrentLevel() + 1;
        LevelManager.Instance.LoadLevelWithUnload(newCurrentLevel);
        SaveManager.Instance.SetCurrentLevel(newCurrentLevel);
        PrepareNextLevel();
    }

    public void LightNextStage(int stageProcessCount)
    {
        for (int i = 0; i <= stageProcessCount; i++)
        { 
            stageProcessList[i].color = Color.red;
        }
    }


    private void OnEnable()
    {
        GameManager.Instance.GameLoseEvent.AddListener(LoseScreen);
        GameManager.Instance.GameWinEvent.AddListener(WinScreen);
        GameManager.Instance.OnStageUpdate.AddListener(LightNextStage);
    }

    private void OnDisable()
    {
        GameManager.Instance.GameLoseEvent.RemoveListener(LoseScreen);
        GameManager.Instance.GameWinEvent.RemoveListener(WinScreen);
        GameManager.Instance.OnStageUpdate.RemoveListener(LightNextStage);
    }
}

