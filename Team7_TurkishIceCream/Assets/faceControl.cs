using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnergyMeter : MonoBehaviour
{
    public Image happyFace;
    public Image straightFace;
    public Image sadFace;

    private float energy = 50f; // Initial energy set to 50
    private float threshold = 50f; // Initial threshold

    public Button increaseButton; // Button to increase energy
    public Button decreaseButton; // Button to decrease energy

    public float energyChange = 5f; // Amount by which energy changes when buttons are pressed

    // Text elements to display energy and threshold values
    public TMP_Text energyText;
    public TMP_Text thresholdText; 

    private float thresholdChange = 5f;  // Amount to adjust threshold per update
    private float updateInterval = 5f;   // Adjust threshold every 5 seconds
    private float minThreshold = 50f;    // Starting lower threshold
    private float maxThreshold = 100f;   // Starting upper threshold
    private float targetMin = 70f;       // Target lower limit
    private float targetMax = 80f;       // Target upper limit

    void Start()
    {
        // Set initial face based on energy
        UpdateChildFace();

        // Hook up button listeners
        increaseButton.onClick.AddListener(OnIncreaseEnergy);
        decreaseButton.onClick.AddListener(OnDecreaseEnergy);

        // Start modifying the threshold every 5 seconds
        InvokeRepeating(nameof(AdjustThreshold), updateInterval, updateInterval);
    }

    void Update()
    {
        // Update child's face based on energy
        UpdateChildFace();

        // Update the displayed text for energy and threshold
        UpdateUI();
    }

    void OnIncreaseEnergy()
    {
        energy += energyChange;
        energy = Mathf.Clamp(energy, 0f, 100f); // Ensure energy stays within 0 to 100 range
    }

    void OnDecreaseEnergy()
    {
        energy -= energyChange;
        energy = Mathf.Clamp(energy, 0f, 100f); // Ensure energy stays within 0 to 100 range
    }

    // Update the child's face based on current energy
    void UpdateChildFace()
    {
        if (energy > maxThreshold) // If energy is greater than the max threshold, sad face
        {
            sadFace.gameObject.SetActive(true);
            happyFace.gameObject.SetActive(false);
            straightFace.gameObject.SetActive(false);
        }
        else if (energy >= minThreshold && energy <= maxThreshold) // If within the threshold range, happy face
        {
            happyFace.gameObject.SetActive(true);
            sadFace.gameObject.SetActive(false);
            straightFace.gameObject.SetActive(false);
        }
        else // If energy is below the min threshold, straight face
        {
            straightFace.gameObject.SetActive(true);
            happyFace.gameObject.SetActive(false);
            sadFace.gameObject.SetActive(false);
        }
    }

    // Update the UI Text components with current energy and threshold values
    void UpdateUI()
    {
        energyText.text = "Energy: " + energy.ToString("F0"); // Display energy (formatted to no decimals)
        thresholdText.text = "Threshold: " + minThreshold.ToString("F0") + " - " + maxThreshold.ToString("F0"); // Display the changing threshold range
    }

    // Gradually adjust the threshold until it falls within 70-80
    void AdjustThreshold()
    {
        // Increase low end until it reaches 70
        if (minThreshold < targetMin)
        {
            minThreshold += thresholdChange;
        }

        // Decrease high end until it reaches 80
        if (maxThreshold > targetMax)
        {
            maxThreshold -= thresholdChange;
        }

        // Clamp values to ensure they don't go beyond limits
        minThreshold = Mathf.Clamp(minThreshold, 50f, targetMin);
        maxThreshold = Mathf.Clamp(maxThreshold, targetMax, 100f);

        UpdateUI(); // Update the threshold text in the UI
    }
}
