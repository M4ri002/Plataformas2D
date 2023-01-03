using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.WSA;

public class Disparo : MonoBehaviour
{
    public float spawnTime = 1;
    public Transform spawner;
    public GameObject bulletPrefab;
    private float count;

    private void Start()
    {
        count = spawnTime;
    }

    public void Update()
    {
        if (count <= 0)
        {
            count = spawnTime;
            Invoke("LaunchBullet", 0.5f);
        }
        else
        {
            count -= Time.deltaTime;
        }
    }

    public void LaunchBullet()
    {
        GameObject newBullet;

        newBullet = Instantiate(bulletPrefab, spawner.position, spawner.rotation);
    }
}
