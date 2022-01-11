using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FighterIcon : MonoBehaviour
{
    [SerializeField] internal Image heroImage;//stores a child object with a hero's sprite
    [SerializeField] internal Image backGround;//stores a child object with a background sprite
    [SerializeField] internal UnitAttributes unitAttributes;//access to hero data
    internal bool deployed = false;//evaluates if the unit is already on the battlefield

    StorageMNG storage;
    private void Start()
    {
        storage = GetComponentInParent<StorageMNG>();
        StorageMNG.OnClickOnGrayIcon += ReturnDefaultState; //subscribes the ReturnDefaultState method to an OnRemoveHero event
    }
    internal void FillIcon()
    {
        heroImage.sprite = unitAttributes.heroSprite;
    }
    public void IconClicked()//responds to a click on a button
    {
        StorageMNG storage = GetComponentInParent<StorageMNG>();
        if (!deployed)//evaluates if the unit is already on the battlefield
        {
            storage.TintIcon(this);//marks a regiment to be placed on the battlefield
        }
        else
        {
            storage.RemoveFighter(unitAttributes);
        }
    }
    public void HeroIsDeployed()
    {
        backGround.sprite = storage.deployedFighter;
        deployed = true;
    }
    public void ReturnDefaultState(UnitAttributes selectedUnitAttributes)//sets green background to the icon
    {
        if (selectedUnitAttributes == unitAttributes)
        {
            backGround.sprite = GetComponentInParent<StorageMNG>().defaultIcon; 
            deployed = false;//defines the hero as available for deployment
        }
    }
}
