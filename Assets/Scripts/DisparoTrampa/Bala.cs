using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bala : MonoBehaviour
{
    public Transform bala;
    public float speed = 2;
    public float lifeTime = 2;
    public bool left;
    public bool right;
    public bool up;
    public bool down;
    public bool rotacion;
    public float rotspeed = 1;


    //public bool left; Para controlar la direccion del disparo

    public void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    public void Update()
    {
        if (left)
        {
            if (rotacion)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
                bala.transform.Rotate(Vector3.forward * rotspeed * Time.deltaTime);
            }
            transform.Translate(Vector2.left * speed * Time.deltaTime);

        }
        if (right)
        {
            if (rotacion)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                bala.transform.Rotate(Vector3.forward * rotspeed * Time.deltaTime);
            }
            transform.Translate(Vector2.right * speed * Time.deltaTime);

        }
        if (up)
        {
            if (rotacion)
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
                bala.transform.Rotate(Vector3.forward * rotspeed * Time.deltaTime);
            }
            transform.Translate(Vector2.up * speed * Time.deltaTime);

        }
        if (down)
        {
            if (rotacion)
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
                bala.transform.Rotate(Vector3.forward * rotspeed * Time.deltaTime);
            }
            transform.Translate(Vector2.down * speed * Time.deltaTime);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BordeMapa"))
        {
            Destroy(gameObject);
        }
    }
}
