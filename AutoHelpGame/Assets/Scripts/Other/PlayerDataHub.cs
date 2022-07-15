using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataHub : MonoBehaviour
{
    public static PlayerDataHub instance;
    public CarLoadList carLoadList;
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
        carLoadList = Instantiate(carLoadList);
        carLoadList.Reload();
    }
}

