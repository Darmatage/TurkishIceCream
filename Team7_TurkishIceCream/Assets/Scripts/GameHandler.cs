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
    public int sceneNum;
    public string flavorChosen;
    public bool iceCreamChosen;
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
    public GameObject BgIceCream;
    public GameObject BgBaby;
    public GameObject BgTrick;
    public GameObject positionParent;
    public GameObject[] positions;
    public int[] energyChanges;
    public GameObject cursor;

    public Slider energyMeter;
    public Image fillMeter;

    private Color greenColor = Color.green;
    private Color orangeColor = new Color(1f, 0.5f, 0f);
    private Color redColor = Color.red;

    private bool timerGoing;
    private float timer;
    public float finalScore;

    // Start is called before the first frame update
    void Start()
    {
        timerGoing = true;
        iceCreamChosen = false;
        timer = 0f;
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
        BgIceCream.gameObject.SetActive(false);
        BgTrick.gameObject.SetActive(false);
        CursorMovement.gameObject.SetActive(false);
        switchButton.gameObject.SetActive(true);
        updateFaceDisplay();
        updateEnergyMeter();
        timerStartAndStop();
        sceneNum = 0;
        Transform[] poss = positionParent.GetComponentsInChildren<Transform>();
        energyChanges = new int[poss.Length-1];
        Debug.Log(energyChanges.Length);

        for (int i = 0; i < poss.Length-1; i++)
        {
            energyChanges[i] = poss[i+1].gameObject.GetComponent<EnergyValue>().energy;
            Debug.Log(energyChanges[i]);
        }
        StartCoroutine(AdjustThreshold());
    
    }

    void Update() 
    {
        if (timerGoing)
        {
            timer += Time.deltaTime;
        }
        updateEnergyMeter();
        if (CursorMovement.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                int curr = cursor.GetComponent<CursorMovement>().currentLocation - 1;
                Debug.Log("Old child energy:" + childEnergy);
                energyChange(energyChanges[curr]);
                Debug.Log("Change in energy:" + energyChanges[curr]);
                Debug.Log("New child energy:" + childEnergy);

            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.LogWarning("end game");
                endGame();
            }
        }

    }

    public void energyChange(int newEnergy) 
    {
        childEnergy += newEnergy;
        childEnergy = Mathf.Clamp(childEnergy, 0, 100);
        //updateFaceDisplay();
        //updateEnergyMeter();
        timerStartAndStop();
    }

    void timerStartAndStop()
    {
        if (childEnergy > maxThreshold)
        {
            timerGoing = false; // Overstimulated
        }
        else if (childEnergy >= minThreshold)
        {
            timerGoing = true; // Normal range
        }
        else
        {
            timerGoing = false; // Bored state
        }
    }

     void updateEnergyMeter()
    {
        if (energyMeter != null)
        {
            energyMeter.value = childEnergy;
        }

        if (childEnergy > maxThreshold) {
            fillMeter.color = redColor; // Overstimulated
        } 
        else if (childEnergy >= minThreshold) {
            fillMeter.color = greenColor; // Normal range
        } 
        else {
            fillMeter.color = orangeColor; // Bored state
        }
        
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
            endGame();

            if (minThreshold < 75)
                minThreshold += thresholdChange;

            if (maxThreshold > 75)
                maxThreshold -= thresholdChange;

            minThreshold = Mathf.Clamp(minThreshold, 50f, 75);
            maxThreshold = Mathf.Clamp(maxThreshold, 75, 100f);

            Debug.Log("Energy: " + childEnergy);
            Debug.Log("Threshold: " + minThreshold + " : " + maxThreshold);
            if (sceneNum == 0) {
                updateFaceDisplay();
                
            }
        }
    }

    private void endGame()
    {
        if (childEnergy < minThreshold) {
            SceneManager.LoadScene("EndLose");
            finalScore = timer / 100;
        } else if (childEnergy > maxThreshold) {
            SceneManager.LoadScene("EndLose");
            finalScore = timer / 100;
        }

        if (minThreshold == 75 && maxThreshold == 75)
        {
            SceneManager.LoadScene("EndWin");
            finalScore = timer / 100;
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
            BgTrick.gameObject.SetActive(true);
            BgIceCream.gameObject.SetActive(false);
            switchButton.gameObject.SetActive(true);
            CursorMovement.gameObject.SetActive(true);
            canvas.gameObject.SetActive(true);
            panel.gameObject.SetActive(true);
            iceCreamChosen = true;
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
