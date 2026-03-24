using UnityEngine;
public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteorPrefab;
    void Start()
    {
        InvokeRepeating("SpawnMeteor", 1f, 2f);
    }
    void SpawnMeteor()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-5f, 5f), 20f, 0);
        GameObject meteor = Instantiate(meteorPrefab, spawnPos, Quaternion.identity);
       
        MeshRenderer mr = meteor.GetComponent<MeshRenderer>();
        if (mr != null)
        {
            mr.enabled = true;
        }
    }
}