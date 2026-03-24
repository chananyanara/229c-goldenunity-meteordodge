using UnityEngine;

public class ScoreManager : MonoBehaviour

{

    public float score = 0f;

    void Update()

    {

        score += Time.deltaTime;
        Debug.Log(score);

    }
    
}