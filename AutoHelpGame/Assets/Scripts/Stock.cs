using System.Collections;
using System.Collections.Generic;
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
       // SceneManager.LoadScene(scenenumber, LoadSceneMode.Single);

    }
    public void HidePanel()
    {
        obj.SetActive(false);
        // SceneManager.LoadScene(scenenumber, LoadSceneMode.Single);

    }
}
