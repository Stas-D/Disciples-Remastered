using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCounter : MonoBehaviour
{
    int totalDamage;
    int targetHP;

    public int TargetHealth
    {
        get { return targetHP; }
        set 
        {
            if (value > 0) { targetHP = value; } //excludes negative variable value
            else { targetHP = 0; }
        }
    }
    int damagebyUnit;//damage done by unit
    int DamageByUnit
    {
        get { return damagebyUnit; }
        set //excludes negative variable value
        {
            if (value > 0) { damagebyUnit = value; }
            else { damagebyUnit = 1; } //sets the value to one if resistance is greater than attack
        }
    }
    //calculates the HP after the attack
    internal int CountTargetHealth(Hero currentAtacker, Hero target)
    {
        totalDamage = CountDamageDealt(currentAtacker, target); //assigns the damage dealt to the variable
        TargetHealth = target.heroData.hp - totalDamage;
        return TargetHealth;
    }
    //calculates the damage done by one unit
    private int CountDamageDealt(Hero currentAtacker, Hero target)
    {       
        if (target.heroData.block)   //damage when Hero is bloking
        {
            int blockedAttack = (int)(currentAtacker.heroData.AtackCurrent / 2);
            DamageByUnit = blockedAttack - target.heroData.ResistanceCurrent;
            target.heroData.block=false;
            target.GetComponent<Animator>().SetTrigger("IsBloked");
            print("ATTACK IS BLOKED   DAMAGE IS " + DamageByUnit + "SHOULD BE " + currentAtacker.heroData.AtackCurrent);
        }
        else //damage when Hero is not bloking
        {
            DamageByUnit = currentAtacker.heroData.AtackCurrent - target.heroData.ResistanceCurrent;
        }
        return DamageByUnit;
    }      
}
