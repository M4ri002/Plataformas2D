using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LifeControler : MonoBehaviour
{
    public int vidas_restantes;
    public int vidas_maximas;
    public float invencible_time;
    bool invencible;
    private playerControl playerControl;
    private MovHorizontal movJugador;
    public float TiempoControl;
    private Animator animator;
    public bool Reaparece;
    public enum DeathMode { Teleport, ReloadScreen, Destroy}
    public DeathMode death_mode;
    public Transform respawn;
    Rigidbody2D rb;

    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        playerControl = GetComponent<playerControl>();
        animator= GetComponent<Animator>(); 
        movJugador = GetComponent<MovHorizontal>();
        vidas_restantes = vidas_maximas;  
    }

    // Update is called once per frame

    public void Damage(Vector2 posicion, int daño = 1, bool ignorarInvencible = false)
    {
        
        if (!invencible || ignorarInvencible)
        {
            animator.SetTrigger("Golpe");
            StartCoroutine(PerderControl());
            playerControl.Rebote(posicion);
            vidas_restantes -= daño;
            StartCoroutine(Invencible_Corutine());

        }
    }

     //HE PREFERIDO QUE CUANDO NO TENGAS VIDAS SE REINICIE EL NIVEL EN VEZ DE REAPARECER
    //public void Muerte()
    //{
    //    Debug.Log("He muerto");
    //    switch (death_mode)
    //    {
    //        case DeathMode.Teleport:
    //            rb.velocity = new Vector2(0, 0);
    //            transform.position = respawn.position;
    //            vidas_restantes = vidas_maximas;
    //            break;
    //        case DeathMode.ReloadScreen:

    //            break;
    //        case DeathMode.Destroy:
    //            Destroy(gameObject);
    //            break;
    //        default:
    //            break;
    //    }
    //}


    IEnumerator Invencible_Corutine()
    {
        invencible = true;
        yield return new WaitForSeconds(invencible_time);
        invencible = false;
    }

    IEnumerator PerderControl()
    {
        Debug.Log("Perdida Control");
        movJugador.sePuedeMover = false;
        yield return new WaitForSeconds(TiempoControl);
        movJugador.sePuedeMover = true;

    }
}
