using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;

public class TurretController : MonoBehaviour
{
    private float turretRotate;
    [SerializeField] private float turretRotateSpeed = 90;
    [SerializeField] private GameObject turret;

    private void Update()
    {
        Rotate();
    }
    private void OnRotate(InputValue inputValue)
    {
        turretRotate = inputValue.Get<float>();    
    }
    private void Rotate()
    {
        turret.transform.Rotate(Vector3.up, turretRotate * turretRotateSpeed * Time.deltaTime);
    }
}
