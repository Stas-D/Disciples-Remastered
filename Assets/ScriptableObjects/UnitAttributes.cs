using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HeroAttributes", menuName = "Fighter")]
public class UnitAttributes : ScriptableObject
{
    [Header("Default Attributes")]
    public float initiative;
    public int hp;
    public int atack;
    public int resistance;

    [Header("General Attributes")]
    public bool isRanger;
    public Sprite heroSprite;
    public Hero heroSO;
    public bool isDeployed;
    public bool block;
    public bool isPoisoned;

    [Header("Current Attributes")]
    float initiativeCurrent;
    public float InitiativeCurrent
    {
        get { return initiativeCurrent; }
        set { initiativeCurrent = value; }
    }
    int hpCurrent;
    public int HPCurrent
    {
        get { return hpCurrent; }
        set { hpCurrent = value; }
    }
    int atackCurrent;
    public int AtackCurrent
    {
        get { return atackCurrent; }
        set { atackCurrent = value; }
    }
    int resistanceCurrent;
    public int ResistanceCurrent
    {
        get { return resistanceCurrent; }
        set { resistanceCurrent = value; }
    }
     public void SetCurrentAttributes()//at the beginning of the battle sets the default values
    {
        hpCurrent = hp;
        atackCurrent = atack;
        resistanceCurrent = resistance;
        initiativeCurrent = initiative;
    }
}
