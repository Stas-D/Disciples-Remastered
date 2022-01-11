using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartBTN : MonoBehaviour
{
    public delegate void StartsBattle();
    public static event StartsBattle OnStartingBattle;
    [SerializeField] Button startBTN;   //stores the Start Button Object
    StorageMNG storage;
    [SerializeField] int minimumHeroesNum; //minimum set of units to activate the battle

    private void Start()
    {
        storage = GetComponent<StorageMNG>();
        OnStartingBattle += ControlStartBTN;
        startBTN.gameObject.SetActive(false);//disables the Start button before the deployment 
    }
    public void StartBattle()//the method is executed when the start button is pressed
    {
        OnStartingBattle();//calls delegate
    }
    public void ControlStartBTN()//enables and disables the start button
    {
        int deployedReg = GetGrayIcons(); //the number of units deployed

        //compares the number of units on the battlefield with the minimum number required
        if (deployedReg >= minimumHeroesNum)
        {
            startBTN.gameObject.SetActive(true);// enables  the start button
        }
        else
        {
            startBTN.gameObject.SetActive(false);// disables the start button
        }
    }
    int GetGrayIcons()//counts the number of units deployed on the battlefield
    {
        int grayIcons = 0;//start with zero in case of multiple use of the method
        foreach (FighterIcon icon in storage.fighterIcons)//all icons are stored in storage class
        {
            if (icon.deployed)
            {
                grayIcons++;//adds one to the number if the unit is deployed
            }
        }
        return grayIcons;
    }
}
