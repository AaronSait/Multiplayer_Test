using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatScript : MonoBehaviour
{
	// Update is called once per frame
	void Update ()
    {
        float translation = Time.deltaTime * 10;
        transform.Rotate(0, translation, 0 );
    }
}
