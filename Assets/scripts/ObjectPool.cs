using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject objectToPool; 
    public int amountToPool; 
    public float spawnRate = 2f; 
    public float timeToReset = 5f; 

    private List<GameObject> pooledObjects; 
    private float nextSpawnTime = 0f;

    void Awake()
    {
        pooledObjects = new List<GameObject>();
        
        for(int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(objectToPool);
            obj.SetActive(false); 
            pooledObjects.Add(obj);
        }
    }

    void Update()
    {
        
        if(Time.time >= nextSpawnTime)
        {
            SpawnSphere();
            nextSpawnTime = Time.time + 1f / spawnRate;
        }
    }

    void SpawnSphere()
    {
        GameObject sphere = GetPooledObject();
        if (sphere != null)
        {
            sphere.transform.position = this.transform.position;
            sphere.SetActive(true);
            StartCoroutine(ResetObject(sphere));
        }
    }

    GameObject GetPooledObject()
    {
        foreach (var pooledObject in pooledObjects)
        {
            
            if (!pooledObject.activeInHierarchy)
            {
                return pooledObject;
            }
        }
        return null;
    }

    System.Collections.IEnumerator ResetObject(GameObject obj)
    {
        yield return new WaitForSeconds(timeToReset);
        obj.SetActive(false);
    }
}