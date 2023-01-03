using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject Teletransporte;
    private GameObject Player;
    Rigidbody2D rb;
    public float Cooldown;
    public BoxCollider2D colision;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        rb = Player.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        rb.velocity = new Vector2(0, 0);
        Player.transform.position = Teletransporte.transform.position;
        StartCoroutine(CooldownTime());
    }

    IEnumerator CooldownTime()
    {
        colision.enabled=false;
        yield return new WaitForSeconds(Cooldown);
        colision.enabled = true;



    }
}
