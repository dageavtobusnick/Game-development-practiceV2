using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class carEngine : Car
{
 
    float direction;
    private float accelTime;
    private float frictionTime;
    private float deaccelTime;
    private float consumeTime;
    

    [SerializeField]
    Rigidbody2D backWheelBody;
    [SerializeField]
    Rigidbody2D frontWheelBody;

   
    //boost
    void Awake()
    {
        accelTime = Intervals[0];
        frictionTime = Intervals[1];
        deaccelTime = Intervals[2];
        consumeTime = Intervals[3];
        CarBody = this.GetComponent<Rigidbody2D>();
        FuelBar =  GameObject.FindWithTag("FuelBar").GetComponent<Slider>();
        /*if(PlayerDataHub.instance == null)
            CarData = PlayerDataHub.instance.PlayerData.TotalCar;*/
    }
    // Start is called before the first frame update
    void Start()
    {
        InitalSpeed = Speed;
       backWheelBody.drag=15f;
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(CarBody.velocity);
        AccelAndDeaccel();

        if (frictionTime > 0 && !engineOn)
        {
            frictionTime -= Time.deltaTime;
        }
        else if (frictionTime < 0 && !engineOn)
        {
            frictionTime += Intervals[1];
            if (CarBody.velocity.x >= 3)
            {
                CarBody.velocity = new Vector2(CarBody.velocity.x - 3f, CarBody.velocity.y-3f);
            }
            else if (CarBody.velocity.x < 0.5f)
            {
                CarBody.velocity = new Vector2(0, 0); //stop all movement
                Speed = InitalSpeed;
            }
        }

        if( brakesOn && CarBody.velocity.x>3f)
        {
            Debug.Log("brake");
            CarBody.velocity = new Vector2(CarBody.velocity.x - 3f, CarBody.velocity.y-3f);
          
        }
        else if (brakesOn && CarBody.velocity.x<0.1f && CarBody.velocity.y<0.7f)
        {
            backWheelBody.drag=15f;
            frontWheelBody.drag=15f;
        }
        else if (CarBody.velocity.y<0.7f )
        {
           backWheelBody.drag=2f;
           frontWheelBody.drag=2f;
        }
        else if (CarBody.velocity.y>1f)
        {
            backWheelBody.drag=0f;
            frontWheelBody.drag=0f;
        }

    }

    private void AccelAndDeaccel()
    {
        if (accelTime > 0 && engineOn)
        {
            accelTime -= Time.deltaTime;
        }
        else if (accelTime <= 0 && engineOn)
        {
            accelTime += Intervals[0];
            if (Speed < MaxSpeed)
            {
                Speed += Accel;
            }
        }
        else if (accelTime < Intervals[0] && !engineOn)
        {
            accelTime = Intervals[0];
        }

        if (deaccelTime > 0 && !engineOn)
        {
            deaccelTime -= Time.deltaTime;
        }
        else if (accelTime <= 0 && !engineOn)
        {
            deaccelTime += Intervals[2];
            if (Speed < MaxSpeed)
            {
                Speed -= Accel / 2;
            }
        }
        else if (accelTime < Intervals[2] && engineOn)
        {
            deaccelTime = Intervals[2];
        }

    }

    void FixedUpdate()
    {
        if(engineOn)
        {        
           BackWheel.useMotor=true;
           FrontWheel.useMotor=true;
           JointMotor2D motor = new JointMotor2D{motorSpeed = Speed*direction , maxMotorTorque = 10000};
           BackWheel.motor=motor;
           FrontWheel.motor=motor;
          
           
            if (consumeTime > 0 )
            {
                consumeTime -= Time.deltaTime;
            }
            else
            {
                FuelTank-= FuelConsume*100;
              
               
                consumeTime+=Intervals[3];
            }
        }
        else
        {
           BackWheel.useMotor=false;
           FrontWheel.useMotor=false;
        }
        if(FuelTank<=0)
        {
            GameObject.FindWithTag("DeathMenu").transform.GetChild (0).gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
         FuelBar.value = FuelTank/FuelMaxTank;
    }
   public void EngineTurnOn(bool forward)
   {    
        engineOn=!engineOn;
        if(forward)
        {
            direction=1;
        }
        else
        {
            direction=-1;
        }
        if(engineOn == false)
        {
            consumeTime = Intervals[3];
        }

   }
    public void BrakesTurnOn()
   {    
        brakesOn=!brakesOn;
   }
}
