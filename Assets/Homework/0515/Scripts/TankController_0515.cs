using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

public class TankController_0515 : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 direction;
    private Vector2 inputDirection;

    [SerializeField] private int moveSpeed = 2;
    [SerializeField] private int rotateSpeed = 90;

    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject turretHead;
    [SerializeField] private float bulletCoolTime;

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

    private void OnFire(InputValue inputValue)
    {
        Instantiate(bullet, turretHead.transform.position, turretHead.transform.rotation);
    }

    private Coroutine bulletRepeatCoroutine;
    private void OnRepeatFire(InputValue inputValue)
    {
        if (inputValue.isPressed)
        {
            bulletRepeatCoroutine = StartCoroutine(BulletRepeatRoutine());
        }
        else
        {
            StopCoroutine(bulletRepeatCoroutine);
        }
    }

    IEnumerator BulletRepeatRoutine()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(bulletCoolTime);
            Instantiate(bullet, turretHead.transform.position, turretHead.transform.rotation);
        }
    }
}
