using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LVSelvection : NetworkBehaviour
{
    public GameObject menu;
    GameObject nMHolder;
    NetworkManager nM;

    bool LevleOne, LevelTwo, Back;
	// Use this for initialization
	void Start ()
    {
        LevleOne = false;
        LevelTwo = false;
        Back = false;

        nMHolder = GameObject.Find("GameMaster");
        nM = nMHolder.gameObject.GetComponent<NetworkManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isLocalPlayer)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                menu.SetActive(!menu.activeInHierarchy);
            }
            if (LevleOne)
            {
                CmdLoadLevel("SampleScene");
            }
            if (LevelTwo)
            {
                CmdLoadLevel("LevleTwo");
            }
            if (Back)
            {
                menu.SetActive(false);
                Back = false;
            }
        }
    }
    public void LevleOneBtn()
    {
        if (isLocalPlayer)
        {
            Debug.Log("L1");
            LevleOne = true;
        }
    }
    public void LevelTwoBtn()
    {
        if (isLocalPlayer)
        {
            Debug.Log("L2");
            LevelTwo = true;
        }
    }
    public void BackBtn()
    {
        if (isLocalPlayer)
        {
            Debug.Log("BACK");
            Back = true;
        }
    }
    [Command]
    void CmdLoadLevel(string level)
    {
        nM.ServerChangeScene(level);
    }
}
