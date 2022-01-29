using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustEffect : MonoBehaviour
{

    public GameObject Dust_A_Prefab;
    public bool grounded;
    // Start is called before the first frame update
    
    void Start()
    {
        grounded = true;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "floor")
        {
            grounded = true;
            gameObject.GetComponent<ParticleSystem>().Play(); //¼½©ñ
            
            Debug.Log("Touch Floor");
        }
    }
    public bool JumpKey
    {
        get
        {
            return Input.GetKeyDown(KeyCode.W);
        }
    }
    void LeaveGround()
    {
        if (grounded == true && JumpKey )
        {
            grounded = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        LeaveGround();
    }
}
