using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Car : MonoBehaviour
{
    
    [SerializeField]
    private float speed;

    [SerializeField]
    private float initalSpeed = 300;
    [SerializeField]
    private float maxSpeed= 2000;
    [SerializeField]
    private float accel= 50;
    [SerializeField]
    private float brakesPower= 150;

    [SerializeField]
    private float gasTank=100;
    public bool engineOn = false;
    public bool brakesOn = false;

    [SerializeField]
    WheelJoint2D backWheel;
    [SerializeField]
    WheelJoint2D frontWheel;
     //[Header("Button Settings")]
    [Tooltip("accel, brakes, friction,deaccel")]
    [SerializeField]
    List<float> intervals= new List<float>(4); //accel brakes friction deaccel

    Rigidbody2D carBody;

    public float Speed { get => speed; set => speed = value; }

    public float InitalSpeed { get => initalSpeed; set => initalSpeed = value; }
    public float MaxSpeed { get => maxSpeed; set => maxSpeed = value; }
    public float Accel { get => accel; set => accel = value; }
    public WheelJoint2D BackWheel { get => backWheel; set => backWheel = value; }
    public WheelJoint2D FrontWheel { get => frontWheel; set => frontWheel = value; }
    public Rigidbody2D CarBody { get => carBody; set => carBody = value; }
    public List<float> Intervals { get => intervals; set => intervals = value; }
    public float GasTank { get => gasTank; set => gasTank = value; }
    public float BrakesPower { get => brakesPower; set => brakesPower = value; }

    public Car()
    {
    
    }
    
}
