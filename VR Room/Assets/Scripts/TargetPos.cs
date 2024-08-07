using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TargetPos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
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
        
        //create field of dots for target
        int Size = 100;     //Number of objects
        GameObject[] dots = new GameObject[Size];
            //Loop for the entire size of the array, 10 in this case
        for (int i = 0; i < Size; i++)
        {
            //Create the game object
            dots[i] = GameObject.Instantiate (Resources.Load ("SphereTarget")) as GameObject;  

            //Position it in the scene
            dots[i].transform.position = (Random.insideUnitSphere * .05F) + GameManager.Instance.TarPos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
