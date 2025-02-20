using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameHandlerButtons : MonoBehaviour{

        public static int playerStat1;
        // public GameObject textGameObject;

        // void Start () { UpdateScore (); }

        void Update(){
        }

        // void UpdateScore () {
        //        Text scoreTemp = textGameObject.GetComponent<Text>();
        //        scoreTemp.text = "Score: " + score; }

        public void StartGame(){
                SceneManager.LoadScene("CombinedScene");
        }

        public void OpenCredits(){
                SceneManager.LoadScene("Credits");
        }

        public void RestartGame(){
                SceneManager.LoadScene("StartMenu");
        }

        public void QuitGame(){
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #else
                Application.Quit();
                #endif
        }
}