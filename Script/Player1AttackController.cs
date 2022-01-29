using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1AttackController : MonoBehaviour
{

    // 角色動畫 
    public Animator PlayerAni;
    // public Transform bulletPrefab;
    // 攻擊
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public AudioSource play;

    public int HP = 200;//初始血量
    public RectTransform HP_Bar;//血條
    public Text message;
    public GameObject GameOverWindow;
    public Button exitButton;

    public float totalCoolTime = 0.7f;
    public float cdTime = 0f;


    private void Start() {
        GameOverWindow.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && cdTime <= 0)
        {
            // Physics.IgnoreCollision(player1, player2);
            //  var bullet = Instantiate(bulletPrefab) as Transform;
            //  Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            cdTime = totalCoolTime;
            Attack();
            play.Play();
        }

        cdTime -= Time.deltaTime; // 減少冷卻

        if(HP <= 0)
        {
            HP = 0;
            message.text = "K.O!";

            GameOverWindow.gameObject.SetActive(true);
            exitButton.onClick.AddListener(exitGame);
            Time.timeScale = 0;
        }
        else
        {
            GameOverWindow.gameObject.SetActive(false);
        }

    }

    void Attack()
    {

        // Play an attack animation
        PlayerAni.SetTrigger("Attack_Normal");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("we hit " + enemy.name);

            HP -= Random.Range(10,25);
            HP_Bar.sizeDelta = new Vector2(HP, HP_Bar.sizeDelta.y);

        }
    }

    void OnDrawGizmosSelected()
    {

        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);

    }

    void exitGame()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

}
