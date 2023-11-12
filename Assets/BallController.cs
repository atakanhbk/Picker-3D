using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    bool collisionWithPlayer = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player") && !collisionWithPlayer)
        {
            SoundManager.Instance.BallSound();
            collisionWithPlayer = true;
        }
    }
}
