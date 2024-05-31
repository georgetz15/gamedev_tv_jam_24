using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private int damage = 1;

    private void OnTriggerEnter2D(Collider2D col)
    {
        // Scene boundary => self-destruct
        var other = col.gameObject;
        if (other.CompareTag("Scene Boundary"))
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Enemy => deal damage
        var enemyCtrl = other.gameObject.GetComponent<EnemyController>();
        if (enemyCtrl)
        {
            enemyCtrl.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}