using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    Vector3 HomeLocation;
    Rigidbody body;
    void Start()
    {
        HomeLocation = transform.position;
        body = GetComponent<Rigidbody>();
    }

    public void ResetBallToHome()
    {
        StartCoroutine(ResetBall());
    }

    IEnumerator ResetBall()
    {
        yield return new WaitForSeconds(2);
        transform.position = HomeLocation;
        body.velocity = Vector3.zero;
        body.angularVelocity = Vector3.zero;
        transform.rotation = new Quaternion(0, 0, 0, 0);
        body.freezeRotation = true;
        yield return new WaitForSeconds(.2f);
        body.freezeRotation = false;
    }
}
