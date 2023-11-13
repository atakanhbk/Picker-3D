using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GateController : MonoBehaviour
{
    [SerializeField] GameObject rightGate, leftGate;


    public void OpenGates()
    {
        Quaternion rightGateRotation = Quaternion.Euler(0, -90, -90);
        rightGate.transform.DORotateQuaternion(rightGateRotation, 1.0f)
           .SetEase(Ease.Linear);

        Quaternion leftGateRotation = Quaternion.Euler(0, 90, 90);
        leftGate.transform.DORotateQuaternion(leftGateRotation, 1.0f)
           .SetEase(Ease.Linear);

        SoundManager.Instance.SuccessSound();
        EffectManager.Instance.CallEffect(transform.position + (Vector3.up*7),"confetti");
    }
}
