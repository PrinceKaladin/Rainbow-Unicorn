using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnscript : MonoBehaviour
{
    public GameObject[] prefabs;   // 5 вариантов
    public int count = 5;
    public float spawnDelay = 1f;
    public float xRange = 2.5f;
    public float spawnY = 5f;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < count; i++)
        {
            int index = Random.Range(0, prefabs.Length);
            float x = Random.Range(-xRange, xRange);

            Instantiate(
                prefabs[index],
                new Vector3(x, spawnY, 0),
                Quaternion.identity
            );

            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
