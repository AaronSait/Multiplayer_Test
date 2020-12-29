using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSpher : NetworkBehaviour
{
	// Use this for initialization
	void Start ()
    {
		
	}	
	// Update is called once per frame
	void Update ()
    {
		if(hasAuthority)
        {
            if (Input.GetKeyUp(KeyCode.E))
                CmdDestroy();
        }
	}

    [Command]
    public void CmdDestroy()
    {
        NetworkServer.Destroy(this.gameObject);
    }
}
