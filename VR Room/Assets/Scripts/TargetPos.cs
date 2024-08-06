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
        tarLocY.Add(.5F);
        tarLocY.Add(1);
        tarLocY.Add(1.5F);
        
        List<float> tarLocZ = new List<float>();
        tarLocZ.Add(1);
        tarLocZ.Add(0);
        tarLocZ.Add(-1);

        transform.position = new Vector3(
            -1.5F,
            tarLocY[Random.Range(0, tarLocY.Count)],
            tarLocZ[Random.Range(0, tarLocZ.Count)]);
        GameManager.Instance.TarPos = new Vector3(transform.position[0], transform.position[1], transform.position[2]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
