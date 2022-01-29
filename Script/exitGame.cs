using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class exitGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
