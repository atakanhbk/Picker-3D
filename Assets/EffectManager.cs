using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviourSingleton<EffectManager>
{
    [SerializeField] ParticleSystem confetti;
    [SerializeField] ParticleSystem ballDestroy;



    public void CallEffect(Vector3 transform,string effectName)
    {
        switch (effectName)
        {
            case "confetti":
                Instantiate(confetti, transform, Quaternion.identity);
                break;
            case "ballDestroy":
                Instantiate(ballDestroy, transform, Quaternion.identity);
                break;
        }
    }
}
