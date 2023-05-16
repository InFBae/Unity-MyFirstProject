using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private GameObject explosionEffect;

    private Rigidbody rb;
    private AudioSource bulletExplosionSound;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        bulletExplosionSound = GetComponent<AudioSource>();
    }

    private void Start()
    {
        rb.velocity = transform.forward * bulletSpeed;
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        bulletExplosionSound.Play();
        Destroy(gameObject);       
    }
}
