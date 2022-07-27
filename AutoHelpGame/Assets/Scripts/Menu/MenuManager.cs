using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartLevel1() 
    {
        SceneManager.LoadScene("Level_1");
    }
	
	public void StartLevel2() 
    {
        SceneManager.LoadScene("Level_2");
    }

    public void LoadUpgradeScene() 
    {
        SceneManager.LoadScene("UpgradeMenu");
    }
    public void LoadCarWashScene()
    {
        SceneManager.LoadScene("CarWashMenu");
    }
    public void LoadSalesScene()
    {
        SceneManager.LoadScene("SalesMenu");
    }
    public void LoadRepairScene()
    {
        SceneManager.LoadScene("RepairMenu");
    }
	public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadStockMenu()
    {
        SceneManager.LoadScene("StockScene");
    }
	
	public void LoadMapSelection()
    {
        SceneManager.LoadScene("MapSelection");
    }
}
