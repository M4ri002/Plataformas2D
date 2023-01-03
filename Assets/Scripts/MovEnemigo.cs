using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovEnemigo : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public Transform detect;
    public LayerMask wallMask;
    private playerControl Rebotecabeza;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Rebotecabeza = GetComponent<playerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(transform.right.x * speed, rb.velocity.y);
        Collider2D collision = Physics2D.OverlapCircle(detect.position, 0.1f, wallMask);
        
        if(collision != null)
        {
            transform.eulerAngles = transform.eulerAngles.y == 0 ? new Vector3(0, 180, 0) : new Vector3(0, 0, 0);
        }
    }


}
