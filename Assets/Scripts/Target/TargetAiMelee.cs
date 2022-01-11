using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAiMelee : MonoBehaviour, IDefineTarget
{
    public void DefineTargets(Hero currentAtacker)
    {
        foreach (BattlePlace place in FieldManager.playerRow_1)
        {
            if (place.GetComponentInChildren<Player>() != null)
            {
                place.DefineMeAsPotencialTarget();//mark potential target
            }
        }
    }
}
