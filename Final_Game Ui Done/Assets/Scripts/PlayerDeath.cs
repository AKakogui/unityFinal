using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private Transform respawnPoint;
    private Vector3 initialPosition;
    [SerializeField] GameObject boolman;
    [SerializeField] AudioSource soundSource;
    [SerializeField] AudioClip deathSound;
    
    void Start()
    {
        initialPosition = transform.position;
    }
    public void SetRespawnPoint(Transform newRespawnPoint)
    {
        respawnPoint = newRespawnPoint;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            
            Respawn();
            Debug.Log("Player Died");
            boolman.GetComponent<FollowCam>().checker = true;
            soundSource.PlayOneShot(deathSound);
        }
    }

    private void Respawn()
    {
        if (respawnPoint != null)
        {
            transform.position = respawnPoint.position;
            
        }
        else
        {
            transform.position = initialPosition;
        }

        

    }
}



