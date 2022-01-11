using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeploymentPos : MonoBehaviour
{
    BattlePlace parentPlace;
    public GameObject mark;
    void Start()
    {
        parentPlace = GetComponentInParent<BattlePlace>();//finds the parent place
        mark = this.gameObject.transform.GetChild(0).gameObject;
        StartBTN.OnStartingBattle += DisableMe;
    }
    public void OnMouseDown()//is executed when the user has pressed the mouse button while over the Collider.
    {
        if (Deployer.readyForDeploymentIcon != null)
        {
            Deployer.DeployRegiment(parentPlace);//deploys a unit
        }
    }
    void DisableMe()
    {
        parentPlace.CleanUpDeploymentPosition();
    }
  public void MarkIsActive()//displays mark for the active hero
    {
        mark.SetActive(true);
    }
    public void MarkIsDisable()//hides mark for the active hero
    {
        mark.SetActive(false);
    }
}
