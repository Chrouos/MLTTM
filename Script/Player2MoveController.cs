using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2MoveController : MonoBehaviour
{

    public Animator playerAni;

    // 速度
    public float horizontalDirection; // 水平方向
    public float speed_X = 5f; // 水平移動的速度
    private float speed_Y; // 目前垂直速度

    public float maxSpeedX; // 最大水平速度

    [Range(0, 150)]
    public float Force_X; // 水平推力
    public float Force_Y = 5; // 往上跳的力度

    // 角色物理
    Rigidbody2D playerRigidbody2D;

    // 狀態確認
    [Range(0, 0.5f)]
    public float distance; // 感應地板的距離
    public Transform groundCheck; // 偵測地板的射線起點
    public LayerMask groundLayer; // 地板的圖層
    public bool grounded; // 是否在地面上
    bool walk = false;

    void Start()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }


    // 按 W 就可以往上跳，確認是否按了 W 
    public bool JumpKey
    {
        get
        {
            return Input.GetKeyDown(KeyCode.UpArrow);
        }
    }
    // 把速動控制
    public void ControlSpeed()
    {
        speed_X = playerRigidbody2D.velocity.x;
        speed_Y = playerRigidbody2D.velocity.y;
        float newSpeedX = Mathf.Clamp(speed_X, -maxSpeedX, maxSpeedX);
        playerRigidbody2D.velocity = new Vector2(newSpeedX, speed_Y);
    }
    // 是否在地面上
    /*bool isGround{
        get{
            Vector2 start = groundCheck.position;
            Vector2 end = new Vector2(start.x, start.y - distance);

            Debug.DrawLine(start, end, Color.blue);
            grounded = Physics2D.Linecast(start, end, groundLayer);
            return grounded;
        }
    }
    */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "floor")
        {
            grounded = true;
            playerAni.SetInteger("Jump", 0);
        }
    }
    void TryWalk()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            walk = true;
            playerRigidbody2D.velocity = new Vector2(-maxSpeedX, playerRigidbody2D.velocity.y);
        }
        //右鍵
        if (Input.GetKey(KeyCode.RightArrow))
        {
            walk = true;
            playerRigidbody2D.velocity = new Vector2(maxSpeedX, playerRigidbody2D.velocity.y);
        }// 水平移動
    }
    void WalkAnimator(bool walkCheck)
    {
        if (walkCheck)
        {
            if (playerAni.GetInteger("Status") == 0)
            {
                playerAni.SetInteger("Status", 1);
            }
        }
        else
        {
            if (playerAni.GetInteger("Status") == 1)
            {
                playerAni.SetInteger("Status", 0);

            }
        }
    }
    void Jump_Down_Animator()
    {
        if (grounded == true && JumpKey)
        {
            playerRigidbody2D.AddForce(new Vector2(0, 150), ForceMode2D.Impulse);
            // playerRigidbody2D.AddForce( Vector2.up *   Force_Y ); // 往上跳的力度
            playerAni.SetInteger("Jump", 1);
            grounded = false;

        }
        if (grounded == false && speed_Y < 0)
        {
            if (playerAni.GetInteger("Jump") == 1)
            {
                playerAni.SetInteger("Down", 1);
            }

        }
        else if (grounded == true)
        {
            if (playerAni.GetInteger("Jump") == 1)
            {
                playerAni.SetInteger("Jump", 0);
                playerAni.SetInteger("Down", 0);
            }
        }
    }



    void Update()
    {

        walk = false;
        ControlSpeed();
        TryWalk();
        WalkAnimator(walk);
        Jump_Down_Animator();


    }

}