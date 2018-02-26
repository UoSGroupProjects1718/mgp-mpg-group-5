using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] spawners;
    public GameObject node;

    int arrayIndex;

    private void Update()
    {
        SpawnNode();
    }

    // Randomly select a spawn point 
    public void SpawnNode()
    {
        StartCoroutine(SpawnWait());
        //SpawnWait();
        arrayIndex = Random.Range(0, 5);
        var randomSpawn = spawners[arrayIndex];
        Instantiate(node, randomSpawn.transform.position, Quaternion.identity);
    }

    IEnumerator SpawnWait()
    {
        yield return new WaitForSeconds(5);
    }
}