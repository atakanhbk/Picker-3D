using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GameManager : MonoBehaviourSingleton<GameManager>
{
    public UnityEvent TapToStartEvent;
    public UnityEvent GameLoseEvent;
    public UnityEvent GameWinEvent;
    public UnityEvent <int> OnStageUpdate;

    void Awake()
    {
        TapToStartEvent = new UnityEvent();
        GameLoseEvent = new UnityEvent();
        GameWinEvent = new UnityEvent();
        OnStageUpdate = new  UnityEvent<int>();
    }


    


}

  
