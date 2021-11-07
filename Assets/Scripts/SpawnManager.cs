using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] asteroidsPrefabs;
    public float startTime;
    private float timeLast;
    void Start()
    {
        timeLast = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        timeLast -= Time.deltaTime;
        if (timeLast <= 0)
        {
            int i = Random.Range(0, asteroidsPrefabs.Length);
            Instantiate(asteroidsPrefabs[i], new Vector3(Random.Range(-73f, 73f), 0, gameObject.transform.position.z), Quaternion.identity);
            timeLast = startTime + Random.Range(-3, 3);
        }
    }
}
