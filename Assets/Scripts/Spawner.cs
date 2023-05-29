using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject balloonprefab;
    [SerializeField]
    public bool spawning = false;

    BoxCollider area;

    // Start is called before the first frame update
    void Start()
    {
        area = GetComponent<BoxCollider>();
    }

    public void ChangeSpawning()
    {
        spawning = !spawning;
        if(spawning ) 
        {
            CancelInvoke("Spawn");
        } else
        {
            InvokeRepeating("Spawn", 0f, 2f);
        }
        
    }
    
    void Spawn()
    {   
        Instantiate(balloonprefab, RandomPointInBounds(area.bounds), Quaternion.Euler(-90,0,0));
    }

    Vector3 RandomPointInBounds(Bounds bounds)
    {
        float minX = bounds.size.x * -0.5f;
        float minY = bounds.size.y * -0.5f;
        float minZ = bounds.size.z * -0.5f;

        return (Vector3)this.gameObject.transform.TransformPoint(
            new Vector3(Random.Range(minX, -minX),
                Random.Range(minY, -minY),
                Random.Range(minZ, -minZ))
        );
    }
}
