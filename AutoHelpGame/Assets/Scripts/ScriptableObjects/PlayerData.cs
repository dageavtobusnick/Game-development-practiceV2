using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Configs/Player")]
public class PlayerData : ScriptableObject
{
    [SerializeField]
    private int _coinsCount;
    [SerializeField]
    private int _lootBoxCount;
    [SerializeField]
    private List<CarData> _cars;
    [SerializeField]
    [HideInInspector]
    private HashSet<Bonus> _bonuses;
    [SerializeField]
    private CarData _totalCar;

    public int CoinsCount { get => _coinsCount; }
    public int LootBoxCount { get => _lootBoxCount; }
    public CarData TotalCar { get => _totalCar; }

    public void AddLootBoxes(int count) => _lootBoxCount += count;
    public void AddCoins(int count) => _coinsCount += count;

    
    public void SelectCar(int index)
    {
        _totalCar= _cars[index];
    }

    public IEnumerable<CarData> GetCars()
    {
        return _cars;
    }

    public void Upgrade(UpgradeType type)
    {
        switch (type)
        {
            case UpgradeType.Engine:
                _coinsCount+= _totalCar.UpgradeEngine();
                break;
            case UpgradeType.Transmission:
                _coinsCount+= _totalCar.UpgradeTransmission();
                break;
            case UpgradeType.HP:
                _coinsCount+= _totalCar.UpdateCarcass();
                break;
            case UpgradeType.FuelTank:
                _coinsCount+= _totalCar.UpgradeFuelTank();
                break;
            case UpgradeType.Wheels:
                _coinsCount+= _totalCar.UpgradeWheels();
                break;

        }
    }    
}
