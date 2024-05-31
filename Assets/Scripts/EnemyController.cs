using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int health = 1;
    [SerializeField] private float moveSpeed = 1.0f;

    private void Awake()
    {
        GetComponent<Rigidbody2D>().velocity = moveSpeed * Vector2.left;
    }

    public void DealDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void AddMoveSpeed(float speed)
    {
        GetComponent<Rigidbody2D>().velocity += speed * Vector2.left;
    }
}