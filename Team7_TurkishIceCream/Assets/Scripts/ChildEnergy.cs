using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildEnergy : MonoBehaviour
{
    GameHandler myGameHandler;
    // Start is called before the first frame update
    void Start()
    {
        myGameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
    }
    
}
