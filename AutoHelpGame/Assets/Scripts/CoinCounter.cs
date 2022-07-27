using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    private  TextMeshProUGUI _textMeshProUGUI;
    private bool _isReadyToDestroy=true;
    private int _localCoins;

    public int LocalCoins { get => _localCoins; }

    void Start()
    {
        _textMeshProUGUI= GetComponent<TextMeshProUGUI>();
        if (PlayerDataHub.instance != null)
        {
            PlayerDataHub.instance.PlayerData.CoinsCountChanged += UpdageCoinsInfo;
            LockDestroy();
            _textMeshProUGUI.text = PlayerDataHub.instance.PlayerData.CoinsCount.ToString();
        }
        //when lvl ends add all of them to coins
    }

    public void GetValueCoins()
    {
        Debug.Log("COPY");
        _textMeshProUGUI.text=PlayerPrefs.GetInt("levelCoins").ToString();
    }
    public void CollectLocalCoins(int count)
    {
        _localCoins += count;
    }
    public void UpdageCoinsInfo(int coinsCount)
    {
        Debug.Log("COPY");
        _textMeshProUGUI.text=$"{coinsCount}";
    }
    private void OnDestroy()
    {
        if (!_isReadyToDestroy)
        {
            PlayerDataHub.instance.PlayerData.CoinsCountChanged -= UpdageCoinsInfo;
            _isReadyToDestroy=true;
        }
    }
    public void LockDestroy()
    {
        _isReadyToDestroy=false;
    }
}
