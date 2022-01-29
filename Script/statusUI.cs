using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class statusUI : MonoBehaviour
{

    public Text popUpMessage;
    float TimeGet;
    // Start is called before the first frame update
    void Start()
    {   
        popUpMessage.text = "FIGHT!";
        Invoke("ClearMessage", 1);
        //GameObject.Find("Player").GetComponent<Player1MoveController>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*TimeGet += Time.deltaTime;
        while((int)TimeGet == 2)
        {
            GameObject.Find("Player").GetComponent<Player1MoveController>().enabled = true;
        }
        Debug.Log(TimeGet);*/
    }

    void ClearMessage()
    {
        popUpMessage.text = "";
    }
}
