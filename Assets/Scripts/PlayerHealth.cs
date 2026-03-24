using UnityEngine;

public class PlayerHealth : MonoBehaviour

{

    public int hp = 5;

    void OnCollisionEnter(Collision collision)

    {

        if (collision.gameObject.CompareTag("Meteor"))

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

        Debug.Log("Game Over");

        Time.timeScale = 0f;

    }

}