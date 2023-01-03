using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedDetection_Raycast : MonoBehaviour
{
    public bool grounded;
    public float length = 2;
    public LayerMask mask; //Para ignorar coliders

    public List<Vector3> OriginPoints; //Lista de puntos de origen


    void Update()
    {
        grounded = false;
        for (int i = 0; i < OriginPoints.Count; i++)
        {
            Debug.DrawRay(transform.position + OriginPoints[i], Vector3.down * length, Color.magenta);
            RaycastHit2D hit = Physics2D.Raycast(transform.position + OriginPoints[i], Vector3.down, length, mask); //Detecta las colisiones con el mundo con la linea magenta
            if (hit.collider != null)
            {
                if (hit.collider.tag == "PlataformaMovil")
                {
                    transform.parent = hit.transform;
                }

                Debug.DrawRay(transform.position + OriginPoints[i], Vector3.down * hit.distance, Color.green);
                grounded = true;
            }
        }
        if (!grounded)
        {
            transform.parent = null;

        }
    }
}
