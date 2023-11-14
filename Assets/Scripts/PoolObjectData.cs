using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObjectData : MonoBehaviour
{
    private void OnDisable()
    {
        ObjectPool.Instance.DisableEffect(gameObject);
    }
}
