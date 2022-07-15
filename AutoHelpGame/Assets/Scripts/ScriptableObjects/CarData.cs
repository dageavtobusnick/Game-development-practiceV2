using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Car",menuName ="Configs/Cars")]
public class CarData : ScriptableObject
{
    [SerializeField]
    private static List<CarData> carDataList; 
    [SerializeField]
    private int _id;
    [SerializeField]
    private float _maxSpeed = 2000;
    [SerializeField]
    private float _accel = 50;
    [SerializeField]
    private float _brakesPower = 150;
    [SerializeField]
    private float _fuelTankMax = 100;
    [SerializeField]
    private float _fuelConsume = 100;
    [SerializeField]
    private int _carMaxHP = 100;
    [SerializeField]
    private CarcassUpgrade _carcassUpgrade; 
    [SerializeField]
    private EngineUpgrade _engineUpgrade; 
    [SerializeField]
    private FuelTankUpgrade _fuelTankUpgrade; 
    [SerializeField]
    private TransmissionUpgrade _transmissionUpgrade; 
    [SerializeField]
    private WheelsUpgrade _wheelsUpgrade;
    private int _carHP = 100;
    private int _fuelTank = 100;
    private CarData _clearData;

    #region GET
    public float MaxSpeed { get => _maxSpeed; }
    public float Accel { get => _accel; }
    public float BrakesPower { get => _brakesPower; }
    public float FuelTank { get => _fuelTank; }
    public float FuelConsume { get => _fuelConsume; }
    public float CarMaxHP { get => _carMaxHP; }
    public int CarHP { get => _carHP; }
    public float FuelTankMax { get => _fuelTankMax; }
    public CarcassUpgrade CarcassUpdate { get => _carcassUpgrade; }
    public EngineUpgrade EngineUpdate { get => _engineUpgrade; }
    public FuelTankUpgrade FuelTankUpdate { get => _fuelTankUpgrade; }
    public TransmissionUpgrade TransmissionUpdate { get => _transmissionUpgrade; }
    public WheelsUpgrade WheelsUpdate { get => _wheelsUpgrade; }
    public int Id { get => _id; }
    #endregion


    public void CheckClearData()
    {
        if (_clearData == null)
        {
            _clearData = PlayerDataHub.instance.carLoadList.CopyCarData(Id);
        }
    }

    public int UpdateCarcass()
    {
        CheckClearData();
        _carcassUpgrade = _carcassUpgrade.Next;
        _carHP = CountValue(_clearData.CarHP,_carcassUpgrade.CountSummaryBoost());
        return _carcassUpgrade.Cost;
    }
    public int UpgradeEngine()
    {
        CheckClearData();
        _engineUpgrade = _engineUpgrade.Next;
        _accel = CountValue(_clearData.Accel,_engineUpgrade.CountSummaryAccelBoost());
        _fuelConsume= CountValue(_clearData.FuelConsume,-_engineUpgrade.CountSummaryConsumeBoost());
        return _engineUpgrade.Cost;
    }
    public int UpgradeFuelTank()
    {
        CheckClearData();
        _fuelTankUpgrade = _fuelTankUpgrade.Next;
        _fuelTankMax = CountValue(_clearData.FuelTankMax,_fuelTankUpgrade.CountSummaryBoost());
        return _fuelTankUpgrade.Cost;
    }
    public int UpgradeTransmission()
    {
        CheckClearData();
        _transmissionUpgrade = _transmissionUpgrade.Next;
        _maxSpeed = CountValue(_clearData.MaxSpeed,_transmissionUpgrade.CountSummaryBoost());
        return _transmissionUpgrade.Cost;
    }
    public int UpgradeWheels()
    {
        CheckClearData();
        _wheelsUpgrade = _wheelsUpgrade.Next;
        _brakesPower = CountValue(_clearData.BrakesPower, _wheelsUpgrade.CountSummaryBoost());
        return _wheelsUpgrade.Cost;
    }
    public void UpdateHP(int hp)
    {
        _carHP = hp;
    }
    private static int CountValue(float value,float boost)
    {
        return (int)Mathf.Round(value * (1 +boost));
    }
}
