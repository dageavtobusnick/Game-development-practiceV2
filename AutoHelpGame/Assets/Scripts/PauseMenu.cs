using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
   public void RestartLevel() //Restarts the level
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
         Time.timeScale = 1f;
    }
}
