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
	private int Enginelevel=1;
	
    public void UpgradeEngine()
    {
		if (Enginelevel<=4){
			Enginelevel++;
			UpgradeEngineText.text = "Уровень: " + Enginelevel;
			
		}
		else
		{
			ButtonUpgradeEngine.GetComponent<Button>().interactable = false;
			UpgradeEngineText.text = "Максимум";
		}
    }
	
	public TextMeshProUGUI UpgradeTransmissionText;
	public GameObject ButtonUpgradeTransmission;
	private int Transmissionlevel=1;
	
	public void UpgradeTransmission()
    {
		if (Transmissionlevel<=4){
			Transmissionlevel++;
			UpgradeTransmissionText.text = "Уровень: " + Transmissionlevel;
			
		}
		else
		{
			ButtonUpgradeTransmission.GetComponent<Button>().interactable = false;
			UpgradeTransmissionText.text = "Максимум";
		}
    }
	
	public TextMeshProUGUI UpgradeWheelsText;
	public GameObject ButtonUpgradeWheels;
	private int Wheelslevel=1;
	
	public void UpgradeWheels()
    {
		if (Wheelslevel<=4){
			Wheelslevel++;
			UpgradeWheelsText.text = "Уровень: " + Wheelslevel;
			
		}
		else
		{
			ButtonUpgradeWheels.GetComponent<Button>().interactable = false;
			UpgradeWheelsText.text = "Максимум";
		}
    }
	
	public TextMeshProUGUI UpgradeBodyText;
	public GameObject ButtonUpgradeBody;
	private int Bodylevel=1;
	
	public void UpgradeBody()
    {
		if (Bodylevel<=4){
			Bodylevel++;
			UpgradeBodyText.text = "Уровень: " + Bodylevel;
			
		}
		else
		{
			ButtonUpgradeBody.GetComponent<Button>().interactable = false;
			UpgradeBodyText.text = "Максимум";
		}
    }
	
	public TextMeshProUGUI UpgradeTankFuelText;
	public GameObject ButtonUpgradeTankFuel;
	private int TankFuellevel=1;
   
   public void UpgradeTankFuel()
    {
		if (TankFuellevel<=4){
			TankFuellevel++;
			UpgradeTankFuelText.text = "Уровень: " + TankFuellevel;
			
		}
		else
		{
			ButtonUpgradeTankFuel.GetComponent<Button>().interactable = false;
			UpgradeTankFuelText.text = "Максимум";
		}
    }
}