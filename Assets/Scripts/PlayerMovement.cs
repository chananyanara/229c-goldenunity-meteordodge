using UnityEngine;

public class PlayerMovement : MonoBehaviour

{

    public float speed = 5f;

    void Update()

    {

        float moveX = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(moveX, 0f, 0f);

        transform.Translate(movement * speed * Time.deltaTime);

    }

}
 