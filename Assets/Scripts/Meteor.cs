using UnityEngine;

public class Meteor : MonoBehaviour

{

    public GameObject explosionEffect;

    [Header("Physics Settings")]

    public float mass = 2f;             // มวล (kg)

    public float gravity = 9.8f;        // ความเร่งโน้มถ่วง (m/s^2)

    public float airResistance = 0.5f;  // ค่าสัมประสิทธิ์แรงต้านอากาศ (หัวข้อ E)

    public float rotationForce = 10f;   // แรงบิดสำหรับการหมุน (หัวข้อ F)

    private Rigidbody rb;

    void Start()

    {

        rb = GetComponent<Rigidbody>();

        // --- หัวข้อ C: กฎข้อที่ 2 ของนิวตัน (F = ma) ---

        // คำนวณแรงตกจากมวลและความเร่ง

        float force = mass * gravity; 

        rb.AddForce(Vector3.down * force, ForceMode.Force);

        // --- หัวข้อ F: การเคลื่อนที่แบบหมุน (Rotational Motion / Angular Velocity) ---

        // ใช้ AddTorque เพื่อให้เกิดแรงบิดตามกฎฟิสิกส์ แทนการปรับมุมโดยตรง

        Vector3 randomTorque = new Vector3(

            Random.Range(-1f, 1f), 

            Random.Range(-1f, 1f), 

            Random.Range(-1f, 1f)

        );

        rb.AddTorque(randomTorque * rotationForce, ForceMode.Impulse);

    }

    void FixedUpdate()

    {

        // --- หัวข้อ E: แรงต้านอากาศ (Air Resistance) ---

        // สูตร F_drag = -k * v (แรงต้านแปรผันตามความเร็วและทิศทางตรงกันข้าม)

        Vector3 airDrag = -rb.velocity * airResistance;

        rb.AddForce(airDrag);

    }

    // ลบ Update() เดิมที่ใช้ transform.Rotate ออก เพราะเราใช้ AddTorque ใน Start แทนแล้ว

    void OnCollisionEnter(Collision collision)

    {

        // ตรวจสอบการชน (Collision Detection)

        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Player"))

        {

            if (explosionEffect != null)

            {

                // สร้างเอฟเฟกต์ระเบิด

                GameObject effect = Instantiate(explosionEffect, transform.position, Quaternion.identity);

                Destroy(effect, 2f); // ลบเอฟเฟกต์ทิ้งหลังจาก 2 วินาทีเพื่อคืนค่า Memory

            }

            // ทำลายอุกกาบาตลูกนี้

            Destroy(gameObject);

        }

    }

}
 