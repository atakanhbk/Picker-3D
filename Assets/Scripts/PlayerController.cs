using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 FirstPos;
    private Vector3 LastPos;
    public float swerveSensitivity;
    public float maxSwerveSpeed;
    public float maxXPosition = 3f;
    public float ForwardSpeed;
    Vector3 targetVelocity;
    bool gameStarted = false;

    private void Start()
    {   
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        GameManager.Instance.TapToStartEvent.AddListener(StartGame);

    }

    private void OnDisable()
    {
            GameManager.Instance.TapToStartEvent.RemoveListener(StartGame);
    }

    private void Update()
    {
         SwerveNew();
    }

    void SwerveNew()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FirstPos = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            float swerveAmount = (FirstPos.x - Input.mousePosition.x) * swerveSensitivity;
            FirstPos = Input.mousePosition;

            targetVelocity = (Vector3.right * swerveAmount * maxSwerveSpeed) + (Vector3.forward * ForwardSpeed);
            float targetPositionX = transform.position.x + (targetVelocity.x * Time.deltaTime);

            if (!((targetPositionX < 3) && (targetPositionX > -3)))
            {
                targetVelocity.x = 0;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            targetVelocity.x = 0;
        }

        rb.velocity = targetVelocity;
    }

    void StartGame()
    {
        gameStarted = true;
    }
    public void SetPlayerMovement(bool canMove) => rb.isKinematic = !canMove;

    public void MakePlayerSizeBigger()
    {
        transform.localScale += new Vector3(0.05f, 0, 0.05f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            GameManager.Instance.GameWinEvent.Invoke();
            rb.isKinematic = true;
        }
    }



}