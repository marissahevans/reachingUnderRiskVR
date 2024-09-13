using System;
using System.Collections;
using System.Collections.Generic;using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class rewardVisuals : MonoBehaviour
{
    public AnimateTaggedObjects sizeChange;
    private string penalty = "penalty";
    private string target = "target";
    
    public void performReward()
  {
    GameObject pts = new GameObject();
    
    if (IsPointInCuboid(GameManager.Instance.ReachEndpt, GameManager.Instance.PenaltyPos))
    {
      GameManager.Instance.Points += -500;
      pts = Instantiate (Resources.Load ("lostPoints")) as GameObject;
      sizeChange.AnimateObject(penalty);
      //animate -500 graphic (possibly get big?)

    }
    else if (IsPointInSphere(GameManager.Instance.ReachEndpt, GameManager.Instance.TarPos, GameManager.Instance.tarSize))
    {
      GameManager.Instance.Points += 300;
      pts = Instantiate (Resources.Load ("gainPoints")) as GameObject;
      sizeChange.AnimateObject(target);
    }
    else
    {
      GameManager.Instance.Points += 0;
      pts = Instantiate (Resources.Load ("zeroPoints")) as GameObject;
    }
  }

  bool IsPointInCuboid(Vector3 point, Bounds bounds)
  {
    return bounds.Contains(point);
  }

  bool IsPointInSphere(Vector3 point, Vector3 center, float radius)
  {
    return Vector3.Distance(point, center) <= radius;
  }
}
