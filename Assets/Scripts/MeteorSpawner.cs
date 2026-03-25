using UnityEngine;

public class MeteorSpawner : MonoBehaviour

{

    [Header("References")]

    public GameObject meteorPrefab; // ลาก Prefab อุกกาบาตมาใส่

    public Transform player;        // ลากตัวละครผู้เล่นมาใส่

    [Header("Spawn Area")]

    public float spawnRadius = 10f;  // รัศมีสุ่มรอบตัวผู้เล่น (ปรับให้กว้างหรือแคบได้)

    public float spawnHeight = 20f;  // ความสูงที่อุกกาบาตเริ่มตก

    [Header("Difficulty Settings")]

    public float initialDelay = 0.3f;     // เริ่มต้นเกิดทุกๆ 2 วินาที

    public float minDelay = 0.2f;         // เร็วที่สุดที่จะเกิดได้ (กันเครื่องค้าง)

    public float difficultySpeed = 0.05f; // ยิ่งเยอะ ยิ่งยากเร็วขึ้น (ลด delay ทุกครั้งที่เกิด)

    private float currentDelay;

    private float timer;

    void Start()

    {

        currentDelay = initialDelay;

        // ถ้าลืมลาก Player ใส่ใน Inspector ให้โค้ดช่วยหา Tag "Player" เอง

        if (player == null)

        {

            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

            if (playerObj != null) player = playerObj.transform;

        }

    }

    void Update()

    {

        if (player == null) return; // ถ้าหาผู้เล่นไม่เจอ ไม่ต้องทำงาน

        // --- 1. ทำให้ Spawner "เดินตาม" ผู้เล่นตลอดเวลา ---

        // วิธีนี้จะทำให้อุกกาบาตตกตามทางที่ผู้เล่นเดินไปหาจรวด

        transform.position = new Vector3(player.position.x, transform.position.y, player.position.z);

        // --- 2. ระบบนับเวลาเกิดอุกกาบาต ---

        timer += Time.deltaTime;

        if (timer >= currentDelay)

        {

            SpawnMeteor();

            timer = 0;

            // --- 3. ระบบความยาก: ยิ่งเวลาผ่านไป ยิ่งตกถี่ขึ้น ---

            if (currentDelay > minDelay)

            {

                currentDelay -= difficultySpeed;

            }

        }

    }

    void SpawnMeteor()

    {

        // สุ่มตำแหน่ง X และ Z รอบๆ ตัว Spawner (ซึ่งตอนนี้อยู่ที่เดียวกับผู้เล่น)

        float randomX = Random.Range(-spawnRadius, spawnRadius);

        float randomZ = Random.Range(-spawnRadius, spawnRadius);

        Vector3 spawnPos = new Vector3(

            transform.position.x + randomX, 

            spawnHeight, 

            transform.position.z + randomZ

        );

        // สร้างอุกกาบาต

        GameObject meteor = Instantiate(meteorPrefab, spawnPos, Quaternion.identity);

        // เปิด MeshRenderer ตามโค้ดเดิมของคุณ (เผื่อปิดไว้ใน Prefab)

        MeshRenderer mr = meteor.GetComponent<MeshRenderer>();

        if (mr != null)

        {

            mr.enabled = true;

        }

    }

}
 