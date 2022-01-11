using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattlePlace : MonoBehaviour
{
    public bool potencialTarget; //helps identify potential targets
    public ClickOnMe clickOnMe;
    public DeploymentPos deploymentPos;
    public bool isStartingPlace = false;
    [SerializeField] private GameObject image;

    private void Awake()
    {
        clickOnMe = GetComponent<ClickOnMe>();
    }
    internal void DefineMeAsPotencialTarget() //defines place as a potential target for attack
    {
        deploymentPos.GetComponent<Image>().color = new Color32(255, 63, 53, 255);
        potencialTarget = true;
    }
    public void DefineMeAsStartingPlace()
    {
        isStartingPlace = true;     
    }
    public void MakeMeDeploymentPosition()//displays the place as a potential for the hero
    {
        deploymentPos.GetComponent<Image>().color = new Color32(255, 63, 53, 255);//displays a checkmark
    }
    public void CleanUpDeploymentPosition()
    {
        deploymentPos.GetComponent<Image>().color = new Color32(255, 63, 53, 0);//hides a checkmark
    }
    public void MyMoove()
    {
        deploymentPos.MarkIsActive();
    }
    public void CleanMyMoove()
    {
        deploymentPos.MarkIsDisable();
    }
}
