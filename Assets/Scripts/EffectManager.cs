using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviourSingleton<EffectManager>
{
    [SerializeField] ParticleSystem confetti;
    [SerializeField] ParticleSystem ballDestroy;



    public void CallEffect(Vector3 position,string effectName)
    {
        switch (effectName)
        {
            case "confetti":
                Instantiate(confetti, position, Quaternion.identity);
                break;
            case "ballDestroy":
                ObjectPool.Instance.GetEffectFromObjectPool(position);
                break;
        }
    }
}
