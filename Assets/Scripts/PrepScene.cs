using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepScene : MonoBehaviour
{
    void Start()
    {
        LevelManager.Instance.LoadLevel(SaveManager.Instance.GetCurrentLevel()); 
    }
}
