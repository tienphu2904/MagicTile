using System.Collections;
using System.Collections.Generic;
using Lean.Touch;
using UnityEngine;
using UnityEngine.Events;

public class LeanTouchTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent<LeanFinger> onFingerTap;

    private void OnEnable()
    {
        LeanTouch.OnFingerTap += LeanTouchOnOnFingerTap;
    }

    private void OnDisable()
    {
        LeanTouch.OnFingerTap -= LeanTouchOnOnFingerTap;
    }

    private void LeanTouchOnOnFingerTap(LeanFinger obj)
    {
        onFingerTap?.Invoke(obj);
    }
}