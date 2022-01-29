using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{
    public int HP = 200;
    public RectTransform HP_Bar;//¦å±ø
    public Text message;
    public GameObject GameOverWindow;
    public Button exitButton;


    // Start is called before the first frame update
    void Start()
    {
        HP = 200;
    }

    public void TakeDamage()
    {
        HP -= Random.Range(10, 25);
        HP_Bar.sizeDelta = new Vector2(HP, HP_Bar.sizeDelta.y);


        
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0) {
            HP = 0;
            message.text = "K.O!";

            GameOverWindow.gameObject.SetActive(true);
            exitButton.onClick.AddListener(exitGame);
            Time.timeScale = 0;
        }
        else {
            GameOverWindow.gameObject.SetActive(false);
        }
    }

    void exitGame()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
