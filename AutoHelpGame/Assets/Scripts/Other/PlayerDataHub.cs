using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataHub : MonoBehaviour
{
    public static PlayerDataHub instance;
    public CarLoadList CarLoadList;
    public PlayerData PlayerData;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        CarLoadList = Instantiate(CarLoadList);
        CarLoadList.ReloadData();
        PlayerData = Instantiate(PlayerData);
        PlayerData.ReloadCarData();
        foreach(var counter in FindObjectsOfType<CoinCounter>())
        {
            PlayerData.CoinsCountChanged += counter.UpdageCoinsInfo;
        }
    }
}

