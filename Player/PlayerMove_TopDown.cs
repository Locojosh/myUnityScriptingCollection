using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove_TopDown : MonoBehaviour
{
    public float speed = 500.0f;

    //private
    Rigidbody2D rb;
    Vector2 inputs; //Horizontal and Vertical

    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }
    private void Update() 
    {
        inputs = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
    }
    private void FixedUpdate() 
    {
        rb.velocity = inputs.normalized * speed * Time.deltaTime;
    }
}
