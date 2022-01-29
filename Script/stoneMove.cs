using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stoneMove : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
   // public AudioSource play;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //Debug.Log(hitInfo.name);
        Damage player = hitInfo.GetComponent<Damage>();
        if(player != null)
        {
            player.TakeDamage();
           // play.Play();
        }

        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
