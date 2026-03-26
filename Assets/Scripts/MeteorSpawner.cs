using UnityEngine;

public class MeteorSpawner : MonoBehaviour

{
    [Header("References")]
    public GameObject meteorPrefab; 
    public Transform player;  
    [Header("Spawn Area")]
    public float spawnRadius = 10f; 
    public float spawnHeight = 20f; 
    [Header("Difficulty Settings")]
    public float initialDelay = 0.3f;  
    public float minDelay = 0.2f; 
    public float difficultySpeed = 0.05f; 
    private float currentDelay;
    private float timer;
    void Start()
    {
        currentDelay = initialDelay;
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null) player = playerObj.transform;
        }
    }
    void Update()
    {
        if (player == null) return; 
        transform.position = new Vector3(player.position.x, transform.position.y, player.position.z);
        timer += Time.deltaTime;
        if (timer >= currentDelay)
        {
            SpawnMeteor();
            timer = 0;
            if (currentDelay > minDelay)
            {
                currentDelay -= difficultySpeed;
            }
        }
    }
    void SpawnMeteor()

    {
        float randomX = Random.Range(-spawnRadius, spawnRadius);
        float randomZ = Random.Range(-spawnRadius, spawnRadius);
        Vector3 spawnPos = new Vector3(
            transform.position.x + randomX, 
            spawnHeight, 
            transform.position.z + randomZ
        );
        GameObject meteor = Instantiate(meteorPrefab, spawnPos, Quaternion.identity);
        MeshRenderer mr = meteor.GetComponent<MeshRenderer>();
        if (mr != null)
        {
            mr.enabled = true;
        }
    }
}
 