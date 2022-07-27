using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LootBoxBuyController : MonoBehaviour
{
    [SerializeField]
    private Button _buy1Button;
    [SerializeField]
    private Button _buy5Button;
    [SerializeField]
    private Button _buy10Button;
    [SerializeField]
    private TextMeshProUGUI _buy1Text;
    [SerializeField]
    private TextMeshProUGUI _buy5Text;
    [SerializeField]
    private TextMeshProUGUI _buy10Text;
    private void OnEnable()
    {
        UpdateFullInfo();
    }

    public void UpdateFullInfo()
    {
        UpdateInfo(_buy1Button, _buy1Text, 1);
        UpdateInfo(_buy5Button, _buy5Text, 5);
        UpdateInfo(_buy10Button, _buy10Text, 10);
    }

    public void UpdateInfo(Button button, TextMeshProUGUI text,int lootboxCount)
    {
        var playerData = PlayerDataHub.instance.PlayerData;

        if (playerData.LootboxCost*lootboxCount <= playerData.CoinsCount)
        {
            button.interactable = true;
            text.text = $"Купить {lootboxCount} колес{((lootboxCount==1)?"o":"")}";
        }
        else
        {
            button.interactable = false;
            text.text = "Дорого";
        }

    }
}
