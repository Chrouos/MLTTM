using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stone : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Stone;
    public GameObject StonePrefab;

    public float totalCoolTime = 0.7f;
    public float cdTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && cdTime <= 0)
        {
            
            Shoot();
            cdTime = totalCoolTime;
        }

        cdTime -= Time.deltaTime; // ´î¤Ö§N«o
    }

    void Shoot()
    {
        Instantiate(StonePrefab, Stone.position, Stone.rotation);
    }
}
