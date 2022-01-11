using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class BattleController : MonoBehaviour
{
    public GameObject buttonBlock;
    public static Hero currentAtacker;
    public static Hero currentTarget; //Stores information about who is being attacked
    List<Hero> allFighters = new List<Hero>(); //collects all fighters placed on the battlefield
    Turn turn;
    public EventSystem events; //to disable click response
    private void Start()
    {
        turn = GetComponent<Turn>();
        events = FindObjectOfType<EventSystem>();
    }   
    public List<Hero> DefineAllFighters() //collects all fighters placed on the battlefield
    {
        allFighters = FindObjectsOfType<Hero>().ToList();
        return allFighters;
    }
    public void DefineNewAtacker()
    {
        //   sorts fighters by initiative value, in descending order
        List<Hero> allFighters = DefineAllFighters().OrderByDescending(hero => hero.heroData.initiative).ToList();                                
        //  the first element of the list has the biggest initiative value (for now it is random)
        currentAtacker = allFighters[0];
        currentAtacker.parentPlace.MyMoove();
        currentAtacker.heroData.initiative = 0;
    }
    public void CleanField()
    {
        foreach (BattlePlace place in FieldManager.allEnemyPlacesArray)
        {
            place.CleanUpDeploymentPosition();
            place.CleanMyMoove();
            place.potencialTarget = false;
        }
        foreach (BattlePlace place in FieldManager.allPlacesArray)
        {
            place.CleanUpDeploymentPosition();
            place.CleanMyMoove();
            place.potencialTarget = false;
        }
    }
    public void RemoveHeroWhenItIsKilled(Hero hero)
    {
        Destroy(hero.gameObject);
        turn.TurnIsCompleted();
    }
    public void SetBlockToFighter() //  sets blok to fighter for one turn
    {
        currentAtacker.heroData.block = true;
        currentAtacker.GetComponent<Animator>().SetTrigger("IsBloked");
        buttonBlock.SetActive(false);
        turn.TurnIsCompleted();
    }
    public void SetActiveBlockButton()
    {
        buttonBlock.SetActive(true);
    }
    public void SetDisableBlockButton()
    {
        buttonBlock.SetActive(false);
    }
}
