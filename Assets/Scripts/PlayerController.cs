using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private float fireRate = 1.0f;
    [SerializeField] private GameObject bulletSpawnPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 5.0f;

    private Vector3 moveDirection = Vector3.zero;
    private bool isFiring = false;
    private float fireTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Movement
        var newPos = transform.position + Time.fixedDeltaTime * moveSpeed * moveDirection.normalized;
        var cam = Camera.main;
        var start = cam.ScreenToWorldPoint(Vector3.zero);
        var end = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        newPos.x = Mathf.Clamp(newPos.x, start.x, end.x);
        newPos.y = Mathf.Clamp(newPos.y, start.y, end.y);
        transform.position = newPos;

        // Firing
        if (isFiring)
        {
            fireTime -= Time.deltaTime;
            if (fireTime < 0)
            {
                // Fire!
                var bullet = Instantiate(bulletPrefab,
                    bulletSpawnPoint.transform.position,
                    bulletSpawnPoint.transform.rotation);
                bullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * bulletSpeed;

                // Reset timer
                fireTime += 1.0f / fireRate;
            }
        }
        else
        {
            fireTime -= Time.deltaTime;
            if (fireTime < 0) fireTime = 0;
        }
    }

    private void OnMove(InputValue value)
    {
        moveDirection = value.Get<Vector2>();
    }

    private void OnFire(InputValue value)
    {
        isFiring = value.Get<float>() > 0.5;
    }
}