using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector3 moveDirection;
    private Rigidbody rb;

    [SerializeField] private int moveSpeed;
    [SerializeField] private int jumpPower;
    [Header("Shooter")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletPoint;
    [SerializeField] private float repeatTime;
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

    private Coroutine bulletRoutine;
    private void OnFire(InputValue inputValue)
    {
        Instantiate(bulletPrefab, bulletPoint.transform.position, bulletPoint.transform.rotation);
    }

    IEnumerator BulletMakeRoutine()
    {
        while (true)
        {
            Instantiate(bulletPrefab, bulletPoint.transform.position, bulletPoint.transform.rotation);
            yield return new WaitForSeconds(repeatTime);
        }
    }

    private void OnRepeatFire(InputValue inputValue)
    {
        if (inputValue.isPressed)
        {
            bulletRoutine = StartCoroutine(BulletMakeRoutine());
        }
        else
        {
            StopCoroutine(bulletRoutine);
        }
    }
}
