using UnityEngine;
public class Meteor : MonoBehaviour
{
    public GameObject explosionEffect;
    //ค่าฟิสิกส์
    public float mass = 2f;            // มวล (kg)
    public float gravity = 9.8f;       // ความเร่งโน้มถ่วง (m/s^2)
    public float airResistance = 0.5f; // ค่าสัมประสิทธิ์แรงต้านอากาศ
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Newton's Second Law: F = m * a
        float force = mass * gravity;
        //แรงตกลง 
        rb.AddForce(Vector3.down * force, ForceMode.Force);
    }
    void FixedUpdate()
    {
        //Air Resistance (แรงต้านอากาศจริง)
        // F_drag = -k * v
        Vector3 airDrag = -rb.velocity * airResistance;
        rb.AddForce(airDrag);
    }
    void Update()
    {
        //Rotational Motion (การหมุน)
        transform.Rotate(200 * Time.deltaTime, 120 * Time.deltaTime, 0);
    }
    void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("Ground") ||
            collision.gameObject.CompareTag("Player"))
        {
            if (explosionEffect != null)
            {
                Instantiate(explosionEffect, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}