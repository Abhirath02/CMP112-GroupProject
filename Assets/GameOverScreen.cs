using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    public GameObject FailUI;

    // Call this from anywhere (like Health)
    public void TriggerGameOver()
    {
         Debug.Log("Game Over Triggered!");
        Time.timeScale = 0;  // pause the game
        if(FailUI != null)
            FailUI.SetActive(true);
    }

}