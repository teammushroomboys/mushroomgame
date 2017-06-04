﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    // 1 - Designer variables

    /// <summary>
    /// Object speed
    /// </summary>
    public Vector2 speed = new Vector2(10, 10);

    /// <summary>
    /// Moving direction
    /// </summary>
    public Vector2 direction = new Vector2(-1, 0);

    private Vector2 movement;
    private Rigidbody2D rigidbodyComponent;

    // Use this for initialization
    void Start () {
        rigidbodyComponent = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        // 2 - Movement
        movement = new Vector2(
        speed.x * direction.x,
        speed.y * direction.y);
    }

    void FixedUpdate()
    {
        //if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();

        // Apply movement to the rigidbody
        rigidbodyComponent.velocity = movement;
    }
}
