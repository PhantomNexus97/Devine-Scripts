using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPSController : MonoBehaviour
{
    [Header("Movement")]
    private float _moveSpeed;
    public float _walkSpeed;
    public float _sprintSpeed;
    public float _swingSpeed;
    public float _groundDrag;

    [Header("Jumping")]
    public float _jumpForce;
    public float _jumpCooldown;
    public float _airMultiplier;
    bool _readyToJump;

    [Header("Crouching")]
    public float _crouchSpeed;
    public float _crouchYScale;
    private float _startYScale;

    [Header("Keybinds")]
    public KeyCode _jumpKey = KeyCode.Space;
    public KeyCode _sprintKey = KeyCode.LeftShift;
    public KeyCode _crouchKey = KeyCode.LeftControl;

    [Header("Ground Check")]
    public float _playerHeight;
    public LayerMask _whatIsGround;
    public bool _grounded;

    [Header("Slope Handling")]
    public float _maxSlopeAngle;
    private RaycastHit _slopeHit;
    private bool _exitingSlope;


    public Transform _orientation;

    float _horizontalInput;
    float _verticalInput;

    Vector3 _moveDirection;

    Rigidbody _rb;

    public MovementState _state;
    public enum MovementState
    {
        swinging,
        walking,
        sprinting,
        crouching,
        air
    }

    public bool _swinging;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;

        _readyToJump = true;

        _startYScale = transform.localScale.y;
    }

    private void Update()
    {
        // ground check
        _grounded = Physics.Raycast(transform.position, Vector3.down, _playerHeight * 0.5f + 0.2f, _whatIsGround);

        MyInput();
        SpeedControl();
        StateHandler();

        // handle drag
        if (_grounded)
            _rb.drag = _groundDrag;
        else
            _rb.drag = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump
        if (Input.GetKey(_jumpKey) && _readyToJump && _grounded)
        {
            _readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), _jumpCooldown);
        }

        // start crouch
        if (Input.GetKeyDown(_crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, _crouchYScale, transform.localScale.z);
            _rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
        }

        // stop crouch
        if (Input.GetKeyUp(_crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, _startYScale, transform.localScale.z);
        }
    }

    private void StateHandler()
    {
        // Mode - Walking
        if (_grounded)
        {
            _state = MovementState.walking;
            _moveSpeed = _walkSpeed;
        }

        // Mode - Swinging
        else if (_swinging) 
        {
            _state = MovementState.swinging;
            _moveSpeed = _swingSpeed;
        }

        // Mode - Crouching
        else if (Input.GetKey(_crouchKey))
        {
            _state = MovementState.crouching;
            _moveSpeed = _crouchSpeed;
        }

        // Mode - Sprinting
        else if (_grounded && Input.GetKey(_sprintKey))
        {
            _state = MovementState.sprinting;
            _moveSpeed = _sprintSpeed;
        }

        // Mode - Air
        else
        {
            _state = MovementState.air;
        }
    }

    private void MovePlayer()
    {
        // calculate movement direction
        _moveDirection = _orientation.forward * _verticalInput + _orientation.right * _horizontalInput;

        // on slope
        if (OnSlope() && !_exitingSlope)
        {
            _rb.AddForce(GetSlopeMoveDirection() * _moveSpeed * 20f, ForceMode.Force);

            if (_rb.velocity.y > 0)
                _rb.AddForce(Vector3.down * 80f, ForceMode.Force);
        }

        // on ground
        else if (_grounded)
            _rb.AddForce(_moveDirection.normalized * _moveSpeed * 10f, ForceMode.Force);

        // in air
        else if (!_grounded)
            _rb.AddForce(_moveDirection.normalized * _moveSpeed * 10f * _airMultiplier, ForceMode.Force);

        // turn gravity off while on slope
        _rb.useGravity = !OnSlope();
    }

    private void SpeedControl()
    {
        // limiting speed on slope
        if (OnSlope() && !_exitingSlope)
        {
            if (_rb.velocity.magnitude > _moveSpeed)
                _rb.velocity = _rb.velocity.normalized * _moveSpeed;
        }

        // limiting speed on ground or in air
        else
        {
            Vector3 flatVel = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);

            // limit velocity if needed
            if (flatVel.magnitude > _moveSpeed)
            {
                Vector3 limitedVel = flatVel.normalized * _moveSpeed;
                _rb.velocity = new Vector3(limitedVel.x, _rb.velocity.y, limitedVel.z);
            }
        }
    }

    private void Jump()
    {
        _exitingSlope = true;

        // reset y velocity
        _rb.velocity = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);

        _rb.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        _readyToJump = true;

        _exitingSlope = false;
    }

    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out _slopeHit, _playerHeight * 0.5f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up, _slopeHit.normal);
            return angle < _maxSlopeAngle && angle != 0;
        }

        return false;
    }

    private Vector3 GetSlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(_moveDirection, _slopeHit.normal).normalized;
    }
}