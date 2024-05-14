using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FollowCam : MonoBehaviour
{

    public float camSpeed = 1f;
    public float currentPos = 0f;
    [SerializeField] public Transform target;
    public bool checker = false;
    
    void LateUpdate()
    {   
        if (checker)
        {
            currentPos = target.position.x + 6;
            checker = false;
        }
        
        currentPos += camSpeed * Time.deltaTime;
        Vector3 slowRight = new Vector3(currentPos, 0, -10);
        transform.position = slowRight;
        
    }

}