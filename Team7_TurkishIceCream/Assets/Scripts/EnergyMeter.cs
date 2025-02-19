using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnergySquareGame : MonoBehaviour
{
    public GameObject cursor;
    public GameObject positionParent;
    private Transform[] positions;
    private SpriteRenderer[] squareRenderers;

    private int targetIndex;
    private float timer;
    private bool isRoundActive;

    public float timeLimit = 5f;
    public float energyIncrease = 5f;
    private float energy = 50f; 

    private float minThreshold = 50f;
    private float maxThreshold = 100f;
    private float thresholdChange = 5f;
    private float targetMin = 70f;
    private float targetMax = 80f;

    public Image happyFace;
    public Image straightFace;
    public Image sadFace;
    public TMP_Text energyText;

    void Start()
    {
        InitializeSquares();
        UpdateEnergyUI();
        StartNewRound();
        StartCoroutine(AdjustThreshold());
    }

    void Update()
    {
        if (isRoundActive)
        {
            timer -= Time.deltaTime;

            if (IsCursorOnTarget() && Input.GetKeyDown(KeyCode.Return))
            {
                OnCorrectSelection();
            }

            if (timer <= 0)
            {
                StartNewRound();
            }
        }
    }

    void InitializeSquares()
    {
        Transform[] allTransforms = positionParent.GetComponentsInChildren<Transform>();
        positions = new Transform[allTransforms.Length - 1];
        squareRenderers = new SpriteRenderer[positions.Length];

        for (int i = 1; i < allTransforms.Length; i++)
        {
            positions[i - 1] = allTransforms[i];
            squareRenderers[i - 1] = positions[i - 1].GetComponent<SpriteRenderer>();
        }
    }

    bool IsCursorOnTarget()
    {
        return Vector3.Distance(cursor.transform.position, positions[targetIndex].position) < 0.1f;
    }

    void OnCorrectSelection()
    {
        ResetSquares(); // **First, reset all squares to white before adjusting energy.**
        energy = Mathf.Clamp(energy + energyIncrease, 0, 100); // **Now adjust energy after color reset**
        UpdateEnergyUI();
        StartNewRound();
    }

    void StartNewRound()
    {
        isRoundActive = false;
        Invoke(nameof(SelectNewTarget), 0.1f); // Ensure color reset is processed before selecting a new target
    }

    void SelectNewTarget()
    {
        targetIndex = Random.Range(0, positions.Length);
        squareRenderers[targetIndex].color = new Color(1f, 0.5f, 0f); // Set new target square to orange
        timer = timeLimit;
        isRoundActive = true;
    }

    void ResetSquares()
    {
        foreach (SpriteRenderer square in squareRenderers)
        {
            if (square != null)
            {
                square.color = Color.white; // **Ensure all squares reset before anything else**
            }
        }
    }

    IEnumerator AdjustThreshold()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);

            if (minThreshold < targetMin)
                minThreshold += thresholdChange;

            if (maxThreshold > targetMax)
                maxThreshold -= thresholdChange;

            minThreshold = Mathf.Clamp(minThreshold, 50f, targetMin);
            maxThreshold = Mathf.Clamp(maxThreshold, targetMax, 100f);

            UpdateEnergyUI();
        }
    }

    void UpdateEnergyUI()
    {
        if (energyText != null)
        {
            energyText.text = $"Energy: {energy:F0} | Threshold: {minThreshold:F0} - {maxThreshold:F0}";
        }

        if (energy > maxThreshold)
        {
            happyFace.gameObject.SetActive(false);
            straightFace.gameObject.SetActive(false);
            sadFace.gameObject.SetActive(true);
        }
        else if (energy >= minThreshold)
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
}
