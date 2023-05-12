using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallController : MonoBehaviour
{
    private Vector2 inputDirection;
    private Vector3 direction;
    private Rigidbody rb;

    [SerializeField]
    private int moveSpeed = 2;
    [SerializeField]
    private int jumpPower = 5;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }




    private void OnMove(InputValue inputValue)
    {
        inputDirection = inputValue.Get<Vector2>();
        direction.x = inputDirection.x;
        direction.z = inputDirection.y;
    }
    private void OnJump()
    {
        rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }



    private void Move()
    {
        rb.AddForce(direction * moveSpeed);
    }
}
