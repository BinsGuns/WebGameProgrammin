using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int poolSize = 3;

    private List<GameObject> pooledObjects = new List<GameObject>();

    // Called when the script instance is being loaded.
    private void Awake()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(bulletPrefab);
            enemy.SetActive(false);
            pooledObjects.Add(enemy);
        }
    }

    // Get an available object from the pool, or create a new one if the pool is empty.
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        // If no inactive object is found in the pool, create a new one and add it to the pool.
        GameObject newBullet = Instantiate(bulletPrefab);
        newBullet.SetActive(false);
        pooledObjects.Add(newBullet);
        return newBullet;
    }

    // Recycle the object back to the pool when it's no longer needed.
    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
    }
}
