using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1MoveTest : MonoBehaviour
{
    
    public float speed = 10f;
    public float jumpPower = 15f;
    public int extraJumps = 1;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform feet;

    int jumpCount;
    bool isGrounded; // 是否在地板上
    float moveX; // 水平移動
    float jumpCoolDown; // 跳躍冷卻

    void Update(){
        
        moveX = Input.GetAxis("Player1");
        if (Input.GetKey(KeyCode.W))
            Jump();

        CheckGrounded();

    }

    private void FixedUpdate() {
        
        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);
        
    }

    void Jump(){
        if(isGrounded || jumpCount < extraJumps){
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            jumpCount++;
        }
    }

    void CheckGrounded(){
        if(Physics2D.OverlapCircle(feet.position, 0.5f, groundLayer)){
            isGrounded = true;
            jumpCount = 0;
            jumpCoolDown = Time.time + 0.2f;
        }
        else if(Time.time < jumpCoolDown){
            isGrounded = true;
        }
        else{
            isGrounded = false;
        }

    }


}
