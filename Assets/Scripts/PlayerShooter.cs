using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerShooter : MonoBehaviour
{
    private Animator animator;

    [Header("Shooter")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletPoint;
    [SerializeField] private float repeatTime;


    public UnityEvent OnFired;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    private Coroutine bulletRoutine;
    private void OnFire(InputValue inputValue)
    {
        Fire();
    }

    public void Fire()
    {
        Instantiate(bulletPrefab, bulletPoint.transform.position, bulletPoint.transform.rotation);
        animator.SetTrigger("Fire");
        GameManager.Data.AddShootCount(1);
        OnFired?.Invoke();
    }

    IEnumerator BulletMakeRoutine()
    {
        while (true)
        {
            Fire();
            yield return new WaitForSeconds(repeatTime);
        }
    }

    private void OnRepeatFire(InputValue inputValue)
    {
        if (inputValue.isPressed)
        {
            if (bulletRoutine != null)
            {
                StopCoroutine(bulletRoutine);
            }
            bulletRoutine = StartCoroutine(BulletMakeRoutine());
        }
        else
        {
            StopCoroutine(bulletRoutine);
        }
    }

}
