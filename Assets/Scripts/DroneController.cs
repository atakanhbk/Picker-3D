using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DroneController : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] float movementSpeed = 0.1f;
    [SerializeField] int spawnedBallNumber = 10;
    [SerializeField] float spawnCooldown = 0.1f;
    [SerializeField] GameObject ball;
    private bool moveRight = true;
    bool canDroneMove = false;
    int currentBallNumber = 0;
    float timer = 0;
    void Update()
    {

        if (canDroneMove)
        {
            transform.Translate(new Vector3(0, 0, movementSpeed));
            if (moveRight)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                if (transform.position.x >= 3.0f)
                    moveRight = false;
            }
            else
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
                if (transform.position.x <= -3.0f)
                    moveRight = true;
            }

            timer += Time.deltaTime;

            if (timer >= spawnCooldown && currentBallNumber < spawnedBallNumber)
            {
                SpawnBallDrone();
                currentBallNumber++;
                timer = 0;
            }
            else if (currentBallNumber == spawnedBallNumber)
            {
                Destroy(gameObject);
            }
        }

    }

    void SpawnBallDrone()
    {
        Scene desiredScene = SceneManager.GetSceneByBuildIndex(SaveManager.Instance.GetCurrentLevel()); // Replace with your desired scene name
        var spawnedBall = Instantiate(ball, transform.position, Quaternion.identity);
        SceneManager.MoveGameObjectToScene(spawnedBall, desiredScene);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canDroneMove = true;
        }
    }
}
