using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeMechanics : MonoBehaviour
{

    public TextMeshProUGUI UpgradeEngineText;
    public Button ButtonUpgradeEngine;
    public static int Enginelevel = 1;
    private Button _upgradeButton;



    public void Start()
    {
       //PlayerPrefs.DeleteAll();
        Debug.Log(Enginelevel);
        Debug.Log(PlayerPrefs.GetInt("UpgradeEngine"));
        FullInfoUpdate();
    }

    private void FullInfoUpdate()
    {
        var playerData = PlayerDataHub.instance.PlayerData;
        var car = playerData.TotalCar;
        UpdateInfo(car.EngineUpgrade,ButtonUpgradeEngine, UpgradeEngineText);
        UpdateInfo(car.TransmissionUpgrade, ButtonUpgradeTransmission, UpgradeTransmissionText);
        UpdateInfo(car.WheelsUpgrade, ButtonUpgradeWheels, UpgradeWheelsText);
        UpdateInfo(car.FuelTankUpgrade, ButtonUpgradeTankFuel, UpgradeTankFuelText);
        UpdateInfo(car.CarcassUpgrade, ButtonUpgradeBody, UpgradeBodyText);
    }

    private void UpdateInfo(BaseUpgrade upgrade, Button button,TextMeshProUGUI text)
    {
        var playerData = PlayerDataHub.instance.PlayerData;
        if (upgrade.IsUpgradeable)
        {
            if (upgrade.NextCost<= playerData.CoinsCount)
            {
                button.interactable = true;
                text.text = $"Уровень: {upgrade.Level}";
            }
            else
            {
                button.interactable = false;
                text.text = "Дорого";
            }
        }
        else
        {
            button.interactable = false;
            text.text = "Максимум";
        }
    }

    public void UpgradeEngine()
    {
        var playerData = PlayerDataHub.instance.PlayerData;
        var car = playerData.TotalCar;
        PlayerDataHub.instance.PlayerData.Upgrade(UpgradeType.Engine);
        FullInfoUpdate();
    }

    public TextMeshProUGUI UpgradeTransmissionText;
    public Button ButtonUpgradeTransmission;

    public void UpgradeTransmission()
    {
        var playerData = PlayerDataHub.instance.PlayerData;
        var car = playerData.TotalCar;
        PlayerDataHub.instance.PlayerData.Upgrade(UpgradeType.Transmission);
        FullInfoUpdate();
    }

    public TextMeshProUGUI UpgradeWheelsText;
    public Button ButtonUpgradeWheels;

    public void UpgradeWheels()
    {
        var playerData = PlayerDataHub.instance.PlayerData;
        var car = playerData.TotalCar;
        PlayerDataHub.instance.PlayerData.Upgrade(UpgradeType.Wheels);
        FullInfoUpdate();
    }

    public TextMeshProUGUI UpgradeBodyText;
    public Button ButtonUpgradeBody;

    public void UpgradeBody()
    {
        var playerData = PlayerDataHub.instance.PlayerData;
        var car = playerData.TotalCar;
        PlayerDataHub.instance.PlayerData.Upgrade(UpgradeType.HP);
        FullInfoUpdate();
    }

    public TextMeshProUGUI UpgradeTankFuelText;
    public Button ButtonUpgradeTankFuel;

    public void UpgradeTankFuel()
    {
        var playerData = PlayerDataHub.instance.PlayerData;
        var car = playerData.TotalCar;
        PlayerDataHub.instance.PlayerData.Upgrade(UpgradeType.FuelTank);
        FullInfoUpdate();
    }
}