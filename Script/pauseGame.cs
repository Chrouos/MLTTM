using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseGame : MonoBehaviour
{
    public Button PauseButton;
    public Button ResumeButton;
    public GameObject PauseWindow;

    public Button InsButton;
    public GameObject InsWindow;
    public Button backButton;
    //private bool isPause;

    // Start is called before the first frame update
    void Start()
    {
        //isPause = false;
        PauseWindow.gameObject.SetActive(false);
        InsWindow.gameObject.SetActive(false);
        PauseButton.onClick.AddListener(PauseGame);
        Time.timeScale = 1;
    }

    void PauseGame()
    {
        //isPause = true;

        PauseWindow.gameObject.SetActive(true);
        InsWindow.gameObject.SetActive(false);
        Time.timeScale = 0;

        ResumeButton.onClick.AddListener(ResumeGame);
        InsButton.onClick.AddListener(InsWindows);
    }

    void ResumeGame()
    {
        //isPause = false;

        PauseWindow.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    void InsWindows()
    {
        //isPause = true;

        PauseWindow.gameObject.SetActive(false);
        InsWindow.gameObject.SetActive(true);
        Time.timeScale = 0;

        backButton.onClick.AddListener(PauseGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
