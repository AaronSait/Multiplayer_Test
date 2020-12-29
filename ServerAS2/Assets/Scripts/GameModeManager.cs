using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
public class GameModeManager : NetworkBehaviour
{
    /*
     *      we need a var for seeing if a current gamemode is compleat
     *      
     *      we need a timer form 60 seconds to 120 seconds to start a game mode
     *      
     *      we need a refrence to the type of game mode
     */

    float timer, tagT;
    public bool currentlyInAGameMode;
    public bool CoinCollection, Tag;
    public GameObject coinsObj;
    int Gamemodechosen;
    public GameObject goldSpawn;
	// Use this for initialization
	void Start ()
    {
        currentlyInAGameMode = false;
        CoinCollection = false;
        Tag = false;
        timer = Random.Range(10, 15);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!currentlyInAGameMode)
        {
            if (timer <= 0)
            {
                Gamemodechosen = Random.Range(0, 2);
                if (Gamemodechosen == 1)
                {
                    Tag = true;
                    tagT = 20f;
                    CoinCollection = false;
                    coinsObj.SetActive(false);
                    currentlyInAGameMode = true;
                    GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");
                    for (int i = 0; i < Players.Length; i++)
                    {
                        Debug.Log(i + "           " + Players.Length);
                        Players[i].GetComponent<Player>().Tag = true;
                        Players[i].GetComponent<Player>().CoinCollection = false;
                    }
                    selectIt();

                }
                else if (Gamemodechosen == 0)
                {
                    CoinCollection = true;
                    Tag = false;
                    coinsObj.SetActive(true);
                    currentlyInAGameMode = true;
                    CmdSpawn();
                    GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");
                    for (int i = 0; i < Players.Length; i++)
                    {
                        Debug.Log(i + "           " + Players.Length);
                        Players[i].GetComponent<Player>().Tag = false;
                        Players[i].GetComponent<Player>().CoinCollection = true;
                    }
                }

                timer = Random.Range(10, 15);
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
        else
        {
            if (CoinCollection)
                CheckCoinColectionIsOver();
            else
                tagTimer();
        }
		
	}

    void tagTimer()
    {
        if (tagT <= 0)
        {
            currentlyInAGameMode = false;
            GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");
            for (int i = 0; i < Players.Length; i++)
            {
                Debug.Log(i + "           " + Players.Length);
                Players[i].GetComponent<Player>().Tag = false;
                Players[i].GetComponent<Player>().CoinCollection = false;
            }
        }
        else
        {

            Debug.Log("Tag");
            GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");
            Debug.Log(Players.Length);
            for (int j = 0; j < Players.Length; j++)
            {
                Players[j].GetComponent<Player>().t = tagT;
            }
            tagT -= Time.deltaTime;
        }
    }
    void CheckCoinColectionIsOver()
    {
        int totalCoins =0;
        GameObject [] coins = GameObject.FindGameObjectsWithTag("GOLD");

        if (coins.Length == 0)
        {
            currentlyInAGameMode = false;
            GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");
            for (int j = 0; j < Players.Length; j++)
            {
                Debug.Log(j + "           " + Players.Length);
                Players[j].GetComponent<Player>().Tag = false;
                Players[j].GetComponent<Player>().CoinCollection = false;
                if (totalCoins < Players[j].GetComponent<Player>().coins)
                    totalCoins = Players[j].GetComponent<Player>().coins;
            }
        }        
    }
    void selectIt()
    {
        GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");

        int playerit;

        playerit = Random.Range(0, Players.Length);
        Players[playerit].GetComponent<Player>().it = true;

    }




    [Command]
    public void CmdSpawn()
    {
        GameObject gold = (GameObject)Instantiate(coinsObj, goldSpawn.transform.position, Quaternion.identity);
        NetworkServer.Spawn(gold);

    }

}
