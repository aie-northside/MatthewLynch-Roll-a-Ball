﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    private Rigidbody _rigidBody;
    private bool _isGrounded;
    public Transform respawnPosition;
    private Vector2 _moveVector;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (_isGrounded == true)
            {
                _rigidBody.AddForce(new Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }

        Vector2 moveVector = Vector2.zero;
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.y = Input.GetAxis("Vertical");

    }
    private void FixedUpdate()
    {
        _rigidBody.AddForce(new Vector3(_moveVector.x, 0, _moveVector.y) * speed, ForceMode.Force);
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            _isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            _isGrounded = false;
        }
    }

    public void DisabledBallController()
    {
        _rigidBody.isKinematic = true;
        this.enabled = false;
    }

    public void Respawn()
    {
        this.gameObject.transform.position = respawnPosition.position;
        _rigidBody.velocity = Vector3.zero;
    }

}