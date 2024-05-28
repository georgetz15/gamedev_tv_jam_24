using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1.0f;

    private Vector3 moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var newPos = transform.position + Time.fixedDeltaTime * moveSpeed * moveDirection.normalized;
        var cam = Camera.main;
        var start = cam.ScreenToWorldPoint(Vector3.zero);
        var end = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        Debug.Log($"Start = {start}");
        Debug.Log($"End = {end}");
        newPos.x = Mathf.Clamp(newPos.x, start.x, end.x);
        newPos.y = Mathf.Clamp(newPos.y, start.y, end.y);
        transform.position = newPos;
    }

    private void OnMove(InputValue value)
    {
        moveDirection = value.Get<Vector2>();
    }
}