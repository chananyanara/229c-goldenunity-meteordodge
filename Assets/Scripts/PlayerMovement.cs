using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 10f; 
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); 

        float moveZ = Input.GetAxis("Vertical"); 
        Vector3 movement = new Vector3(moveX, 0f, moveZ);
        if (movement.magnitude > 1)
        {
            movement.Normalize();
        }
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
        if (movement != Vector3.zero)
        {
            transform.forward = movement;
        }
    }
}