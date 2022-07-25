using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using UnityEngine;
using static PlayerData;

public class PlayerDataHub : MonoBehaviour
{
    public static PlayerDataHub instance;
    public CarLoadList CarLoadList;
    public BonusLoadList BonusLoadList;
    public PlayerData PlayerData;
    [SerializeField]
    private bool _loadOnAwake;
    private static readonly string _savePath= "/Saves"; 
    private static readonly string _savePathName= "/Saves/SaveData.sav";
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
            counter.LockDestroy();
        }
        if(_loadOnAwake)
            Load();
    }
    public async void Save()
    {
        var saveData= await Task.Run(()=>PlayerData.Save());
        var bf = new BinaryFormatter();
        var dataPath = Application.persistentDataPath;
        await Task.Run(()=>Directory.CreateDirectory(dataPath+_savePath));
        using (var fs = File.Open(dataPath + _savePathName, FileMode.Create))
        {
            await Task.Run(() => bf.Serialize(fs, saveData));
        }
        Debug.Log("DataSaved");
    }
    public void Load()
    {
        var bf = new BinaryFormatter();
        var dataPath = Application.persistentDataPath;
        try
        {
            using (var fs = File.Open(dataPath + _savePathName, FileMode.Open))
            {
                var data=(PlayerSaveData) bf.Deserialize(fs);
                PlayerData.LoadData(data);
            }
            Debug.Log("DataLoaded");
        }
        finally
        {

        }
       
    }
}

