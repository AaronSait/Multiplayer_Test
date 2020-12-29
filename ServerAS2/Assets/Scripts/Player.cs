using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Player : NetworkBehaviour
{

    public GameObject[] wheels;
    public GameObject[] wheelsObj;
    public float moterPower, instantPower, wheelTurn, Break;
    public float MaxTurn;
    Text coinstxt, tagTime, gameMode;
    Text win;

    GameObject tagPan, coinPan;

    [SyncVar]
    GameObject CurrentCar;

    [SyncVar]
    public float t = 0;

    [SyncVar]
    public int carChosen;
    public GameObject[] cars;

    Rigidbody RB;


    public GameObject playerSpear;
    public GameObject pCam;
    private bool hitPlayer;

    // GameMode Vars
    public bool it;
    public int coins;

    [SyncVar]
    public bool CoinCollection, Tag;
    void CheckOtherPlayer()
    {
        if (GameObject.FindGameObjectsWithTag("Player") != null)
        {
            
            GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");
            Debug.Log(Players.Length);
            for (int i = 0; i < Players.Length; i++)
            {
                CmdSetParent(Players[i].GetComponent<Player>().CurrentCar, Players[i]);
            }
        }
    }


    // Use this for initialization	
    void Start ()
    {
        if (isLocalPlayer)
        {
            Debug.Log(GameInstance.instance.chosenCar);
            carChosen = GameInstance.instance.chosenCar;
            CmdSpawn(carChosen);

            coinstxt = this. transform.GetChild(2).transform.GetChild(1).transform.GetChild(1).gameObject.GetComponent<Text>();
            tagTime = this.transform.GetChild(2).transform.GetChild(0).transform.GetChild(1).gameObject.GetComponent<Text>();
            gameMode = this.transform.GetChild(2).transform.GetChild(2).transform.GetChild(1).gameObject.GetComponent<Text>();
            win = this.transform.GetChild(2).transform.GetChild(2).transform.GetChild(2).gameObject.GetComponent<Text>();

            tagPan = this.transform.GetChild(2).transform.GetChild(0).gameObject;
            coinPan = this.transform.GetChild(2).transform.GetChild(1).gameObject;


            pCam.SetActive(true);
            if (GameObject.Find("Camera") != null)
                GameObject.Find("Camera").SetActive(false);
            moterPower = GameInstance.instance.moterPower;
            RB = gameObject.GetComponent<Rigidbody>();
            RB.mass = GameInstance.instance.Mass;
            RB.centerOfMass = new Vector3(0, -0.5f, 0); ;
        }
        else
            pCam.SetActive(false);

        //This is setting the center of mass on the car
        //so the car is more stable in turns
        
    }
    // Update is called once per frame
    void Update ()
    {
        if (isLocalPlayer)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                transform.transform.position = new Vector3(transform.transform.position.x, transform.transform.position.y + .5f, transform.transform.position.z);
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
            }
            CheckOtherPlayer();
            GetInputs();
            TurnWheeles();
            ApplyPower();
            if (Tag)
            {
                tagPan.SetActive(true);
                coinPan.SetActive(false);
                gameMode.text = "Tag";
                win.text = "";
                tagTimeSet();
            }
            else if (CoinCollection)
            {
                tagPan.SetActive(false);
                coinPan.SetActive(true);
                gameMode.text = "Coin Collection";
                win.text = "";
            }
            else
            {

                gameMode.text = "";
                tagPan.SetActive(false);
                coinPan.SetActive(false);
            }
        }
    }
    void tagTimeSet()
    {
        tagTime = this.transform.GetChild(2).transform.GetChild(0).transform.GetChild(1).gameObject.GetComponent<Text>();
        tagTime.text = "" + t;
        Debug.Log("Changing room");
    }
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
        wheels[0].transform.localEulerAngles = new Vector3(wheels[0].transform.localEulerAngles.x, getCollider(0).steerAngle, wheels[0].transform.localEulerAngles.z);
        wheels[1].transform.localEulerAngles = new Vector3(wheels[1].transform.localEulerAngles.x, getCollider(1).steerAngle, wheels[1].transform.localEulerAngles.z);

        wheelsObj[0].transform.localEulerAngles = new Vector3(wheelsObj[0].transform.localEulerAngles.x, getCollider(0).steerAngle, wheelsObj[0].transform.localEulerAngles.z);
        wheelsObj[1].transform.localEulerAngles = new Vector3(wheelsObj[1].transform.localEulerAngles.x, getCollider(1).steerAngle, wheelsObj[1].transform.localEulerAngles.z);

        //spin Wheeles
        //these lines of code rotate the wheeles so if the car was seen form a side angel the wheeles will be seeming to be rolling along the ground
        wheels[0].transform.Rotate(0, 0, -getCollider(3).rpm / 60 * 360 * Time.deltaTime);
        wheels[1].transform.Rotate(0, 0, -getCollider(3).rpm / 60 * 360 * Time.deltaTime);
        wheels[2].transform.Rotate(0, 0, -getCollider(3).rpm / 60 * 360 * Time.deltaTime);
        wheels[3].transform.Rotate(0, 0, -getCollider(3).rpm / 60 * 360 * Time.deltaTime);
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
       // Debug.Log(n);
        return wheels[n].GetComponent<WheelCollider>();
    }
    //this method is checking to see if the car has hit an object

    private void OnCollisionEnter(Collision collision)
    {
        if (Tag)
        {

            Debug.Log("HIT SOMETHING");
            if (collision.gameObject.tag == "Player")
            {
                if (collision.gameObject.GetComponent<Player>().it || it)
                {
                    collision.gameObject.GetComponent<Player>().it = !collision.gameObject.GetComponent<Player>().it;
                    it = !it;
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (CoinCollection)
        {
            Debug.Log("Triggard SOMETHING");
            if (other.tag == "GOLD")
            {
                coins++;
                coinstxt = this.transform.GetChild(2).transform.GetChild(1).transform.GetChild(1).gameObject.GetComponent<Text>();
                coinstxt.text = "" + coins;
                CmdDestroy(other.gameObject);
                Destroy(other.gameObject);
            }
        }
    }

    [Command]
    public void CmdDestroy(GameObject other)
    {
        Network.Destroy(other);
        RpcDestroy(other);
    }
    [ClientRpc]
    void RpcDestroy(GameObject other)
    {
        Destroy(other);
    }
    [Command]
    public void CmdSetParent(GameObject car, GameObject ParentObj)
    {
        Debug.Log(car);
        if (car != null)
        {
            if (car.transform.parent != ParentObj)
            {
                car.transform.parent = ParentObj.transform;
                RpcSetParent(car, ParentObj);
            }
        }
    }

    [ClientRpc]
    void RpcSetParent(GameObject why, GameObject ParentObj)
    {
        why.transform.parent = ParentObj.transform;
    }

    [Command]
    public void CmdSpawn(int i)
    {
        GameObject Player = (GameObject)Instantiate(cars[i], transform.position, Quaternion.identity);
        Player.transform.eulerAngles = new Vector3(Player.transform.eulerAngles.x, Player.transform.eulerAngles.y - 90, Player.transform.eulerAngles.z);
        Player.transform.parent = this.gameObject.transform;
        Player.transform.position = new Vector3(0, 0, 0);
        if (i == 1)
            Player.transform.position = new Vector3(0, Player.transform.position.y + 0.45f, 0);
        
        NetworkServer.SpawnWithClientAuthority(Player, connectionToClient);
        CurrentCar = Player;
        RpcSpawn(Player);
    }

    [ClientRpc]
    void RpcSpawn(GameObject why)
    {
        why.transform.parent = this.gameObject.transform;
        why.transform.position = new Vector3(0, why.transform.position.y, 0);
    }
}
