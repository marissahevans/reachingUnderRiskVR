using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startButton : MonoBehaviour
{
    private IEnumerator WaitForSceneLoad()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("TarDisp");
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("You started the trial");
        GameManager.Instance.Trial++;
        StartCoroutine(WaitForSceneLoad());
        Debug.Log("Trial:" + GameManager.Instance.Trial);
    }
}
