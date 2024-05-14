using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finishPlatform : MonoBehaviour
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
            SceneManager.LoadScene(scene);
            Debug.Log("Next Level");
        }
    }


}
