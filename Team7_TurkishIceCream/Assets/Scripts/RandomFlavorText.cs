using UnityEngine;
using TMPro; // Required for TextMeshPro

public class RandomFlavorText : MonoBehaviour
{
    GameHandler myGH;
    public GameObject flavorText;

    private string[] flavors = { "Vanilla", "Chocolate", "Strawberry", "Turkish Coffee", "Lemon", "Kaymak" };
    private string[] flavorKey = { "V", "C", "S", "TC", "L", "K"};
                                 
    void Start()
    {
        myGH = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        SpawnFlavorText();
    }

    void SpawnFlavorText()
    {
        int i = Random.Range(0, flavors.Length);
        myGH.flavorChosen = flavorKey[i];
        string randomisedFlavor = flavors[i];
        TextMeshProUGUI textComp = flavorText.GetComponent<TextMeshProUGUI>();
        if (textComp != null)
        {
            textComp.text = "I want: " + randomisedFlavor;
        }
    }
}
