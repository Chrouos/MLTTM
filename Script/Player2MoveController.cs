using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2MoveController : MonoBehaviour
{

    public Animator playerAni;

    // �t��
    public float horizontalDirection; // ������V
    public float speed_X = 5f; // �������ʪ��t��
    private float speed_Y; // �ثe�����t��

    public float maxSpeedX; // �̤j�����t��

    [Range(0, 150)]
    public float Force_X; // �������O
    public float Force_Y = 5; // ���W�����O��

    // ���⪫�z
    Rigidbody2D playerRigidbody2D;

    // ���A�T�{
    [Range(0, 0.5f)]
    public float distance; // �P���a�O���Z��
    public Transform groundCheck; // �����a�O���g�u�_�I
    public LayerMask groundLayer; // �a�O���ϼh
    public bool grounded; // �O�_�b�a���W
    bool walk = false;

    void Start()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }


    // �� W �N�i�H���W���A�T�{�O�_���F W 
    public bool JumpKey
    {
        get
        {
            return Input.GetKeyDown(KeyCode.UpArrow);
        }
    }
    // ��t�ʱ���
    public void ControlSpeed()
    {
        speed_X = playerRigidbody2D.velocity.x;
        speed_Y = playerRigidbody2D.velocity.y;
        float newSpeedX = Mathf.Clamp(speed_X, -maxSpeedX, maxSpeedX);
        playerRigidbody2D.velocity = new Vector2(newSpeedX, speed_Y);
    }
    // �O�_�b�a���W
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
        //�k��
        if (Input.GetKey(KeyCode.RightArrow))
        {
            walk = true;
            playerRigidbody2D.velocity = new Vector2(maxSpeedX, playerRigidbody2D.velocity.y);
        }// ��������
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
            // playerRigidbody2D.AddForce( Vector2.up *   Force_Y ); // ���W�����O��
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