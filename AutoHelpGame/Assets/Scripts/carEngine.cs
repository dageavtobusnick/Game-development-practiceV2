using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class carEngine : Car
{
 
    float direction;
    private float accelTime;
    private float frictionTime;
    private float deaccelTime;

    private Vector3 stopLocation ;

    bool stopped = false;

    //boost
    void Awake()
    {
        accelTime = Intervals[0];
        frictionTime = Intervals[1];
        deaccelTime = Intervals[2];
        CarBody = this.GetComponent<Rigidbody2D>();
        stopLocation = this.transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        InitalSpeed = Speed;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(CarBody.velocity);
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
        else if (brakesOn && CarBody.velocity.x<0.1f)
        {
            stopLocation= this.transform.position;
            CarBody.velocity=Vector2.zero;
            CarBody.angularVelocity=0;
            if (!stopped)
            {
                this.transform.position = stopLocation;
            }
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
        }
        else
        {
           BackWheel.useMotor=false;
           FrontWheel.useMotor=false;
        }
       
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

   }
    public void BrakesTurnOn()
   {    
        brakesOn=!brakesOn;
        stopped = false;
        if(!brakesOn)
        {
            stopped=true;
        }
   }
}
