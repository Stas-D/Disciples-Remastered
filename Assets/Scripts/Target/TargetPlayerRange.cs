using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPlayerRange : MonoBehaviour, IDefineTarget
{
    public void DefineTargets(Hero currentAtacker)
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
