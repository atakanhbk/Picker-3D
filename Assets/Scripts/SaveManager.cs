using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviourSingleton<SaveManager>
{
    private const string LEVEL_KEY = "level_key";

    public int GetCurrentLevel()
    {
        return PlayerPrefs.GetInt(LEVEL_KEY,1);
    }

    public void SetCurrentLevel(int levelNumber)
    {
        PlayerPrefs.SetInt(LEVEL_KEY,levelNumber);
    }
}
