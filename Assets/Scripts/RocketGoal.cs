using UnityEngine;

public class RocketGoal : MonoBehaviour

{

    private void OnTriggerEnter(Collider other)

    {

        

        if (other.CompareTag("Player"))

        {

            Debug.Log("Reached the Rocket!");

            

            GameManager gm = FindFirstObjectByType<GameManager>();

            if (gm != null)

            {

                gm.EndGame(true);

            }

        }

    }

}