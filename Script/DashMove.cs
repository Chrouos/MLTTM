using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMove : MonoBehaviour
{

    public Rigidbody2D rb;

    float doubleTapTime;
    KeyCode lastKeyCode;

    public float dashSpeed;
    private float dashCount;
    public float startDashCount;
    public int side;

    public float totalCoolTime = 0.7f;
    public float cdTime;

    void Start()
    {
        cdTime = -1f;
        dashCount = startDashCount;
        rb = GetComponent<Rigidbody2D>();
    }

    // Dash
    void TryDash()
    {

        if (side == 0)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (doubleTapTime > Time.time && lastKeyCode == KeyCode.A)
                {
                    side = 1;
                }
                else
                {
                    doubleTapTime = Time.time + 0.5f;
                }

                lastKeyCode = KeyCode.A;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {

                if (doubleTapTime > Time.time && lastKeyCode == KeyCode.D)
                {
                    side = 2;
                }

                else
                {
                    doubleTapTime = Time.time + 0.5f;
                }

                lastKeyCode = KeyCode.D;
            }
        }
        else
        {
            if (dashCount <= 0)
            {
                side = 0;
                dashCount = startDashCount;
                rb.velocity = Vector2.zero;
                cdTime = totalCoolTime;
            }
            else
            {
                dashCount -= Time.deltaTime;

                if (side == 1)
                {
                    Debug.Log("LEFT");
                    rb.velocity = Vector2.left * dashSpeed;
                }
                else if (side == 2)
                {

                    Debug.Log("RIGHT");
                    rb.velocity = Vector2.right * dashSpeed;
                }

            }


        }


    }


    void Update()
    {
        if (cdTime <= 0)
            TryDash();

        cdTime -= Time.deltaTime;

    }

    // public float dashSpeed;
    // private float dashTime;
    // public float startDashTime;
    // public int direction; // ��V

    // public float cloDown = 0;
    // public float cloDownTime = 3;
    // public float maxSpeedX; // 最大水平速度




    // void Update() {


    //     // �k�䬰 1
    //     if (Input.GetKeyDown(KeyCode.D))
    //         direction = 1;
    //     // ���䬰 2
    //     if (Input.GetKeyDown(KeyCode.A))
    //         direction = 2;


    //     if (dashTime <= 0) {
    //         dashTime = startDashTime;
    //         playerRigidbody2D.velocity = Vector2.zero;
    //     }
    //     else {
    //         dashTime -= Time.deltaTime;
    //         cloDown -= Time.deltaTime;
    //         if (direction == 1 && Input.GetKeyDown(KeyCode.J) && cloDown <= 0) {
    //             //playerRigidbody2D.velocity += Vector2.right * dashSpeed;
    //             playerRigidbody2D.velocity = new Vector2(maxSpeedX, playerRigidbody2D.velocity.x);
    //             // playerRigidbody2D.AddForce(Vector2.right * dashSpeed);
    //             cloDown = cloDownTime; // �N�o�ɶ�
    //         }
    //         else if (direction == 2 && Input.GetKeyDown(KeyCode.J) && cloDown <= 0) {
    //             //playerRigidbody2D.velocity += Vector2.left * dashSpeed;
    //             playerRigidbody2D.velocity = new Vector2(-maxSpeedX, playerRigidbody2D.velocity.x);
    //             // playerRigidbody2D.AddForce(Vector2.left * dashSpeed);
    //             cloDown = cloDownTime; // �N�o�ɶ�
    //         }
    //     }

    // }
}
