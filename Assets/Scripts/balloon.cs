using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class balloon : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    GameObject trackerObject;
    [SerializeField]
    scoreTracker trakcer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3 (0, 1, 0);
        StartCoroutine(MaxLife());
        trackerObject = GameObject.Find("GunStand");
        trakcer = trackerObject.GetComponent<scoreTracker>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name.Contains("Bullet"))
        {
            trakcer.IncreaseScore();
            Destroy(gameObject);
        }
    }

    IEnumerator  MaxLife()
    {
        yield return new WaitForSeconds(30);
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }

}
