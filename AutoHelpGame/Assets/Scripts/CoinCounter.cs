using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    // Start is called before the first frame update
    private TextMeshProUGUI _textMeshProUGUI;
    private bool _isReadyToDestroy=true;
    void Start()
    {
        PlayerPrefs.SetInt("levelCoins",0);
        _textMeshProUGUI= GetComponent<TextMeshProUGUI>();
        _textMeshProUGUI.text = PlayerPrefs.GetInt("levelCoins").ToString();
        //when lvl ends add all of them to coins
    }

    public void GetValueCoins()
    {
        Debug.Log("COPY");
        _textMeshProUGUI.text=PlayerPrefs.GetInt("levelCoins").ToString();
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
