using UnityEngine;
using TMPro;

public class DisplayFinalCoin : MonoBehaviour
{
    public TextMeshProUGUI finalCoinText;

    void Start()
    {
        // Load the final coin count from PlayerPrefs
        int finalCoinCount = PlayerPrefs.GetInt("CoinCount", 0);

        // Display the final coin count
        finalCoinText.text = "Final Coins: " + finalCoinCount;
    }
}
