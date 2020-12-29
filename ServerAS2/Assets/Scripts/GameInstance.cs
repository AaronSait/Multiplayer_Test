using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstance : MonoBehaviour
{
    public static GameInstance instance = null;

    public int chosenCar = 0;
    public float moterPower;
    public float Mass;
    void Awake()
    {
        // this is checking to see if there is curently an instanc of theis scriped and if not it creates one
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
        // Use this for initialization
        void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        setCarStats();
	}

    void setCarStats()
    {
        switch (chosenCar)
        {
            case 0:
                {
                    moterPower = 30000;
                    Mass = 1000;
}
                break;
            case 1:
                {
                    moterPower = 40000;
                    Mass = 1500;
                }
                break;
        }
    }
}
