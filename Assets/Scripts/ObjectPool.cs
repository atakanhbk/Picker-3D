using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviourSingleton<ObjectPool>
{
    [SerializeField] ParticleSystem effectPrefab;
    List<PoolableObject<ParticleSystem>> effectList = new List<PoolableObject<ParticleSystem>>();

    private void Start()
    {
        CreateEffectPrefab();
    }

    void CreateEffectPrefab()
    {
        for (int i = 0; i < 40; i++)
        {
           var spawnedObject = Instantiate(effectPrefab,transform);
           effectList.Add(new PoolableObject<ParticleSystem>(spawnedObject));
            spawnedObject.gameObject.SetActive(false);
        }
    }

    public void GetEffectFromObjectPool(Vector3 position)
    {
        var findedEffect = effectList.Find(x => !x.state);

        if (findedEffect is null)
        {
            findedEffect = new PoolableObject<ParticleSystem>(Instantiate(effectPrefab, transform));
            effectList.Add(findedEffect);
        }

        findedEffect.PoolObject.transform.position = position;
        findedEffect.PoolObject.gameObject.SetActive(true);
        findedEffect.state = true;
        findedEffect.PoolObject.Play();
    }

    public void DisableEffect(GameObject effect)
    {
     
        var findedEffect = effectList.Find(x => x.PoolObject.gameObject == effect);
        
        findedEffect.state = false;
        findedEffect.PoolObject.transform.position = Vector3.zero;
        findedEffect.PoolObject.gameObject.SetActive(false);
   
    }
}

public class PoolableObject<T> {
    public T PoolObject;
    public bool state;
    public PoolableObject(T effect)
    {
        this.PoolObject = effect;
    }
}
