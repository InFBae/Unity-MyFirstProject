using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    private Vector3 moveDirection;
    private Rigidbody rb;

    [SerializeField] private int moveSpeed;
    [SerializeField] private int jumpPower;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        rb.AddForce(moveDirection * moveSpeed);
    }


    private void OnMove(InputValue inputValue)
    {
        moveDirection.x = inputValue.Get<Vector2>().x;
        moveDirection.z = inputValue.Get<Vector2>().y;
    }

    private void OnJump(InputValue inputValue)
    {
        Jump();
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }
}
