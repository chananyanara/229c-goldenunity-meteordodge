using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
   [Header("UI Panels")]
   public GameObject resultPanel; 
   [Header("UI Display")]
   public TextMeshProUGUI statusTxt; 
   public TextMeshProUGUI scoreTxt;  
   public TextMeshProUGUI rankTxt;  
   public TextMeshProUGUI announceTxt; 
   private float timer = 0f;
   private bool isGameOver = false;
   private int lastRankUpdate = 0;
   void Start()
   {
       Time.timeScale = 1f;
       if(resultPanel != null) resultPanel.SetActive(false);
       if(announceTxt != null) announceTxt.gameObject.SetActive(false);
   }
   void Update()
   {
       if (isGameOver) return;
       timer += Time.deltaTime;
       int currentSec = Mathf.FloorToInt(timer);
       if (currentSec > 0 && currentSec % 10 == 0 && currentSec != lastRankUpdate)
       {
           lastRankUpdate = currentSec;
           ShowRankUp(GetRankName(timer));
       }
   }
   public void EndGame(bool isWin)
   {
       isGameOver = true;
       Time.timeScale = 0f; 
       if (resultPanel != null)
       {
           resultPanel.SetActive(true);
           statusTxt.text = isWin ? "MISSION COMPLETE" : "MISSION FAILED";
           statusTxt.color = isWin ? Color.green : Color.red;
           scoreTxt.text = "Survival Time: " + Mathf.FloorToInt(timer) + "s";
           rankTxt.text = "Rank: " + GetRankName(timer);
       }
   }
   string GetRankName(float t)
   {
       if (t >= 40f) return "UNTOUCHABLE";
       if (t >= 30f) return "ELITE";
       if (t >= 20f) return "EVADER";
       if (t >= 10f) return "AMATEUR";
       return "NOVICE";
   }
   void ShowRankUp(string name)
   {
       if (announceTxt == null) return;
       announceTxt.text = "RANK UP: " + name;
       announceTxt.gameObject.SetActive(true);
       CancelInvoke("HideAnnounce");
       Invoke("HideAnnounce", 2f);
   }
   void HideAnnounce() { announceTxt.gameObject.SetActive(false); }
   public void RestartGame() { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }
} 