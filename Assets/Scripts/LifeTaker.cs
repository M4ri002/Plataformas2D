using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTaker : MonoBehaviour
{
    public int damage;
    public bool ignoreInvenicble;
    public string target = "Player";
    public string target2 = "#";
    public bool DestroyItem = false;
    public playerControl Reload;
    public bool instakill = false;

    private void Start()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(target))
        {
            if (instakill)
            {
                Reload.RecargarNivel();
            }
                collision.gameObject.GetComponent<LifeControler>().Damage(collision.GetContact(0).normal, damage, ignoreInvenicble);
            if (DestroyItem)
            {
                Destroy(gameObject);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == target)
        {
            Destroy(gameObject);
        }
    }


}
