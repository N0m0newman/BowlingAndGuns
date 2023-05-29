using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pins : MonoBehaviour
{
    Vector3 HomeLocation;
    bool isResetReady = true;
    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        HomeLocation = this.gameObject.transform.position;
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Force Resetting");      
            StartCoroutine(ResetPins());
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name.Contains("Ball") || collision.gameObject.name.Contains("Pin"))
        {
            if (!isResetReady) return;
            Debug.Log("Ball Hit");
            StartCoroutine(ResetPins());
            isResetReady = false;
        }
    }

    IEnumerator ResetPins() 
    {
        Debug.Log("resetting");
        yield return new WaitForSeconds(3);
        transform.position = HomeLocation;
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        transform.rotation = new Quaternion(0, 0, 0, 0);
        rigidbody.freezeRotation = true;
        yield return new WaitForSeconds(.2f);
        rigidbody.freezeRotation = false;
        isResetReady = true;
    }
}
