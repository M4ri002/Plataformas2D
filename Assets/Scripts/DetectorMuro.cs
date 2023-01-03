using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorMuro : MonoBehaviour
{
    public Transform detect;
    public LayerMask wallMask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Collider2D collision = Physics2D.OverlapCircle(detect.position, 0.1f, wallMask);

        if (collision != null)
        {
            transform.eulerAngles = transform.eulerAngles.y == 0 ? new Vector3(0, 180, 0) : new Vector3(0, 0, 0);
        }
 
    }
}
