using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateTaggedObjects : MonoBehaviour
{
   public float scaleAmount = 1.5F;
   public float duration = 1.0F;
   public float delay = 0.0F;

   public void AnimateObject(string tagToAnimate)
   {
      // Find all gameobjects with specific tag
      GameObject[] objectsToAnimate = GameObject.FindGameObjectsWithTag(tagToAnimate);
      
      //Start animation
      StartCoroutine(AnimateObjectsCoroutine(objectsToAnimate));
   }

   private IEnumerator AnimateObjectsCoroutine(GameObject[] objectsToAnimate)
   {
      yield return new WaitForSeconds(delay);

      // Store original scale of each object
      float elapsedTime = 0F;
      Vector3[] originalScales = new Vector3[objectsToAnimate.Length];

      for (int i = 0; i < objectsToAnimate.Length; i++)
      {
         originalScales[i] = objectsToAnimate[i].transform.localScale;
      }

      // Animate objects
      while (elapsedTime < duration)
      {
         elapsedTime += Time.deltaTime;

         float scaleFactor = Mathf.PingPong(elapsedTime / duration, scaleAmount - 1) + 1;
         
         // Apply thenew scale to all GameObjects with the tag
         for (int i = 0; i < objectsToAnimate.Length; i++)
         {
            objectsToAnimate[i].transform.localScale = originalScales[i] * scaleFactor;
         }

         yield return null;
      }
      
      //Reset scale to  normal 
      for (int i = 0; i < objectsToAnimate.Length; i++)
      {
         objectsToAnimate[i].transform.localScale = originalScales[i];
      }
   }
}
