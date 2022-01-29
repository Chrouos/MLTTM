using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    //scene number
    public int sceneNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
        Time.timeScale = 1;
    }

    void OnClick(){
        SceneManager.LoadScene(sceneNum); //change scene
    } 

    // Update is called once per frame
    void Update()
    {
        
    }
}
