using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    List<BattlePlace> allTargets = new List<BattlePlace>();//the variable is used to sort player's units
    List<BattlePlace> targetsToAttack = new List<BattlePlace>();//collects player units able to attack 
    Hero hero;
    private void Start()
    {
        hero = GetComponent<Hero>();
    }
    public void Aisturnbegins()
    {
        hero.DefineTargets();
        //starts looking for all player's units
        CollectAllTargets();
        AISelectsTargetToAttack();
        AIMakesDecision();
    }
    List<BattlePlace> CollectAllTargets()
    {
        foreach (BattlePlace place in FieldManager.allPlacesArray)
        {
            if (place.GetComponentInChildren<Player>() != null)
            {
                allTargets.Add(place);
            }
        }
        return allTargets;
    }
    public BattlePlace AISelectsTargetToAttack()//selects a target for attack
    {
        allTargets.Clear();//clear the list 
        allTargets = CollectAllTargets().OrderBy(hero => hero.GetComponentInChildren<Hero>().heroData.HPCurrent).ToList();                     
        // the AI can choose the weakest fighter to attack
        int i = UnityEngine.Random.Range(0, allTargets.Count); // the AI choose random fighter to attack
        print("CHOOOOSE " + i);
        BattleController.currentTarget = allTargets[i].GetComponentInChildren<Hero>();
        return allTargets[i];
    }
    void AIMakesDecision()//the AI attack 
    {
        BattlePlace targetToAttack = AISelectsTargetToAttack();//assigns a priority target for attack      
        hero.HeroIsAtacking();
    }
}
