using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankMoveController_0518 : MonoBehaviour
{
    private Vector3 direction;
    private Vector2 inputDirection;
    private float turretDir;

    [SerializeField] private int moveSpeed = 3;
    [SerializeField] private int rotateSpeed = 90;
    [SerializeField] private GameObject turretHead;

    private void Update()
    {
        Move();
        Rotate();
        TurretRotate();
    }

    private void OnMove(InputValue inputValue)
    {
        inputDirection = inputValue.Get<Vector2>();
        direction.x = inputDirection.x;
        direction.z = inputDirection.y;
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * direction.z * moveSpeed * Time.deltaTime);
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up, direction.x * rotateSpeed * Time.deltaTime);
    }

    private void OnTurretRotate(InputValue inputValue)
    {
        turretDir = inputValue.Get<float>();
    }

    private void TurretRotate()
    {
        turretHead.transform.Rotate(Vector3.up, turretDir * rotateSpeed * Time.deltaTime);
    }
}
