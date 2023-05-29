using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBlock : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            if (other.gameObject.name.Contains("Bullet"))
            {
                Destroy(other.gameObject);
            }
        }
    }
}
