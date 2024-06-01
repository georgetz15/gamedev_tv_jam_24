using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int health = 1;
    [SerializeField] private float moveSpeed = 1.0f;
    [field: SerializeField] public float powerupDropChance { get; private set; } = 0.0f;
    [field: SerializeField] public GameObject powerup { get; private set; }

    private void Awake()
    {
        GetComponent<Rigidbody2D>().velocity = moveSpeed * Vector2.left;
    }

    public void DealDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            var dropRoll = Random.Range(0.0f, 1.0f);
            if (dropRoll < powerupDropChance)
            {
                Instantiate(powerup, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }

    public void AddMoveSpeed(float speed)
    {
        GetComponent<Rigidbody2D>().velocity += speed * Vector2.left;
    }
}