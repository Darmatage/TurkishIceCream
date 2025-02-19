using UnityEngine;
using TMPro; // Required for TextMeshPro

public class RandomFlavorText : MonoBehaviour
{
    public GameObject flavorText;
    GameHandler myGameHandler;

    private string[] flavors = { "Vanilla", "Chocolate", "Strawberry",
                                 "Turkish Coffee", "Lemon", "Kaymak" };
    private string[] flavorTag = { "V", "C", "S",
                                 "TC", "L", "K"};
                                 

    void Start()
    {
        myGameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        SpawnFlavorText();
    }

    void SpawnFlavorText()
    {
        // Pick a random flavor
        int index = Random.Range(0, flavors.Length);
        myGameHandler.flavorChosen = flavorTag[index];
        string randomFlavor = flavors[index];
        Debug.Log("Spawning text: " + randomFlavor);
        // Set text dynamically
        TextMeshProUGUI textComponent = flavorText.GetComponent<TextMeshProUGUI>();
        if (textComponent != null)
        {
            textComponent.text = "I want: " + randomFlavor;
        }
    }
}