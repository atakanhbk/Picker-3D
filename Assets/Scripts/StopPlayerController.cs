using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPlayerController : MonoBehaviour
{
    [SerializeField] StageController stageController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController playerController))
        {
            playerController.CloseWheelsIfOpen();
            playerController.PushTheBalls();
            stageController.player = playerController;
            playerController.SetPlayerMovement(false);
            stageController.TriggeredPlayer();
            Destroy(gameObject);
        }
    }
}
