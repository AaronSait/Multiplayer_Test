using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CamraControll : MonoBehaviour {
//this script keeps the camera the same dissidence away form the player object
    public GameObject player;
    private Vector3 offset;
    void Start()
    {		
        offset = transform.position - player.transform.position;
    }
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
