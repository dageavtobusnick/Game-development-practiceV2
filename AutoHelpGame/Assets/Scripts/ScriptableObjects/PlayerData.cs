using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Bonus;
using static CarData;

[CreateAssetMenu(fileName = "Player", menuName = "Configs/Player")]
public class PlayerData : ScriptableObject
{
    [Serializable]
    public readonly struct PlayerSaveData
    {
        public readonly int CoinsCount;
        public readonly int LootboxCount;
        public readonly CarSaveData[] Cars;
        public readonly BonusSaveData[] Bonuses;

        public PlayerSaveData(int coinsCount, int lootboxCount, CarSaveData[] cars, BonusSaveData[] bonuses)
        {
            CoinsCount = coinsCount;
            LootboxCount = lootboxCount;
            Cars = cars;
            Bonuses = bonuses;
        }
    }


    [SerializeField]
    private int _coinsCount;
    [SerializeField]
    private int _lootBoxCount;
    [SerializeField]
    private int _fullRepairCost;
    [SerializeField]
    private int _partRepairCost;
    [SerializeField]
    private int _lootboxCost;
    [SerializeField]
    private List<CarData> _cars;
    [SerializeField]
    [HideInInspector]
    private HashSet<Bonus> _bonuses=new HashSet<Bonus>();
    [SerializeField]
    private CarData _totalCar;

    public int CoinsCount { get => _coinsCount; }
    public int LootBoxCount { get => _lootBoxCount; }
    public CarData TotalCar { get => _totalCar; }
    public int FullRepairCost { get => _fullRepairCost; }
    public int PartRepairCost { get => _partRepairCost; }
    public int LootboxCost { get => _lootboxCost; }

    public event Action<int> CoinsCountChanged;

    public void AddLootBoxes(int count) 
    { 
        _lootBoxCount += count;
        _coinsCount -= _lootboxCost*count;
        CoinsCountChanged?.Invoke(_coinsCount);
        PlayerDataHub.instance.Save();
    }
    public void SpinWheel()
    {
        _lootBoxCount--;
        PlayerDataHub.instance.Save();
    }
    public void AddCoins(int count)
    {
        _coinsCount += count;
        CoinsCountChanged?.Invoke(CoinsCount);
        PlayerDataHub.instance.Save();
    }
    public void AddBonus(int Id)
    {
        var bonus=PlayerDataHub.instance.BonusLoadList.CopyBonusData(Id);
        while (_bonuses.Contains(bonus))
        {
            bonus.RegenUniqueID();
        }
        _bonuses.Add(bonus);
    }
    public void SelectCar(int index)
    {
        _totalCar= _cars[index];
    }

    public void PayPenalty(int value)
    {
        _coinsCount -= value;
        CoinsCountChanged?.Invoke(CoinsCount);
        PlayerDataHub.instance.Save();
    }

    public void ReloadCarData()
    {
        _cars=_cars.Select(x=>Instantiate(x)).ToList();
        _totalCar = _cars?[0];
    }

    public IEnumerable<CarData> GetCars()
    {
        return _cars;
    }
    public void FullRepair()
    {
        _totalCar.Repair();
        _coinsCount -= _fullRepairCost;
        CoinsCountChanged?.Invoke(CoinsCount);
    }
    public void PartRepair()
    {
        _totalCar.PartRepair();
        _coinsCount -= _partRepairCost;
        CoinsCountChanged?.Invoke(CoinsCount);

    }
    public PlayerSaveData Save()
    {
        return new PlayerSaveData(CoinsCount,LootBoxCount,_cars.Select(x=>x.SaveData()).ToArray(),_bonuses?.Select(x=>x.SaveData()).ToArray());
    }
    public void LoadData(PlayerSaveData saveData)
    {
        _coinsCount= saveData.CoinsCount;
        _lootBoxCount = saveData.LootboxCount;
        _bonuses = saveData.Bonuses?.Select(x =>PlayerDataHub.instance.BonusLoadList.CopyBonusData(x.Id).LoadData(x)).ToHashSet();
        _cars = saveData.Cars?.Select(x => PlayerDataHub.instance.CarLoadList.CopyCarData(x.Id).LoadData(x)).ToList();
        _totalCar= _cars?[0];
    }
    public void Upgrade(UpgradeType type)
    {
        switch (type)
        {
            case UpgradeType.Engine:
                _coinsCount-= _totalCar.UpgradeEngine();
                break;
            case UpgradeType.Transmission:
                _coinsCount-= _totalCar.UpgradeTransmission();
                break;
            case UpgradeType.HP:
                _coinsCount-= _totalCar.UpgradeCarcass();
                break;
            case UpgradeType.FuelTank:
                _coinsCount-= _totalCar.UpgradeFuelTank();
                break;
            case UpgradeType.Wheels:
                _coinsCount-= _totalCar.UpgradeWheels();
                break;

        }
        CoinsCountChanged?.Invoke(CoinsCount);
        PlayerDataHub.instance.Save();
    }    
}
