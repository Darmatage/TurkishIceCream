using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ViewSwitch : MonoBehaviour
{
    GameHandler myGameHandler;
    // Start is called before the first frame update
    void Start()
    {
        myGameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
    }    
    void Update()
    {
        if(Input.GetMouseButtonDown(1)) {
            LoadNewView();
        }
    }

    public void LoadNewView() {
        if(myGameHandler.sceneNum == 0) {
            Debug.Log("SceneNum = " + myGameHandler.sceneNum);
            myGameHandler.sceneNum = 1;
            myGameHandler.happyFace.gameObject.SetActive(false);
            myGameHandler.straightFace.gameObject.SetActive(false);
            myGameHandler.sadFace.gameObject.SetActive(false); 
            myGameHandler.flavorText.gameObject.SetActive(false);
            myGameHandler.bubble.gameObject.SetActive(false);
            myGameHandler.buttons.gameObject.SetActive(true);
        } else if (myGameHandler.sceneNum == 1) { // pick flavor
            Debug.Log("SceneNum = " + myGameHandler.sceneNum);
            myGameHandler.sceneNum = 2;
            myGameHandler.buttons.gameObject.SetActive(false);
            myGameHandler.CursorMovement.gameObject.SetActive(true);
            myGameHandler.canvas.gameObject.SetActive(false);
        } else { // do tricks 
            Debug.Log("SceneNum = " + myGameHandler.sceneNum);
            myGameHandler.sceneNum = 0;
            myGameHandler.CursorMovement.gameObject.SetActive(false);
            myGameHandler.canvas.gameObject.SetActive(true);
            myGameHandler.flavorText.gameObject.SetActive(true);
            myGameHandler.bubble.gameObject.SetActive(true);
            myGameHandler.updateFaceDisplay();
        }
    }
}