using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int health = 1;
    [SerializeField] private float moveSpeed = 1.0f;
    [field: SerializeField] public float powerupDropChance { get; private set; } = 0.0f;
    [field: SerializeField] public GameObject powerup { get; private set; }
    [SerializeField] private float fireRate = 1.5f;
    [SerializeField] private float fireChance = 0.5f;
    [SerializeField] private GameObject bulletSpawnPoint;
    [SerializeField] private GameObject bullet;
    [SerializeField] private int scoreReward = 10;

    private float fireTime = 0.0f;

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
                AudioManager.instance.PlayPowerupDropped();
            }
            
            AudioManager.instance.PlayEnemyDestroyed();
            GameManager.instance.AddScore(scoreReward);
            Destroy(gameObject);
        }
    }

    public void AddMoveSpeed(float speed)
    {
        GetComponent<Rigidbody2D>().velocity += speed * Vector2.left;
    }

    private void FixedUpdate()
    {
        // Fire at player
        fireTime -= Time.fixedDeltaTime;
        if (fireTime < 0)
        {
            var fireRoll = Random.value;
            if (fireRoll < fireChance)
            {
                AudioManager.instance.PlayEnemyFire();
                Instantiate(bullet, bulletSpawnPoint.transform.position, Quaternion.identity);
            }

            fireTime += 1.0f / fireRate;
        }
    }
}