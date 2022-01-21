using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapSpawner : MonoBehaviour
{
    public GameObject[] tapPrefab;
    public Transform spawnPoint;

    public float delay = 2f;

    // Use this for initialization
    void Start()
    {
       StartCoroutine(SpawnTap());
    }

    void Update()
    {
        if (Timer.timeRunning == false)
        {
            StopCoroutine(SpawnTap());
        }
    }
    IEnumerator SpawnTap()
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);

            int randomSpawn = Random.Range(0, tapPrefab.Length);
            GameObject spawnObject = Instantiate(tapPrefab[randomSpawn], spawnPoint.position, spawnPoint.rotation);
            Destroy(spawnObject, 4f);
        }
    }

}
