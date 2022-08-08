using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{

    [Header("Speed Setup")]
    public Vector2 friction = new Vector2(-.1f, 0);
    public float speed;
    public float speedRun;
    public float forceJump = 2;
    public Rigidbody2D myRigidbody;

    [Header("Animation Setup")]
    public float jumpScaleY = 1.5f;
    public float jumpScaleX = 0.7f;
    public float animationDuration = .3f;

    [Header("Player Animation")]
    private string boolRun = "Run";
    public Animator animator;
    public float playerSwipeDuration = .1f;

    private float _currentSpeed;
    private bool _isRunning = false;
   
    private void Update() 
    {
        HandleJump();
        HandleMovement();
    }

    private void HandleMovement()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = speedRun;
            animator.speed = 2;
        }
        else 
        {
             _currentSpeed = speed;
             animator.speed = 1;
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidbody.velocity = new Vector2(-_currentSpeed, myRigidbody.velocity.y);
            if(myRigidbody.transform.localScale.x != -1)
            {
                myRigidbody.transform.DOScaleX(-1, playerSwipeDuration);
            }
            animator.SetBool(boolRun, true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);
            if(myRigidbody.transform.localScale.x != 1)
            {
                myRigidbody.transform.DOScaleX(1, playerSwipeDuration);
            }
            animator.SetBool(boolRun, true);
        }
        else 
        {
            animator.SetBool(boolRun, false);
        }

        if(myRigidbody.velocity.x > 0)
        {
            myRigidbody.velocity += friction;
        }
        else if (myRigidbody.velocity.x < 0)
        {
            myRigidbody.velocity -= friction;
        }
    }

    private void HandleJump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            myRigidbody.velocity = Vector2.up * forceJump;
            myRigidbody.transform.localScale = Vector2.one;

            DOTween.Kill(myRigidbody.transform);
            HandleScaleJump();
    }

    private void HandleScaleJump()
    {
        myRigidbody.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo);
        myRigidbody.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo);
    }
}
