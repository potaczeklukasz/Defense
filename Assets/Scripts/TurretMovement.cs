using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class TurretMovement : MonoBehaviour
{
    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    void Update()
    {
        if (!Touchscreen.current.primaryTouch.press.isPressed) return;

        var touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
        var targetPosition = _mainCamera.ScreenToWorldPoint(touchPosition);
        var difference = targetPosition - transform.position;
        var rotationZ = Math.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, (float) rotationZ);
    }
}