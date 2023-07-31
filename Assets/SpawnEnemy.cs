using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject enemy = GetComponent<ObjectPooler>().GetPooledObject();
        enemy.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
