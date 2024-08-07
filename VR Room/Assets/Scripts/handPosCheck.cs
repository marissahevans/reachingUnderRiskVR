using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class handPosCheck : MonoBehaviour
{
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPos = transform.position;
        
        float deltaX = currentPos[0] - startPos[0];
        float deltaY = currentPos[1] - startPos[1];
        float deltaZ = currentPos[2] - startPos[2];
        float velocity = (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);

        if (velocity < 1)
        {
            GameManager.Instance.ReachEndpt = new Vector3(currentPos[0], currentPos[1], currentPos[2]);
            SceneManager.LoadScene("StartingRoom"); 
        }
        else
        {
            startPos = currentPos;
        }
        
    }
    
}
