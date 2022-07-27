using UnityEngine;
using UnityEngine.SceneManagement;

public class Stock : MonoBehaviour
{
   public  GameObject obj;
  

    
    public void PressButton(int scenenumber)
    {
        SceneManager.LoadScene(scenenumber,LoadSceneMode.Single);
    }
    public void ShowPanel()
    {
        obj.SetActive(true);
    }
    public void HidePanel()
    {
        obj.SetActive(false);
    }
    public void Buy1Wheel(int count)
    {
        PlayerDataHub.instance.PlayerData.AddLootBoxes(count);
    }
}

