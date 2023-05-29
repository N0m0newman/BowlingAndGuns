using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGutter : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
         if(other.gameObject.name.Contains("Ball"))
        {
            other.gameObject.GetComponent<Ball>().ResetBallToHome();
        }
    }
}
