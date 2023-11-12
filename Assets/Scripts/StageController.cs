using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class StageController : MonoBehaviour
{
    int ballNumber = 0;
    [SerializeField] int neededBall;
    [SerializeField] int stageId;
    [SerializeField] GameObject risePlatform;
    [SerializeField] GateController gates;

    List<GameObject> destroyBalls = new List<GameObject>();
    [SerializeField] ParticleSystem ballDestroyEffect;

    [HideInInspector]
    public PlayerController player;
    public TextMeshPro stageText;

    private void Start()
    {
        stageText.text = " 0 / " + neededBall;
    }

    void UpdateText()
    {
        stageText.text = ballNumber + " / " + neededBall;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            SoundManager.Instance.BallSound();
            ballNumber++;
            UpdateText();
            destroyBalls.Add(other.gameObject);
        }
    }

    public void TriggeredPlayer()
    {
        if (!IsInvoking(nameof(CheckBallNumber)))
        {
            Invoke(nameof(CheckBallNumber), 3.0f);
        }

    }

    void CheckBallNumber()
    {

        if (ballNumber >= neededBall)
        {
            BallIsEnough();
        }
        else
        {
            CallGameManagerGameLose();
        }
    }

    void BallIsEnough()
    {

        Invoke(nameof(DestroyAllBalls), 0.5f);

    }

    void DestroyAllBalls()
    {

        foreach (GameObject ball in destroyBalls)
        {
            Destroy(ball);
            Instantiate(ballDestroyEffect, ball.transform.position, Quaternion.identity);
        }

        destroyBalls.Clear();

        Invoke(nameof(RisePlatform), 0.5f);
    }

    void RisePlatform()
    {
        stageText.gameObject.SetActive(false);
        risePlatform.transform.DOMoveY(1, 0.5f).SetEase(Ease.Linear)
            .OnComplete(() => risePlatform.transform.DOMoveY(0, 0.5f).OnComplete(() => DOTween.Sequence().AppendInterval(0.5f).OnComplete(OpenGates)));

    }

    void OpenGates()
    {

        gates.OpenGates();
        Invoke(nameof(LetPlayerKeepMove), 1f);
    }

    void LetPlayerKeepMove()
    {
        GameManager.Instance.OnStageUpdate.Invoke(stageId);
        player.SetPlayerMovement(true);
    }

    void CallGameManagerGameLose()
    {
        Debug.Log(GameManager.Instance.GameLoseEvent.GetPersistentEventCount());
        GameManager.Instance.GameLoseEvent.Invoke();

    }



}
