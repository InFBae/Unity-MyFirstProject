using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

public class TankController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 direction;
    private Vector2 inputDirection;

    [SerializeField]
    private int moveSpeed = 2;
    [SerializeField]
    private int rotateSpeed = 90;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
        Rotate();
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
}
