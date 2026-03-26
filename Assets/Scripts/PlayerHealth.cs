using UnityEngine;

public class PlayerHealth : MonoBehaviour

{

    public int hp = 5; // ใช้ชื่อเดิมที่คุณต้องการ

    private bool isDead = false;

    void OnCollisionEnter(Collision collision)

    {

        if (collision.gameObject.CompareTag("Meteor") && !isDead)

        {

            hp--;

            Debug.Log("HP: " + hp);

            if (hp <= 0)

            {

                GameOver();

            }

        }

    }

    void GameOver()

    {

        isDead = true;

        Debug.Log("Game Over Called");

        // เรียกใช้ฟังก์ชัน EndGame จาก GameManager

        GameManager gm = FindFirstObjectByType<GameManager>();

        if (gm != null)

        {

            gm.EndGame(false); // false หมายถึงแพ้

        }

    }

}