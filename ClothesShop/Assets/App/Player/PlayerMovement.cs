using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    [SerializeField] private float Speed = 1;
    [SerializeField] private float CollisionOffset = 3f;
    float calculatedSpeed;

    private Vector2 movement;
    bool IsMoving = false;

    [SerializeField] private ContactFilter2D contactFilter;
    [SerializeField] private List<RaycastHit2D> castCollision = new List<RaycastHit2D>();

    [SerializeField] private Animator animator;
    

    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();
    }


    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        Application.targetFrameRate = 50;
    }


    private void FixedUpdate()
    {

        Vector2 movePossible = TestPossibleMoves();

        IsMoving = (movePossible != Vector2.zero);

        if (IsMoving)
        {
            calculatedSpeed = Speed * Time.fixedDeltaTime;

            Vector2 movePosition = rigidBody.position + movePossible * calculatedSpeed;
            rigidBody.MovePosition(movePosition);

            MoveAnimation(true);
        }
        else
        {
            MoveAnimation(false);
        }
    }


    private bool CheckMove(Vector2 direction)
    {
        calculatedSpeed = Speed * Time.fixedDeltaTime;
        int countPhysicsShape2D = 0;


        countPhysicsShape2D = rigidBody.Cast(direction, contactFilter, castCollision, calculatedSpeed + CollisionOffset);

        if (countPhysicsShape2D == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    private Vector2 TestPossibleMoves()
    {
        if (CheckMove(movement)) return movement;

        Vector2 LastMove = new Vector2(movement.x, 0);
        if (CheckMove(LastMove)) return LastMove;


        LastMove = new Vector2(0, movement.y);
        if (CheckMove(LastMove)) return LastMove;

        return Vector2.zero;
    }


    private void MoveAnimation(bool shouldMove)
    {

        if (!shouldMove)
        {
            animator.SetBool("IsMoving", false);
        }
        else
        {
            animator.SetBool("IsMoving", true);
        }
    }
}
