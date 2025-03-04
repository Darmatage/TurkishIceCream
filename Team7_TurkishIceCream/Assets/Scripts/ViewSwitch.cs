using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ViewSwitch : MonoBehaviour
{
    GameHandler myGameHandler;
    // Start is called before the first frame update

    bool iceCreamChosen = false;

    public void Start()
    {
        myGameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        GetComponent<Button>().onClick.AddListener(LoadNewView);
    }   

    public void LoadNewView() {
        if (myGameHandler.sceneNum == 0) {
            Debug.Log("Child SceneNum = " + myGameHandler.sceneNum);
            //enter ice cream choosing view
            myGameHandler.sceneNum = (!myGameHandler.iceCreamChosen) ? 1 : 2;
            myGameHandler.happyFace.gameObject.SetActive(false);
            myGameHandler.straightFace.gameObject.SetActive(false);
            myGameHandler.sadFace.gameObject.SetActive(false); 
            myGameHandler.flavorText.gameObject.SetActive(false);
            myGameHandler.bubble.gameObject.SetActive(false);
            myGameHandler.BgBaby.gameObject.SetActive(false);
            myGameHandler.button1.gameObject.SetActive(true);
            myGameHandler.button2.gameObject.SetActive(true);
            myGameHandler.button3.gameObject.SetActive(true);
            myGameHandler.button4.gameObject.SetActive(true);
            myGameHandler.button5.gameObject.SetActive(true);
            myGameHandler.button6.gameObject.SetActive(true);
            myGameHandler.BgIceCream.gameObject.SetActive(true);
            myGameHandler.switchButton.gameObject.SetActive(false);
            myGameHandler.BgTrick.gameObject.SetActive(false);
            myGameHandler.panel.SetActive(true);
        } else if (myGameHandler.iceCreamChosen == false) { // pick flavor
            myGameHandler.sceneNum = 2;
            myGameHandler.button1.gameObject.SetActive(false);
            myGameHandler.button2.gameObject.SetActive(false);
            myGameHandler.button3.gameObject.SetActive(false);
            myGameHandler.button4.gameObject.SetActive(false);
            myGameHandler.button5.gameObject.SetActive(false);
            myGameHandler.button6.gameObject.SetActive(false);
            myGameHandler.BgIceCream.gameObject.SetActive(false);
            myGameHandler.switchButton.gameObject.SetActive(true);
            myGameHandler.panel.SetActive(true);
            myGameHandler.CursorMovement.gameObject.SetActive(true);
            myGameHandler.BgTrick.gameObject.SetActive(true);
            myGameHandler.canvas.gameObject.SetActive(false);
            myGameHandler.iceCreamChosen = true;
        } else { // do tricks
            Debug.Log("tricks SceneNum = " + myGameHandler.sceneNum);
            myGameHandler.sceneNum = 0;
            myGameHandler.canvas.gameObject.SetActive(true);
            myGameHandler.CursorMovement.gameObject.SetActive(false);
            myGameHandler.BgTrick.gameObject.SetActive(false);
            myGameHandler.BgBaby.gameObject.SetActive(true);
            myGameHandler.flavorText.gameObject.SetActive(true);
            myGameHandler.switchButton.gameObject.SetActive(true);
            myGameHandler.bubble.gameObject.SetActive(true);
            myGameHandler.panel.SetActive(true);
            myGameHandler.updateFaceDisplay();
            myGameHandler.iceCreamChosen = true;
        }
    }
}