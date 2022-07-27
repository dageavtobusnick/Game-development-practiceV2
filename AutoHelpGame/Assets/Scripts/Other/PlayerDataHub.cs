using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using static PlayerData;

public class PlayerDataHub : MonoBehaviour
{
    public static PlayerDataHub instance;
    public CarLoadList CarLoadList;
    public BonusLoadList BonusLoadList;
    public PlayerData PlayerData;
    public event Action SaveDeleted;
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
        PlayerData = Instantiate(PlayerData);
        PlayerData.ReloadCarData();
        SaveDeleted += FindObjectOfType<MenuManager>().LoadMainMenu;
        if(_loadOnAwake)
            Load();
        Save();
    }
    public async void Save()
    {
        var saveData= await Task.Run(()=>PlayerData.Save());
        var bf = new BinaryFormatter();
        var dataPath = Application.persistentDataPath;
        await Task.Run(()=>Directory.CreateDirectory(dataPath+_savePath));
        try
        {
            using (var fs = File.Create(dataPath + _savePathName))
            {
                await Task.Run(() => bf.Serialize(fs, saveData));
            }
            Debug.Log("DataSaved");
        }
        finally
        {

        }
    }
    public void DeleteSave()
    {;
        var dataPath = Application.persistentDataPath;
        try
        {
            if (File.Exists(dataPath + _savePathName))
            {
                File.Delete(dataPath + _savePathName);
                Debug.Log("DataDeleted");
                instance = null;
                SaveDeleted?.Invoke();
                Destroy(gameObject);
            }
        }
        finally
        {

        }
    }
    public void Load()
    {
        var bf = new BinaryFormatter();
        var dataPath = Application.persistentDataPath;
        try
        {
            if (File.Exists(dataPath + _savePathName))
            {
                using (var fs = File.Open(dataPath + _savePathName, FileMode.Open))
                {
                    var data = (PlayerSaveData)bf.Deserialize(fs);
                    PlayerData.LoadData(data);
                }
                Debug.Log("DataLoaded");
            }
        }
        finally
        {

        }
       
    }
}

