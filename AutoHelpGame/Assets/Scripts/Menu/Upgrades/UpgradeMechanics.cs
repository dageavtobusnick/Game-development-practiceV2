using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    }
    public void Update()
    {
        var playerData = PlayerDataHub.instance.PlayerData;
        if (playerData.TotalCar.EngineUpgrade.Next!=null)
        {
            if(playerData.TotalCar.EngineUpgrade.Cost <= playerData.CoinsCount)
            {
                ButtonUpgradeEngine.interactable = true;
                UpgradeEngineText.text = $"Уровень: {playerData.TotalCar.EngineUpgrade.Level}";
            }
            else
            {
                ButtonUpgradeEngine.interactable = false;
                UpgradeEngineText.text = "Дорого";
            }
        }
        else 
        {
            ButtonUpgradeEngine.interactable = false;
            UpgradeEngineText.text = "Максимум";
        }
        if (playerData.TotalCar.TransmissionUpgrade.Next!=null)
        {
            if(playerData.TotalCar.TransmissionUpgrade.Cost <= playerData.CoinsCount)
            {
                ButtonUpgradeTransmission.interactable = true;
                UpgradeTransmissionText.text = $"Уровень: {playerData.TotalCar.TransmissionUpgrade.Level}";
            }
            else
            {
                ButtonUpgradeTransmission.interactable = false;
                UpgradeTransmissionText.text = "Дорого";
            }
        }
        else 
        {
            ButtonUpgradeTransmission.interactable = false;
            UpgradeTransmissionText.text = "Максимум";
        }
        if (playerData.TotalCar.WheelsUpgrade.Next!=null)
        {
            if(playerData.TotalCar.WheelsUpgrade.Cost <= playerData.CoinsCount)
            {
                ButtonUpgradeWheels.interactable = true;
                UpgradeWheelsText.text = $"Уровень: {playerData.TotalCar.WheelsUpgrade.Level}";
            }
            else
            {
                ButtonUpgradeWheels.interactable = false;
                UpgradeWheelsText.text = "Дорого";
            }
        }
        else 
        {
            ButtonUpgradeWheels.interactable = false;
            UpgradeWheelsText.text = "Максимум";
        }
        if (playerData.TotalCar.CarcassUpgrade.Next!=null)
        {
            if(playerData.TotalCar.CarcassUpgrade.Cost <= playerData.CoinsCount)
            {
                ButtonUpgradeBody.interactable = true;
                UpgradeBodyText.text = $"Уровень: {playerData.TotalCar.CarcassUpgrade.Level}";
            }
            else
            {
               ButtonUpgradeBody.interactable = false;
                UpgradeBodyText.text = "Дорого";
            }
        }
        else 
        {
            ButtonUpgradeBody.interactable = false;
            UpgradeBodyText.text = "Максимум";
        }
        if (playerData.TotalCar.FuelTankUpgrade.Next!=null)
        {
            if(playerData.TotalCar.FuelTankUpgrade.Cost <= playerData.CoinsCount)
            {
                ButtonUpgradeTankFuel.interactable = true;
                UpgradeTankFuelText.text = $"Уровень: {playerData.TotalCar.FuelTankUpgrade.Level}";
            }
            else
            {
                ButtonUpgradeTankFuel.interactable = false;
                UpgradeTankFuelText.text = "Дорого";
            }
        }
        else 
        {
            ButtonUpgradeTankFuel.interactable = false;
            UpgradeTankFuelText.text = "Максимум";
        }
    }
    public void UpgradeEngine()
    {
        PlayerDataHub.instance.PlayerData.Upgrade(UpgradeType.Engine);
    }

    public TextMeshProUGUI UpgradeTransmissionText;
    public Button ButtonUpgradeTransmission;

    public void UpgradeTransmission()
    {
        PlayerDataHub.instance.PlayerData.Upgrade(UpgradeType.Transmission);
    }

    public TextMeshProUGUI UpgradeWheelsText;
    public Button ButtonUpgradeWheels;

    public void UpgradeWheels()
    {

        PlayerDataHub.instance.PlayerData.Upgrade(UpgradeType.Wheels);
    }

    public TextMeshProUGUI UpgradeBodyText;
    public Button ButtonUpgradeBody;

    public void UpgradeBody()
    {
        PlayerDataHub.instance.PlayerData.Upgrade(UpgradeType.HP);
    }

    public TextMeshProUGUI UpgradeTankFuelText;
    public Button ButtonUpgradeTankFuel;

    public void UpgradeTankFuel()
    {
        PlayerDataHub.instance.PlayerData.Upgrade(UpgradeType.FuelTank);
    }
}