using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIS : MonoBehaviour
{
    bool clickedLeft, ClickedRight;
    int car;
    public GameObject[] cars;
	// Use this for initialization
	void Start ()
    {
        clickedLeft = false;
        ClickedRight = false;

    }
	
	// Update is called once per frame
	void Update ()
    {
		if (clickedLeft)
        {
            if (car - 1 < 0)
                car = 1;
            else
                car -= 1;
            clickedLeft = false;
        }
        if (ClickedRight)
        {
            if (car + 1 > 1)
                car = 0;
            else
                car += 1;
            ClickedRight = false;
        }
        changeCar();
    }


    void changeCar()
    {
        switch (car)
        {
            case 0:
                {
                    cars[0].SetActive(true);
                    cars[1].SetActive(false);
                    GameInstance.instance.chosenCar = 0;
                }
                break;
            case 1:
                {
                    cars[1].SetActive(true);
                    cars[0].SetActive(false);
                    GameInstance.instance.chosenCar = 1;
                }
                break;
        }
    }
    public void Right()
    {
        ClickedRight = true;
    }

    public void Left()
    {
        clickedLeft = true;
    }
}
