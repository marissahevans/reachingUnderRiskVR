using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using Random = UnityEngine.Random;

public class penaltyPos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int blockNum = GameManager.Instance.Block;
        int penDir = GameManager.Instance.penMode[blockNum];
        Debug.Log("block = "+ blockNum);
        Debug.Log("direction = "+ penDir);
        float shift;
        int penSide = Random.Range(-1, 1);
        if (penSide >= 0)
        {
            shift = .08F;
        }
        else
        {
            shift = -.08F;
        }
        
        transform.position = new Vector3(
            -1.8F,
            1,
            GameManager.Instance.TarPos[2] + shift);
            GameManager.Instance.PenaltyPos =
                new Vector3(transform.position[0], transform.position[1], transform.position[2]);
        
        //create field of dots for target
        int Size = 1000;     //Number of objects
        GameObject[] dots = new GameObject[Size];
        //Loop for the entire size of the array, 10 in this case
        for (int i = 0; i < Size; i++)
        {
            //Create the game object
            dots[i] = GameObject.Instantiate (Resources.Load ("SpherePenalty")) as GameObject;
            if (penDir == 1)
            {
                //Position it in the scene
                dots[i].transform.position = new Vector3(Random.Range(-0.05F,0.05F)+shift,Random.Range(-1.0F,1.0F),Random.Range(-1.0F,1.0F)) + GameManager.Instance.TarPos; 
            }

            if (penDir == 2)
            {
                //Position it in the scene
                dots[i].transform.position = new Vector3(Random.Range(-0.5F,0.5F),Random.Range(-0.05F,0.05F)+shift,Random.Range(-1.0F,1.0F)) + GameManager.Instance.TarPos;
            }

            if (penDir == 3)
            {
                //Position it in the scene
                dots[i].transform.position = new Vector3(Random.Range(-0.5F,0.5F),Random.Range(-1.0F,1.0F),Random.Range(-0.05F,0.05F)+shift) + GameManager.Instance.TarPos; 
            }
        }
    }
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
