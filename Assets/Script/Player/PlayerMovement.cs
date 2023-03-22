using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Vector2 inputVec;

    private PlayerInput _input;
    private Rigidbody2D _rigidBody;


    void Start()
    {
        _input = GetComponent<PlayerInput>();
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        inputVec.Set(_input.HORIZONTAL_MOVEMENT, _input.VERTICAL_MOVEMENT);
        Vector2 deltaPosition = speed * inputVec.normalized * Time.fixedDeltaTime;

        _rigidBody.MovePosition(_rigidBody.position + deltaPosition);
    }

    

}
