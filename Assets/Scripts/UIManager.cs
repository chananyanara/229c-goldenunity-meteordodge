using UnityEngine;

using TMPro;

public class UIManager : MonoBehaviour

{

    public ScoreManager scoreManager;

    public PlayerHealth playerHealth;

    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI hpText;

    void Update()

    {

        int displayScore = Mathf.FloorToInt(scoreManager.score);

        scoreText.text = "Score: " + displayScore;

        hpText.text = "HP: " + playerHealth.hp;

    }

}