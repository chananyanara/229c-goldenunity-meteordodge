using UnityEngine;

public class RocketGoal : MonoBehaviour

{

    private void OnTriggerEnter(Collider other)

    {

        // เช็คว่าสิ่งที่มาชนคือ Player ใช่หรือไม่

        if (other.CompareTag("Player"))

        {

            Debug.Log("Reached the Rocket!");

            // เรียกใช้ GameManager เพื่อจบเกมแบบ "ชนะ" (true)

            GameManager gm = FindFirstObjectByType<GameManager>();

            if (gm != null)

            {

                gm.EndGame(true); // true = ชนะ (Mission Complete)

            }

        }

    }

}