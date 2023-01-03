using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovHorizontal : MonoBehaviour
{
    public float speed = 10;
    public GroundedDetection_Raycast ground;
    private Rigidbody2D rb;
    Animator anim;
    public bool sePuedeMover = true;
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        
            //transform.position = transform.position + new Vector3(horizontal * Time.deltaTime * speed, 0);
        if (sePuedeMover)
        {

            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            if (horizontal > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);

            }
            if (horizontal < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);

            }
        }
        anim.SetBool("grounded", ground.grounded);
        anim.SetBool("moving", horizontal != 0);

       
    }
}
