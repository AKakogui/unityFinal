using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalPlaformEnd : MonoBehaviour
{

    private BoxCollider2D finishZone;
    [SerializeField] public string scene;


    // Start is called before the first frame update
    void Start()
    {
        finishZone = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {

            if (TimerManager.instance != null)
            {
                TimerManager.instance.StopTimer();
                float finalTime = TimerManager.instance.GetElapsedTime();
                PlayerPrefs.SetFloat("FinalTime", finalTime);
                PlayerPrefs.Save();
                Destroy(TimerManager.instance.gameObject);

            }
            if(CoinManager.instance !=null)
            {
                int finalCoins = CoinManager.instance.returnCoins();
                PlayerPrefs.SetInt("CoinCount", finalCoins);
                PlayerPrefs.Save();
                Destroy(CoinManager.instance.gameObject);
            }
            SceneManager.LoadScene(scene);
            Debug.Log("Next Level");
        }
    }


}