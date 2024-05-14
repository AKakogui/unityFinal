using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    public TextMeshProUGUI coinText;
    private int coinCount = 0;
    private List<GameObject> coins = new List<GameObject>();

    void Awake()
    {
        // Ensure that only one instance of CoinManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        // Subscribe to the sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // Unsubscribe from the sceneLoaded event
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Find the TMP_Text component called "coins" in the new scene
        coinText = GameObject.Find("coins").GetComponent<TextMeshProUGUI>();

        // Update the coin text to reflect the current coin count
        if (coinText != null)
        {
            coinText.text = "Coins: " + coinCount;
        }
    }

    public void AddCoin(GameObject coin)
    {
        coinCount++;
        if (coinText != null)
        {
            coinText.text = "Coins: " + coinCount;
        }
        coin.SetActive(false); // Deactivate coin
        coins.Add(coin); // Add to the list of collected coins
    }


    public int returnCoins()
    {
        return coinCount;
    }
}
