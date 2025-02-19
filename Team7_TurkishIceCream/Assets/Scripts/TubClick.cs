using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 


public class TubClick : MonoBehaviour
{
    GameHandler myGameHandler;
    // Start is called before the first frame update
    void Start()
    {
        myGameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        GetComponent<Button>().onClick.AddListener(CheckButtonTag);
    }    

    public void CheckButtonTag()
    {
        string buttonTag = gameObject.tag; // Get the button's tag

        if (myGameHandler != null)
        {
            myGameHandler.CheckTagMatch(buttonTag); // Send the tag to GameHandler
        }
        else
        {
            Debug.LogWarning("GameHandler not found!");
        }
    }
}
