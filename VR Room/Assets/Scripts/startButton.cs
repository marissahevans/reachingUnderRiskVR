using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startButton : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("You started the trial");
        GameManager.Instance.Trial++;
        SceneManager.LoadScene("TarDisp");
        Debug.Log("Trial:" + GameManager.Instance.Trial);
    }
}
