using UnityEngine;
public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteorPrefab;
    public float spawnRate = 2f;
    public float rangeX = 5f;
    void Start()
    {
        InvokeRepeating("SpawnMeteor", 1f, spawnRate);
    }
    void SpawnMeteor()
    {
        float randomX = Random.Range(-rangeX, rangeX);
        Vector3 spawnPos = new Vector3(randomX, 10f, 0f);
        Instantiate(meteorPrefab, spawnPos, Quaternion.identity);
    }
}