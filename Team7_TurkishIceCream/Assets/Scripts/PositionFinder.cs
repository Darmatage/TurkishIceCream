using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PositionFinder : MonoBehaviour
{
    GameHandler myGameHandler;
    public GameObject cursor;
    public GameObject positionParent;
    // Start is called before the first frame update
    void Start()
    {
        myGameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
    }
}
