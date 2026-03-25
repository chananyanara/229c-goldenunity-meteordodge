using UnityEngine;

public class PlayerMovement : MonoBehaviour

{

    [Header("Movement Settings")]

    public float speed = 10f; // ปรับความเร็วตามใจชอบ

    void Update()

    {

        // 1. รับค่าจากคีย์บอร์ด (Horizontal: A,D / Vertical: W,S)

        float moveX = Input.GetAxis("Horizontal"); 

        float moveZ = Input.GetAxis("Vertical"); 

        // 2. สร้าง Vector ทิศทาง (X คือซ้ายขวา, Z คือหน้าหลัง)

        // เราใช้แกน Z เพราะในโลก 3D การเดินไปข้างหน้าคือแกน Z ครับ

        Vector3 movement = new Vector3(moveX, 0f, moveZ);

        // 3. ทำให้การเคลื่อนที่ไม่เร็วเกินไปเวลาเดินแนวทะแยง (Normalize)

        if (movement.magnitude > 1)

        {

            movement.Normalize();

        }

        // 4. สั่งให้ตัวละครเคลื่อนที่

        // Space.World ช่วยให้เดินตามทิศทางของแมพ ไม่หมุนตามตัวละคร

        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        // 5. (แถม) ถ้าอยากให้ตัวละครหันหน้าไปทางที่เดิน

        if (movement != Vector3.zero)

        {

            transform.forward = movement;

        }

    }

}