using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    GameObject BulletPrefab;
    [SerializeField]
    Transform spawnLocation;
    public void Fire()
    {
        Instantiate(BulletPrefab, spawnLocation.position, spawnLocation.rotation);
    }
}
