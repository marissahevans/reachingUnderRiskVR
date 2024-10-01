using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class handPosCheck : MonoBehaviour
{
    //reference to the tracked-object component on the controller/HMD GameObject
    public SteamVR_Behaviour_Pose pose; //initialized via inspector to a pose action
    public Vector3 velocity;
    public float distanceThreshold = .1F;
    public float velocityThreshold = .1F;
    private Vector3 startPosition;
    private Vector3 lastPosition;
    public rewardVisuals otherscript;

    void Start()
    {
        startPosition = pose.transform.position;
        lastPosition = startPosition;
    }
    // Update is called once per frame
    void Update()
    {
        //velocity = pose.GetVelocity();
        //Debug.Log($"Velocity : {velocity}");
        
        // distance travelled
        float distanceTravelled = Vector3.Distance(startPosition, pose.transform.position);

        // current velocity
        float currentVelocity = Vector3.Distance(pose.transform.position, lastPosition) / Time.deltaTime;
        
        if (distanceTravelled > distanceThreshold && currentVelocity < velocityThreshold)
        {
                Vector3 currentPos = pose.transform.position;
                GameManager.Instance.ReachEndpt = new Vector3(currentPos[0], currentPos[1], currentPos[2]);
                otherscript.performReward();
                //SceneManager.LoadScene("StartingRoom");
        }

        lastPosition = pose.transform.position;
    }

   // public Vector3 GetVelocity()
   // {
   //     return velocity;
   // }
}
