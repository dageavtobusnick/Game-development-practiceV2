using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RepairScript : MonoBehaviour
{   [SerializeField]
    private Button _fullRepairButton;
    [SerializeField]
    private Button _partRepairButton;
    [SerializeField]
    private TextMeshProUGUI _fullRepairText;
    [SerializeField]
    private TextMeshProUGUI _partRepairText;
    public void UpdateInfo(){
        var playerData = PlayerDataHub.instance.PlayerData;
        if (playerData.TotalCar.CarHP<playerData.TotalCar.CarMaxHP)
        {
            if (playerData.PartRepairCost <= playerData.CoinsCount)
            {
                _partRepairButton.interactable = true;
                _partRepairText.text = "Частичная починка";
            }
            else
            {
                _partRepairButton.interactable = false;
                _partRepairText.text = "Дорого";
            }
            if (playerData.FullRepairCost <= playerData.CoinsCount)
            {
                _fullRepairButton.interactable = true;
                _fullRepairText.text = "Полная починка";
            }
            else
            {
                _fullRepairButton.interactable = false;
                _fullRepairText.text = "Дорого";
            }
        }
        else
        {
            _fullRepairButton.interactable = false;
            _partRepairButton.interactable = false;
            _fullRepairText.text = "Не требуется";
            _partRepairText.text = "Не требуется";
        }
    }
    void Start()
    {
        UpdateInfo();
    }
    private void OnEnable()
    {
        UpdateInfo();
    }
    private void Awake()
    {
        UpdateInfo();
    }
    public void FullRepair()
    {
        PlayerDataHub.instance.PlayerData.FullRepair();
        UpdateInfo();
    }
    public void PartRepair()
    {
        PlayerDataHub.instance.PlayerData.PartRepair();
        UpdateInfo();
    }

}

