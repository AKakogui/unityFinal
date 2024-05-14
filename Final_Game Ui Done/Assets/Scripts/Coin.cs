using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] AudioSource soundSource;
    [SerializeField] AudioClip coinSound;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            soundSource.PlayOneShot(coinSound);
            CoinManager.instance.AddCoin(gameObject); 
            
        }
    }
}
