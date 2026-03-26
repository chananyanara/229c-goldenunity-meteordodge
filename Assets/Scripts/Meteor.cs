using UnityEngine;

public class Meteor : MonoBehaviour

{

    public GameObject explosionEffect;

    [Header("Physics Settings")]

    public float mass = 2f;             // มวล (kg)

    public float gravity = 9.8f;        // ความเร่งโน้มถ่วง (m/s^2)

    public float airResistance = 0.5f;  // ค่าสัมประสิทธิ์แรงต้านอากาศ

    public float rotationForce = 10f;   // แรงบิดสำหรับการหมุน 

    private Rigidbody rb;

    void Start()

    {

        rb = GetComponent<Rigidbody>();

        // กฎข้อที่ 2 ของนิวตัน (F = ma) 

        // คำนวณแรงตกจากมวลและความเร่ง

        float force = mass * gravity; 

        rb.AddForce(Vector3.down * force, ForceMode.Force);

        // การเคลื่อนที่แบบหมุน (Rotational Motion / Angular Velocity) ---
        

        Vector3 randomTorque = new Vector3(

            Random.Range(-1f, 1f), 

            Random.Range(-1f, 1f), 

            Random.Range(-1f, 1f)

        );

        rb.AddTorque(randomTorque * rotationForce, ForceMode.Impulse);

    }

    void FixedUpdate()

    {

        // แรงต้านอากาศ (Air Resistance) ---

        // สูตร F_drag = -k * v (แรงต้านแปรผันตามความเร็วและทิศทางตรงกันข้าม)

        Vector3 airDrag = -rb.linearVelocity * airResistance;

        rb.AddForce(airDrag);

    }

    void OnCollisionEnter(Collision collision)

    {

        // ตรวจสอบการชน (Collision Detection)

        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Player"))

        {

            if (explosionEffect != null)

            {

                // สร้างเอฟเฟกต์ระเบิด

                GameObject effect = Instantiate(explosionEffect, transform.position, Quaternion.identity);

                Destroy(effect, 2f);

            }
            

            Destroy(gameObject);

        }

    }

}
 