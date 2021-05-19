using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject waterMElonObject;
    public Transform[] spawnPoint;
    float minDelay = .2f;
    float maxDelay = 1.2f;

    private void Start()
    {
        StartCoroutine(createFruit());
    }
    IEnumerator  createFruit()
    {
        while (true)
        {
            float randomDelay = Random.Range(minDelay,maxDelay);
            yield return new WaitForSeconds(randomDelay);
            int spawnIndex = Random.Range(0, spawnPoint.Length);
            GameObject waterMelon = Instantiate(waterMElonObject, spawnPoint[spawnIndex].transform.position, spawnPoint[spawnIndex].transform.rotation);
            Destroy(waterMelon, 3f);

        }
    }
}
