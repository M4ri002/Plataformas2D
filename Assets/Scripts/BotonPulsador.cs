using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonPulsador : MonoBehaviour
{
    public bool pulsado;
    private bool StateAnim = true;
    private Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && StateAnim)
        {
            animator.SetTrigger("Pulsado");
            pulsado = true;
            StateAnim = false;
        }
    }
}
