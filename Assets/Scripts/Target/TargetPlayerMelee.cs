using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPlayerMelee : MonoBehaviour, IDefineTarget
{
    bool row1IsEmpty;
    public void DefineTargets(Hero currentAtacker)
    {
        row1IsEmpty = true;
        foreach (BattlePlace place in FieldManager.enemyRow_1)
        {
            if (place.GetComponentInChildren<Enemy>() != null)
            {
                place.DefineMeAsPotencialTarget();//mark potential target
                row1IsEmpty = false;
            }         
        }
        if (row1IsEmpty) {DefineTargetsRange(currentAtacker);print("MAKE ROW2 AVAILABLE");}
    }
    public void DefineTargetsRange(Hero currentAtacker)
    {
        foreach (BattlePlace place in FieldManager.allEnemyPlacesArray)
        {
            if (place.GetComponentInChildren<Enemy>() != null)
            {
                place.DefineMeAsPotencialTarget();//mark potential target
            }

        }
    }
}
