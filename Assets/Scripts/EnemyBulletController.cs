using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4.0f;


    private void Awake()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.left * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // Scene boundary => self-destruct
        var other = col.gameObject;
        if (other.CompareTag("Scene Boundary"))
        {
            Destroy(gameObject);
        }
        
        // Enemy => deal damage
        var enemyCtrl = other.gameObject.GetComponent<PlayerController>();
        if (enemyCtrl)
        {
            Destroy(gameObject);
        }
    }

    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     // Enemy => deal damage
    //     var enemyCtrl = other.gameObject.GetComponent<PlayerController>();
    //     if (enemyCtrl)
    //     {
    //         Destroy(gameObject);
    //     }
    // }
}