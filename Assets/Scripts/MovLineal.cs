using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovLineal : MonoBehaviour
{
    public List<Transform> puntos;
    int puntoActual;
    public float velPlataforma;
    public float velPlus;
    public float wait;
    public bool Girar;
    public bool Esperar;


    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
        if (Vector3.Distance(transform.position, puntos[puntoActual].position) < 0.01f)
        {
            puntoActual++;
            if (Girar)
            {
                transform.eulerAngles = transform.eulerAngles.y == 0 ? new Vector3(0, 180, 0) : new Vector3(0, 0, 0);
            }
            if (puntoActual >= puntos.Count)
            {
                puntoActual = 0;
                if (Esperar)
                {
                    StartCoroutine("Espera");
                }
            }
            else
            {
                velPlataforma = velPlus;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, puntos[puntoActual].position, velPlataforma * Time.deltaTime);
    }

    IEnumerator Espera()
    {
        velPlataforma = 0;
        yield return new WaitForSeconds(wait);
        velPlataforma = 5;

    }
}
