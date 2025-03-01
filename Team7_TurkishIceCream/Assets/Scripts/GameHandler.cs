using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    private GameObject child;
    public static int childEnergy = 50;
    public int startChildEnergy = 50;
    public Image happyFace;
    public Image straightFace;
    public Image sadFace;
    public Image bubble; 
    public GameObject flavorText;
    private string SceneName;
    private float minThreshold = 50f;
    private float maxThreshold = 100f;
    private float thresholdChange = 5f;
    private float targetMin = 70f;
    private float targetMax = 80f;
    public int sceneNum;
    public string flavorChosen; 
    public Button button1; 
    public Button button2; 
    public Button button3; 
    public Button button4; 
    public Button button5; 
    public Button button6;
    public Button switchButton;
    public GameObject panel;
    public GameObject CursorMovement;
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        child = GameObject.FindWithTag("Child");
        SceneName = SceneManager.GetActiveScene().name;
        //if (sceneName=="MainMenu"){ //uncomment these two lines when the MainMenu exists
                  childEnergy = startChildEnergy;
        //}
        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);
        button3.gameObject.SetActive(false);
        button4.gameObject.SetActive(false);
        button5.gameObject.SetActive(false);
        button6.gameObject.SetActive(false);
        CursorMovement.gameObject.SetActive(false);
        switchButton.gameObject.SetActive(true);
        updateFaceDisplay();
        sceneNum = 0;
        StartCoroutine(AdjustThreshold());
    }

    public void energyChange(int newEnergy) 
    {
        childEnergy += newEnergy;
        updateFaceDisplay();
    }

    public void updateFaceDisplay() 
    {
        if (childEnergy > maxThreshold)
        {
            happyFace.gameObject.SetActive(false);
            straightFace.gameObject.SetActive(false);
            sadFace.gameObject.SetActive(true);
        }
        else if (childEnergy >= minThreshold)
        {
            happyFace.gameObject.SetActive(true);
            straightFace.gameObject.SetActive(false);
            sadFace.gameObject.SetActive(false);
        }
        else
        {
            happyFace.gameObject.SetActive(false);
            straightFace.gameObject.SetActive(true);
            sadFace.gameObject.SetActive(false);
        }
    }
    IEnumerator AdjustThreshold()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            if (childEnergy < minThreshold) {
                SceneManager.LoadScene("EndLose");
            } else if (childEnergy > maxThreshold) {
                SceneManager.LoadScene("EndLose");
            }

            if (minThreshold < targetMin)
                minThreshold += thresholdChange;
            else 
                SceneManager.LoadScene("EndWin");

            if (maxThreshold > targetMax)
                maxThreshold -= thresholdChange;

            minThreshold = Mathf.Clamp(minThreshold, 50f, targetMin);
            maxThreshold = Mathf.Clamp(maxThreshold, targetMax, 100f);

            Debug.Log("Energy: " + childEnergy);
            Debug.Log("Threshold: " + minThreshold + " : " + maxThreshold);
            if (sceneNum == 0) {
                updateFaceDisplay();
            }
        }
    }

    public void CheckTagMatch(string buttonTag)
    {
        if (buttonTag == flavorChosen)
        {
            sceneNum = 1;
            button1.gameObject.SetActive(false);
            button2.gameObject.SetActive(false);
            button3.gameObject.SetActive(false);
            button4.gameObject.SetActive(false);
            button5.gameObject.SetActive(false);
            button6.gameObject.SetActive(false);
            switchButton.gameObject.SetActive(true);
            CursorMovement.gameObject.SetActive(true);
            canvas.gameObject.SetActive(true);
            panel.gameObject.SetActive(true);
            Debug.Log("Correct Flavor");
        }
        else
        {
            SceneManager.LoadScene("EndLose");
        }
    }

    public void StartGame() 
    {
        SceneManager.LoadScene("CombinedScene");
    }
    public void QuitGame() 
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
