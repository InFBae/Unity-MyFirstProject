using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class TankShotContoller_0518 : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private AudioSource shotFiringSound;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject muzzlePoint;
    [SerializeField] private float bulletCoolTime;

    public UnityEvent OnFired;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnFire(InputValue inputValue)
    {
        Fire();
    }

    public void Fire()
    {
        Instantiate(bullet, muzzlePoint.transform.position, muzzlePoint.transform.rotation);
        animator.SetTrigger("Fire");
        GameManager_0518.Data.AddShootCount(1);
        OnFired?.Invoke();
    }

    private Coroutine bulletRepeatCoroutine;
    private void OnRepeatFire(InputValue inputValue)
    {
        if (inputValue.isPressed)
        {
            if (bulletRepeatCoroutine != null)
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
            Fire();
        }
    }
}
