using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class playerControl : MonoBehaviour
{
    public GameObject[] hearts;
    public float ContMoneda = 0;
    public bool OpenDoor = false;
    public LifeControler VidasRestantes;
    private Rigidbody2D rb;
    [SerializeField] public Vector2 VelRebote;
    public float VelReboteCabeza;
    public string nombreNivel;

    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Moneda")
        {
            Destroy(collision.gameObject);
            ContMoneda++;
            if (ContMoneda <= 0)
            {
                OpenDoor = true;
            }
        }
        else if (collision.tag == "Enemigo")
        {
            rb.AddForce(transform.up * VelReboteCabeza, ForceMode2D.Impulse);
        }

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo") || collision.gameObject.CompareTag("Bala") || collision.gameObject.CompareTag("Trampa"))
        {
            if (VidasRestantes.vidas_restantes < 1)
            {
                Destroy(hearts[0].gameObject);
                RecargarNivel();
            }
            else if (VidasRestantes.vidas_restantes < 2)
            {
                Destroy(hearts[1].gameObject);
            }
            else if (VidasRestantes.vidas_restantes < 3)
            {
                Destroy(hearts[2].gameObject);
            }
        }
    }
    public void Rebote(Vector2 puntoGolpe)
    {
        rb.velocity = new Vector2(-VelRebote.x * puntoGolpe.x, VelRebote.y);
    }

    public void ReboteCabeza()
    {
        rb.velocity = new Vector2(rb.velocity.x, VelReboteCabeza);
    }

    public void RecargarNivel()
    {
        SceneManager.LoadScene(nombreNivel);
    }

}
