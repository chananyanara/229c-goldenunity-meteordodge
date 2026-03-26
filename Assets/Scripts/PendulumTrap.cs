using UnityEngine;

public class PendulumTrap : MonoBehaviour

{

    [Header("Settings")]

    public Rigidbody pendulumRb; 

    public float pushForce = 75f; 

    private bool isActivated = false;
    

    private void OnTriggerEnter(Collider other)

    {

    

        if (other.CompareTag("Player") && !isActivated)

        {

            ActivateTrap();

        }

    }

    void ActivateTrap()

    {

        isActivated = true;

        // ใช้การคำนวณแรงผลัก (หัวข้อ A: Constant Force / AddForce)

        // เราผลักไปทางแกน Z ของตัวลูกตุ้มเอง

        pendulumRb.AddForce(Vector3.forward * pushForce, ForceMode.Impulse);

        Debug.Log("กับดักทำงานแล้ว!");

    }

}