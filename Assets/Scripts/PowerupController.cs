using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupController : MonoBehaviour
{
    [field: SerializeField] public float fireRateMultiplier { get; private set; } = 1.0f;
    [SerializeField] private float moveSpeed = 1.33f;

    private void Awake()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.left * moveSpeed;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        {
            var otherObj = other.gameObject;
            if (otherObj.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
        }
    }

    public void Consume()
    {
        Destroy(gameObject);
    }
}