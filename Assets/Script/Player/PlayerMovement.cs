using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.U2D;
using UnityEngine.Windows;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Vector2 inputVec;

    private PlayerInput _input;
    private Rigidbody2D _rigidBody;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    void Start()
    {
        _input = GetComponent<PlayerInput>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        _animator.SetFloat("Speed",inputVec.magnitude);

         if(_input.HORIZONTAL_MOVEMENT!=0)
        {
            _spriteRenderer.flipX = _input.HORIZONTAL_MOVEMENT < 0;
        }
    }

    private void Move()
    {
        inputVec.Set(_input.HORIZONTAL_MOVEMENT, _input.VERTICAL_MOVEMENT);
        Vector2 deltaPosition = speed * inputVec.normalized * Time.fixedDeltaTime;

        _rigidBody.MovePosition(_rigidBody.position + deltaPosition);
    }

    

}
