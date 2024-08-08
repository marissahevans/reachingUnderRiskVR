using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startExperiment : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadExperiment()
    {
        SceneManager.LoadScene("StartingRoom");
    }
}
