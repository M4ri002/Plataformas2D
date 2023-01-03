using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditor;
using UnityEngine;

public class AbrirConPulsador : MonoBehaviour
{
    public Transform door, Open, Close;
    public float speed;
    bool isEnter;
    public BotonPulsador boton;

    public void Update()
    {
        door.transform.position = Vector2.MoveTowards(door.transform.position, (isEnter && boton.pulsado) ? Open.position : Close.position, speed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isEnter = true;


        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isEnter = false;

        }

    }

}
