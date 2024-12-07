using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    Vector2 rawInput;

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
        Debug.Log("Move: " + rawInput);
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 input = rawInput;
        transform.position += input * speed * Time.deltaTime;
    }
}
