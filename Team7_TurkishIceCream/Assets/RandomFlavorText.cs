using UnityEngine;
using TMPro; // Required for TextMeshPro

public class RandomFlavorText : MonoBehaviour
{
    public GameObject flavorTextPrefab; // Assign the prefab in Unity

    private string[] flavors = { "Vanilla", "Pistachio", "Chocolate", "Strawberry", "Mango", 
                                 "Turkish Coffee", "Red Currant", "Peach", "Lemon", "Kaymak" };

    void Start()
    {
        SpawnFlavorText();
    }

    void SpawnFlavorText()
    {
        // Pick a random flavor
        string randomFlavor = flavors[Random.Range(0, flavors.Length)];
        Debug.Log("Spawning text: " + randomFlavor);

        // Instantiate the text prefab
        GameObject textObject = Instantiate(flavorTextPrefab);

        // Find the Canvas and set the instantiated object as its child
        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas != null)
        {
            textObject.transform.SetParent(canvas.transform, false);
        }
        else
        {
            Debug.LogError("No Canvas found in the scene! Make sure you have a UI Canvas.");
            return;
        }

        // Adjust position for bottom-left alignment
        RectTransform rectTransform = textObject.GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            // Set anchor to Bottom-Left
            rectTransform.anchorMin = new Vector2(0, 0);
            rectTransform.anchorMax = new Vector2(0, 0);
            rectTransform.pivot = new Vector2(0, 0); // Set pivot to bottom-left

            // Adjust position slightly inside the screen
            rectTransform.anchoredPosition = new Vector2(50, 50);
        }
        else
        {
            Debug.LogError("RectTransform component not found on instantiated prefab!");
        }

        // Set text dynamically
        TextMeshProUGUI textComponent = textObject.GetComponent<TextMeshProUGUI>();
        if (textComponent != null)
        {
            textComponent.text = "I want: " + randomFlavor;
        }
    }
}