using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzarObjeto : MonoBehaviour
{
    public GameObject hachas;
    public float timer = 2f;



    void Update()
    {
        StartCoroutine(Espera());
    }

    IEnumerator Espera()
    {
        Debug.Log("Disparo");
        yield return new WaitForSeconds(3f);
        //Instantiate(hachas, transform.position, transform.rotation);

    }
}
