using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Random = UnityEngine.Random;

public class penaltyPos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(-1,1) > 0)
        {
            transform.position = new Vector3(
                -1,
                1,
                GameManager.Instance.TarPos[2] - .2F);
            GameManager.Instance.PenaltyPos =
                new Vector3(transform.position[0], transform.position[1], transform.position[2]);
        }
        else
        {
            transform.position = new Vector3(
                -1,
                1,
                GameManager.Instance.TarPos[2] + .2F);
            GameManager.Instance.PenaltyPos =
                new Vector3(transform.position[0], transform.position[1], transform.position[2]);
        }
    }
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
