using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeSpawner : MonoBehaviour
{
    public GameObject[] swipePrefab;
    public Transform spawnPoint;
    public Transform endPoint;
    public float parabolaDuration;

    public float delay = 2f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnSwipe());
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer.timeRunning == false)
        {
            StopCoroutine(SpawnSwipe());
        }
    }
    IEnumerator SpawnSwipe()
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            Throw();
            
        }
    }
    void Throw()
    {
        float xdistance;
        xdistance = endPoint.position.x - spawnPoint.position.x;

        float ydistance;
        ydistance = endPoint.position.y - spawnPoint.position.y;

        float paraAngle;
        paraAngle = Mathf.Atan((ydistance + 4.905f * (parabolaDuration * parabolaDuration)) / xdistance);
        float totalVelo = xdistance / (Mathf.Cos(paraAngle) * parabolaDuration);

        float xVelo, yVelo;
        xVelo = totalVelo * Mathf.Cos(paraAngle);
        yVelo = totalVelo * Mathf.Sin(paraAngle);
        int randomSpawn = Random.Range(0, swipePrefab.Length);
        GameObject spawnObject = Instantiate(swipePrefab[randomSpawn], spawnPoint.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        Rigidbody2D rb;
        rb = spawnObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(xVelo, yVelo);
        Destroy(spawnObject, 4f);
    }
}
