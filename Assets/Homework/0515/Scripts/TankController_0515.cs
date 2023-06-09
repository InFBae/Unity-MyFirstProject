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
    private float turretDir;

    [SerializeField] private int moveSpeed = 2;
    [SerializeField] private int rotateSpeed = 90;

    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject turretHead;
    [SerializeField] private GameObject muzzlePoint;
    [SerializeField] private float bulletCoolTime;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

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

    private void OnFire(InputValue inputValue)
    {
        Instantiate(bullet, muzzlePoint.transform.position, muzzlePoint.transform.rotation);
    }

    private void OnTurretRotate(InputValue inputValue)
    {
        turretDir = inputValue.Get<float>();       
    }

    private void TurretRotate()
    {
        turretHead.transform.Rotate(Vector3.up, turretDir * rotateSpeed * Time.deltaTime);
    }

    private Coroutine bulletRepeatCoroutine;
    private void OnRepeatFire(InputValue inputValue)
    {
        if (inputValue.isPressed)
        {
            if(bulletRepeatCoroutine != null)
                StopCoroutine(bulletRepeatCoroutine);
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
            Instantiate(bullet, muzzlePoint.transform.position, muzzlePoint.transform.rotation);
        }
    }
}
