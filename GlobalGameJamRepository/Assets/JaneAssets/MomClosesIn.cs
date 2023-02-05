using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MomClosesIn : MonoBehaviour
{
    public float speed = 3.0f;
    private float alphaVal = 1f;
    public Transform target; // The target position.
    public SpriteRenderer spr;
    public WaitForSeconds secondsPassed;
    private void Update()
    {
        if (GameManager.instance.isDead == true)
        {
            // Move our position a step closer to the target.
            var step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
           
            /*if(spr.color.a > 0)
            {
                alphaVal -= .002f;
                spr.color -= new Color(255, 255, 255, alphaVal);
            }
            */

            StartCoroutine(DisappearAfter());
        }
        IEnumerator DisappearAfter()
        {
            yield return new WaitForSecondsRealtime(1); // Disappear after 2 seconds
            
            if (spr.color.a > 0)
            {
                alphaVal -= .002f;
                spr.color -= new Color(255, 255, 255, alphaVal);
            }

        }
    }
}
