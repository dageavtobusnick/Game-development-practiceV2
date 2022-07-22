using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UpgradeMechanics : MonoBehaviour
{

    public TextMeshProUGUI UpgradeEngineText;
    public GameObject ButtonUpgradeEngine;
    public static int Enginelevel = 1;
  



    public void Start()
    {
       //PlayerPrefs.DeleteAll();
        if (PlayerPrefs.HasKey("UpgradeEngine"))
        {
            Enginelevel = PlayerPrefs.GetInt("UpgradeEngine");
        }
        if (PlayerPrefs.HasKey("UpgradeTransmission"))
        {
            Transmissionlevel = PlayerPrefs.GetInt("UpgradeTransmission");
        }
        if (PlayerPrefs.HasKey("UpgradeWheels"))
        {
            Wheelslevel = PlayerPrefs.GetInt("UpgradeWheels");
        }
        if (PlayerPrefs.HasKey("UpgradeBody"))
        {
            Bodylevel = PlayerPrefs.GetInt("UpgradeBody");
        }
        if (PlayerPrefs.HasKey("UpgradeTankFuel"))
        {
            TankFuellevel = PlayerPrefs.GetInt("UpgradeTankFuel");
        }

        Debug.Log(Enginelevel);
        Debug.Log(PlayerPrefs.GetInt("UpgradeEngine"));


    }
    public void Update()
    {

        if (Enginelevel <= 4)
        {
            if (PlayerPrefs.HasKey("UpgradeEngine"))
            {

                UpgradeEngineText.text = "Уровень: " + PlayerPrefs.GetInt("UpgradeEngine");
            }
            else
            {
                UpgradeEngineText.text = "Уровень: " + 1;
            }

        }
        else
        {
            ButtonUpgradeEngine.GetComponent<Button>().interactable = false;
            UpgradeEngineText.text = "Максимум";
        }
        if (Transmissionlevel <= 4)
        {
            if (PlayerPrefs.HasKey("UpgradeTransmission"))
            {

                UpgradeTransmissionText.text = "Уровень: " + PlayerPrefs.GetInt("UpgradeTransmission");
            }
            else
            {
                UpgradeTransmissionText.text = "Уровень: " + 1;
            }

        }
        else
        {
            ButtonUpgradeTransmission.GetComponent<Button>().interactable = false;
            UpgradeTransmissionText.text = "Максимум";
        }
        if (Wheelslevel <= 4)
        {
            if (PlayerPrefs.HasKey("UpgradeWheels"))
            {

                UpgradeWheelsText.text = "Уровень: " + PlayerPrefs.GetInt("UpgradeWheels");
            }
            else
            {
                UpgradeWheelsText.text = "Уровень: " + 1;
            }

        }
        else
        {
            ButtonUpgradeWheels.GetComponent<Button>().interactable = false;
            UpgradeWheelsText.text = "Максимум";
        }
        if (Bodylevel <= 4)
        {
            if (PlayerPrefs.HasKey("UpgradeBody"))
            {

                UpgradeBodyText.text = "Уровень: " + PlayerPrefs.GetInt("UpgradeBody");
            }
            else
            {
                UpgradeBodyText.text = "Уровень: " + 1;
            }

        }
        else
        {
            ButtonUpgradeBody.GetComponent<Button>().interactable = false;
            UpgradeBodyText.text = "Максимум";
        }
        if (TankFuellevel <= 4)
        {
            if (PlayerPrefs.HasKey("UpgradeTankFuel"))
            {

                UpgradeTankFuelText.text = "Уровень: " + PlayerPrefs.GetInt("UpgradeTankFuel");
            }
            else
            {
                UpgradeTankFuelText.text = "Уровень: " + 1;
            }

        }
        else
        {
            ButtonUpgradeTankFuel.GetComponent<Button>().interactable = false;
            UpgradeTankFuelText.text = "Максимум";
        }
    }
    public void UpgradeEngine()
    {
        Enginelevel++;
        PlayerPrefs.SetInt("UpgradeEngine", Enginelevel);

    }

    public TextMeshProUGUI UpgradeTransmissionText;
    public GameObject ButtonUpgradeTransmission;
    private int Transmissionlevel = 1;

    public void UpgradeTransmission()
    {

        Transmissionlevel++;
        PlayerPrefs.SetInt("UpgradeTransmission", Transmissionlevel);


    }

    public TextMeshProUGUI UpgradeWheelsText;
    public GameObject ButtonUpgradeWheels;
    private int Wheelslevel = 1;

    public void UpgradeWheels()
    {
      
            Wheelslevel++;
        PlayerPrefs.SetInt("UpgradeWheels", Wheelslevel);

    }

    public TextMeshProUGUI UpgradeBodyText;
    public GameObject ButtonUpgradeBody;
    private int Bodylevel = 1;

    public void UpgradeBody()
    {
        
            Bodylevel++;
        PlayerPrefs.SetInt("UpgradeBody", Bodylevel);

    }

    public TextMeshProUGUI UpgradeTankFuelText;
    public GameObject ButtonUpgradeTankFuel;
    private int TankFuellevel = 1;

    public void UpgradeTankFuel()
    {
     

            TankFuellevel++;
        PlayerPrefs.SetInt("UpgradeTankFuel", TankFuellevel);

    }
}