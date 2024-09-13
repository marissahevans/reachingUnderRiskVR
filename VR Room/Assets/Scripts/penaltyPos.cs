using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using Random = UnityEngine.Random;

public class penaltyPos : MonoBehaviour
{
    public Bounds penBound;
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
        int Size = 10000;     //Number of objects
        GameObject[] dots = new GameObject[Size];
        
        //Loop for the entire size of the array
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

       // GameObject[] penSpheres = GameObject.FindGameObjectsWithTag("penalty");
    }
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
