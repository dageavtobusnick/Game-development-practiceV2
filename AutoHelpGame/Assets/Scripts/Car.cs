using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Car : MonoBehaviour
{
    #region Specs
    [SerializeField]
    private float speed;
    [SerializeField]
    private float initalSpeed = 300;
    [SerializeField]
    private float fuelTank=100;
    [SerializeField]
    private CarData carData;
#endregion
    
    [SerializeField]
    Slider fuelBar;

    public bool engineOn = false;
    public bool brakesOn = false;

    #region Body
    Rigidbody2D carBody;
    [SerializeField]
    WheelJoint2D backWheel;
    [SerializeField]
    WheelJoint2D frontWheel;
#endregion
    
     //[Header("Button Settings")]
    [Tooltip("accel, brakes, friction,deaccel")]
    [SerializeField]
    List<float> intervals= new List<float>(4); //accel friction deaccel

    #region SPECS GET SET
    public float Speed { get => speed; set => speed = value; }
    public float InitalSpeed { get => initalSpeed; set => initalSpeed = value; }
    public float MaxSpeed { get => carData.MaxSpeed; }
    public float Accel { get => carData.Accel;}
    public float BrakesPower { get => carData.BrakesPower; }
    #endregion

    #region BODY GET SET
    public WheelJoint2D BackWheel { get => backWheel; set => backWheel = value; }
    public WheelJoint2D FrontWheel { get => frontWheel; set => frontWheel = value; }
    public Rigidbody2D CarBody { get => carBody; set => carBody = value; }
    public List<float> Intervals { get => intervals; set => intervals = value; }
    #endregion

    #region GAS GET SET
    public float FuelTank { get => fuelTank; set => fuelTank = value; }
    public float FuelMaxTank { get => carData.FuelTankMax; }
    public float FuelConsume { get => carData.FuelConsume/(100*100); }
    public Slider FuelBar { get => fuelBar; set => fuelBar = value; }
    public CarData CarData { get => carData; protected set => carData = value; }
    #endregion

}
