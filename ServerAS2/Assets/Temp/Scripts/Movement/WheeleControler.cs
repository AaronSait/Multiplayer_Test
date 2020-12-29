using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WheeleControler : MonoBehaviour {
    public Transform[] wheels;
    public float moterPower, instantPower, wheelTurn, Break;
    public float MaxTurn;
    bool finish = false;
    Rigidbody RB;
    public AudioClip Moving;
    public AudioClip Breaking;
    void Start ()
    {
		//This is setting the center of mass on the car
		//so the car is more stable in turns
        RB = gameObject.GetComponent<Rigidbody>();
        RB.centerOfMass = new Vector3(0, -0.5f, 0.3f);	
	}
    void Update()
    {
		//in the update we trigger the relevant sounds by calling a method called palysounds
        PlaySound();
    }
//the play sounds method send the sound controller the relevant sounds to be played
    void PlaySound()
    {
		//in this if statement we are checking to see if the car is moving
		// and if it is then we are passing the engine nose to the sound controller to be played
        if (instantPower != 0.0f)
        {
            SoundController.instance.playEffectEngin(Moving);
        }
		//in this if statement we are checking to see if the car is breaking
		// and if it is then we are passing the braking nose to the sound controller to be played
        if (Break > 0.0f)
        {
            SoundController.instance.playEffectBrakes(Breaking);
        }
    }
    void FixedUpdate ()
    {
		//the fixed update calls all methods associated with movement
        GetInputs();
        TurnWheeles();
        ApplyPower();
    }
//the get inputs method reads the users inputs and sets values for the relevant input
    void GetInputs()
    {
		// if any of the vertical keys are pressed then the instant power is assigned
        instantPower = Input.GetAxis("Vertical") * moterPower * Time.deltaTime;
		// if any of the horizontal keys are pressed then the turn rate of the wheeles is assigned
        wheelTurn = Input.GetAxis("Horizontal") * MaxTurn;
		// if the spacebar are pressed then the the breaking power is equal to the mass else the braking power equals 0
        Break = Input.GetKey(KeyCode.Space) ? RB.mass : 0.0f;
    }
//in the Turn Wheels method the cosmetic for the wheeals are made and the turning of the car is processed
    void TurnWheeles()
    {
        //turn collider
		//this turns the colliders by the value stored in wheelturn so the car can move round corners
        getCollider(0).steerAngle = wheelTurn;
        getCollider(1).steerAngle = wheelTurn;
		//this is the asthetic for the two lines above these lines rotate the object the colliders are attached to
		//and rotates them by the same amount as the colliders
        wheels[0].localEulerAngles = new Vector3(wheels[0].localEulerAngles.x, getCollider(0).steerAngle , wheels[0].localEulerAngles.z);
        wheels[1].localEulerAngles = new Vector3(wheels[1].localEulerAngles.x, getCollider(1).steerAngle, wheels[1].localEulerAngles.z);

        //spin Wheeles
		//these lines of code rotate the wheeles so if the car was seen form a side angel the wheeles will be seeming to be rolling along the ground
        wheels[0].Rotate(0, 0, -getCollider(3).rpm / 60 * 360 * Time.deltaTime);
        wheels[1].Rotate(0, 0, -getCollider(3).rpm / 60 * 360 * Time.deltaTime);
        wheels[2].Rotate(0, 0, -getCollider(3).rpm / 60 * 360 * Time.deltaTime);
        wheels[3].Rotate(0, 0, -getCollider(3).rpm / 60 * 360 * Time.deltaTime);
    }	
    void ApplyPower()
    {
        //breaks
		//if the brakes are being applyed then set the brakeTorque to the current break power
        if (Break > 0.0f)
        {
            getCollider(0).brakeTorque = Break;
            getCollider(1).brakeTorque = Break;
            getCollider(2).brakeTorque = Break;
            getCollider(3).brakeTorque = Break;
        }
		//if the breaks are not being applied then set the brakeTorque to zero on each wheel and set the 
		//motorTorque to the current value of instantPower
        else
        {
            getCollider(0).brakeTorque = 0.0f;
            getCollider(1).brakeTorque = 0.0f;
            getCollider(2).brakeTorque = 0.0f;
            getCollider(3).brakeTorque = 0.0f;
            getCollider(0).motorTorque = instantPower;
            getCollider(1).motorTorque = instantPower;
            getCollider(2).motorTorque = instantPower;
            getCollider(3).motorTorque = instantPower;
        }
    }
	//this method is getting the coliders form the objects 
    WheelCollider getCollider(int n)
    {
        return wheels[n].gameObject.GetComponent<WheelCollider>();
    }
//this method is checking to see if the car has hit an object
    private void OnTriggerEnter(Collider other)
    {
		//this if  checks the tag of the object it hit
        if (other.tag == "StartFinish" && finish)
        {
			//if the  object was the start/finish line then the getTime method in the other object is called
            other.gameObject.GetComponent<Timer>().GetTime();            
        }
        else if (other.tag == "HarthWay")
        {
			// if the other object was taged with harthway then the boolean finish is set to true
            finish = true;
        }
        else if (other.tag == "Ground")
        {
			//if the tage of the other object is ground the level is reloaded
            int scene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }
    }
}
