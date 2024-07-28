using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    //private Animator animator;
    private GameInput gameInput;
    private Rigidbody2D rb;
    

    public float speed = 100f;
    public float rotSpeed = 180f;
    void Start()
    {
        gameInput = GameInput.Instance;
        //animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        //HandleRotation();
    }

    private void HandleRotation()
    {
        Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z;
        z += gameInput.GetSpaceshipRotation() * rotSpeed * Time.deltaTime;
        rot = Quaternion.Euler(0, 0, z);
        transform.rotation = rot;
    }

    private void HandleMovement()
    {
        Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z;
        z += gameInput.GetSpaceshipRotation() * rotSpeed * Time.deltaTime;
        rot = Quaternion.Euler(0, 0, z);
        transform.rotation = rot;

        Vector2 movedir = gameInput.GetSpaceshipMovementVectorNormalised();
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, movedir.y * speed * Time.deltaTime, 0);

        pos += rot * velocity;
        transform.position = pos;
        /*Debug.Log(movedir);
        rb.velocity = new Vector2(movedir.x * speed * Time.deltaTime, movedir.y * speed * Time.deltaTime);*/
    }
}
