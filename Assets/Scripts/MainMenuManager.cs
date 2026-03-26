using UnityEngine;
using UnityEngine.SceneManagement; // สำคัญมาก: ต้องมีบรรทัดนี้เพื่อใช้คำสั่งเปลี่ยน Scene

public class MainMenuController : MonoBehaviour
{
    // ฟังก์ชันสำหรับกดไปหน้าเครดิต
    public void GoToCredits()
    {
        
        SceneManager.LoadScene("Credit");
    }
}

