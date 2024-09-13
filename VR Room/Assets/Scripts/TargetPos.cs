using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TargetPos : MonoBehaviour
{
    public Bounds penBound;
    // Start is called before the first frame update
    void Start()
    {
        // Adding the target spheres
        List<float> tarLocY = new List<float>();
        tarLocY.Add(.6F);
        tarLocY.Add(1);
        tarLocY.Add(1.4F);
        
        List<float> tarLocZ = new List<float>();
        tarLocZ.Add(.5F);
        tarLocZ.Add(0);
        tarLocZ.Add(-.5F);

        transform.position = new Vector3(
            -1.8F,
            tarLocY[Random.Range(0, tarLocY.Count)],
            tarLocZ[Random.Range(0, tarLocZ.Count)]);
        GameManager.Instance.TarPos = new Vector3(transform.position[0], transform.position[1], transform.position[2]);
        Debug.Log("target script" + GameManager.Instance.TarPos);
        
        //create field of dots for target
        int size = 100;     //Number of objects
        GameObject[] dots = new GameObject[size];
            //Loop for the entire size of the array
        for (int i = 0; i < size; i++)
        {
            //Create the game object
            dots[i] = GameObject.Instantiate (Resources.Load ("SphereTarget")) as GameObject;  

            //Position it in the scene
            dots[i].transform.position = (Random.insideUnitSphere * .05F) + GameManager.Instance.TarPos;
        }
        // Start adding penalty spheres
        int blockNum = GameManager.Instance.Block;
        int penDir = GameManager.Instance.penMode[blockNum];
        Debug.Log("block = "+ blockNum);
        Debug.Log("direction = "+ penDir);
        Debug.Log(GameManager.Instance.penMode);
        float shift;
        int penSide = Random.Range(-1, 1);
        
        // calculate the amount of shift away from the target sphere
        if (penSide >= 0)
        {
            shift = .08F;
        }
        else
        {
            shift = -.08F;
        }

        // calculate the bounds for the penalty zone to be used later
        if (penDir == 1)
        {
            Bounds penBound = new Bounds(GameManager.Instance.TarPos + new Vector3(shift,0,0), new Vector3(.1F, 2, 2));
            GameManager.Instance.PenaltyPos = penBound;
        }
        if (penDir == 2)
        {
            Bounds penBound = new Bounds(GameManager.Instance.TarPos + new Vector3(0,shift,0), new Vector3(1, .1F, 2));
            GameManager.Instance.PenaltyPos = penBound;
        }
        if (penDir == 3)
        {
            Bounds penBound = new Bounds(GameManager.Instance.TarPos + new Vector3(0,0,shift), new Vector3(1, 2, .1F));
            GameManager.Instance.PenaltyPos = penBound;
        }
        
        Debug.Log(GameManager.Instance.PenaltyPos);
        Debug.Log(GameManager.Instance.TarPos);

        //create field of dots for target
        int size2 = 10000;     //Number of objects
        GameObject[] dots2 = new GameObject[size2];
        
        //Loop for the entire size of the array
        for (int i = 0; i < size2; i++)
        {
            //Create the game object
            dots2[i] = GameObject.Instantiate (Resources.Load ("SpherePenalty")) as GameObject;
            
            if (penDir == 1)
            {
                //Position it in the scene
                dots2[i].transform.position = new Vector3(Random.Range(-0.05F,0.05F)+shift,Random.Range(-1.0F,1.0F),Random.Range(-1.0F,1.0F)) + GameManager.Instance.TarPos; 
            }

            if (penDir == 2)
            {
                //Position it in the scene
                dots2[i].transform.position = new Vector3(Random.Range(-0.5F,0.5F),Random.Range(-0.05F,0.05F)+shift,Random.Range(-1.0F,1.0F)) + GameManager.Instance.TarPos;
            }

            if (penDir == 3)
            {
                //Position it in the scene
                dots2[i].transform.position = new Vector3(Random.Range(-0.5F,0.5F),Random.Range(-1.0F,1.0F),Random.Range(-0.05F,0.05F)+shift) + GameManager.Instance.TarPos; 
            }
        }
    }
}
