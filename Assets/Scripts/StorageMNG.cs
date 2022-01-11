using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorageMNG : MonoBehaviour
{
    [SerializeField] internal CurrentProgress currentProgress;
    [SerializeField] FighterIcon iconPrefab;
    List<UnitAttributes> unitIcons = new List<UnitAttributes>();
    ScrollRect scrollRect;
    // sprites  for the background
    [SerializeField] internal Sprite selectedIcon;
    [SerializeField] internal Sprite defaultIcon;
    [SerializeField] internal Sprite deployedFighter;
    public static event Action<UnitAttributes> OnRemoveHero;//event when a player removes a hero
    public delegate void DeleteHero(UnitAttributes SOofHero);
    public static event DeleteHero OnClickOnGrayIcon;
    public FighterIcon[] fighterIcons;//collects all icons

    void Start()
    {
        scrollRect = GetComponent<ScrollRect>();
        CallHeroIcons();
        //binds the DisableME method to the clocking on starting button
        StartBTN.OnStartingBattle += DisableMe;
        fighterIcons = GetComponentsInChildren<FighterIcon>();//collects all icons
    }
    private void CallHeroIcons()//places heroes icons in storage
    {
        unitIcons = currentProgress.heroesOfPlayer;//access to player's units
        Transform parentOfIcons = scrollRect.content.transform;//defines the parent object for all icons
        for (int i = 0; i < unitIcons.Count; i++)
        {
            FighterIcon fighterIcon = Instantiate(iconPrefab, parentOfIcons);//instantiate and return an icon
            fighterIcon.unitAttributes = unitIcons[i];//assigns scriptable object to an icon
            fighterIcon.FillIcon();//fills the icon with a sprite and the number of units.
        }
    }
    internal void TintIcon(FighterIcon clickedIcon)//marks a unit to be placed on the battlefield
    {
        FighterIcon[] fighterIcons = GetComponentsInChildren<FighterIcon>();//collects all icons
        foreach (FighterIcon icon in fighterIcons)
        {
            if (!icon.deployed)
                icon.backGround.sprite = defaultIcon;//sets default background to the icon
        }
        clickedIcon.backGround.sprite = selectedIcon;//sets green background to the icon
        Deployer.readyForDeploymentIcon = clickedIcon;//Saves the selected icon in memory
    }
    public void RemoveFighter(UnitAttributes SOHero)//calls OnRemoveHero event
    {
        OnClickOnGrayIcon(SOHero);
    }
    private void DisableMe()//disables the storage
    {
        gameObject.SetActive(false);
    }
}