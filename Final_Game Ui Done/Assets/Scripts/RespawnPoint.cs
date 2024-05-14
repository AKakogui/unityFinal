using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerDeath playerDeath = other.gameObject.GetComponent<PlayerDeath>();
            if (playerDeath != null)
            {
                playerDeath.SetRespawnPoint(transform);
            }
        }
    }
}