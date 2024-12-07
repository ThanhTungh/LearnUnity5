using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour     // Player class to move the player  
{
    [SerializeField] private float speed = 1.0f;
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;
    Vector2 rawInput;
    Vector2 minBounds;
    Vector2 maxBounds;

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
        Debug.Log("Move: " + rawInput);
    }
    void Start() {
        InitBounds();
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void InitBounds()
    {
        Camera cam = Camera.main;
        minBounds = cam.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = cam.ViewportToWorldPoint(new Vector2(1, 1));
    }

    private void Move()
    {
        Vector3 input = rawInput * speed * Time.deltaTime;
        Vector2 pos = new Vector2();
        pos.x = Mathf.Clamp(transform.position.x + input.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        pos.y = Mathf.Clamp(transform.position.y + input.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);
        transform.position = pos;
    }
}
