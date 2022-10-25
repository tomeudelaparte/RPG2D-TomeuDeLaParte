using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public const string HORIZONTAL = "Horizontal", VERTICAL = "Vertical";

    public static bool playerCreated;

    public Vector2 lastDirection;

    public string nextUuid;

    private float inputTol = 0.2f;
    private float xInput, yInput;

    private bool isWalking;

    private Animator _animator;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        playerCreated = true;
    }

    void Update()
    {
        xInput = Input.GetAxisRaw(HORIZONTAL);
        yInput = Input.GetAxisRaw(VERTICAL);
        isWalking = false;


        // HORIZONTAL MOVEMENT
        if (Mathf.Abs(xInput) > inputTol)
        {
            //Vector3 translation = new Vector3(xInput * speed * Time.deltaTime, 0, 0);
            //transform.Translate(translation);

            _rigidbody.velocity = new Vector2(xInput * speed, 0);

            isWalking = true;
            lastDirection = new Vector2(xInput, 0);

        }

        // VERTICAL MOVEMENT
        if (Mathf.Abs(yInput) > inputTol)
        {
            //Vector3 translation = new Vector3(0, yInput * speed * Time.deltaTime, 0);
            //transform.Translate(translation);

            _rigidbody.velocity = new Vector2(0, yInput * speed);

            isWalking = true;
            lastDirection = new Vector2(0, yInput);
        }
    }

    private void LateUpdate()
    {
        if (!isWalking)
        {
            _rigidbody.velocity = Vector2.zero;
        }

        _animator.SetFloat(HORIZONTAL, xInput);
        _animator.SetFloat(VERTICAL, yInput);
        _animator.SetFloat("LastHorizontal", lastDirection.x);
        _animator.SetFloat("LastVertical", lastDirection.y);
        _animator.SetBool("IsWalking", isWalking);
    }
}
