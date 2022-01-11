using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    BattleController battleController;
    public delegate void StartNewTurn();
    public static event StartNewTurn OnNewTurn;
    public delegate void StartNewRound();
    public static event StartNewRound OnNewRound;
    [SerializeField] GameObject gameOverPanel; 

    private void Start()
    {
        battleController = GetComponent<BattleController>();
        //a new turn is initialized by pressing the start button
        StartBTN.OnStartingBattle += InitializeNewTurn;
    }
    public void InitializeNewTurn()
    {
        battleController.CleanField();
        battleController.DefineNewAtacker();//finds an attacking hero
        Hero currentAtacker = BattleController.currentAtacker;
        GetStartingPlace();
        List<Hero> allFighters = battleController.DefineAllFighters();
        CheckForPoison(allFighters);
        currentAtacker.DefineTargets();
        if (currentAtacker.GetComponent<Enemy>() == null)//checks if it is a player’s turn
        {
            currentAtacker.PlayersTurn();//player starts his turn 
            battleController.SetActiveBlockButton();
        }
        else
        {
            currentAtacker.GetComponent<Enemy>().Aisturnbegins();
        }
    }
    private void GetStartingPlace()
    {
        BattlePlace startingPlace = BattleController.currentAtacker.GetComponentInParent<BattlePlace>();
        startingPlace.DefineMeAsStartingPlace(); //changes the properties of the starting place
    }
    public void TurnIsCompleted()
    {
        battleController.CleanField();
        StartCoroutine(NextTurnOrGameOver());
    }
    public IEnumerator NextTurnOrGameOver()
    {
        WaitForSeconds wait = new WaitForSeconds(2f);//pause length
        yield return wait;
        battleController.events.gameObject.SetActive(true); //enables click response
        List<Hero> allFighters = battleController.DefineAllFighters();
        if (IfThereIsAI(allFighters) && IfThereIsPlayer(allFighters))
        {
            NextTurnOrNextRound(allFighters);
        }
        else
        {
            print("GAME OVER");
            battleController.CleanField();//clearing the battlefield from frames and numbers
            gameOverPanel.SetActive(true);
            RemoveAllHeroes(allFighters);
        }
    }
    private void RemoveAllHeroes(List<Hero> allFighters)//remove all heroes from the battlefield
    {
        foreach (Hero hero in allFighters)
        {
            Destroy(hero.gameObject);//remove every hero left on the battlefield
        }
    }
    bool IfThereIsAI(List<Hero> allFighters)
    {
        return allFighters.Exists(x => x.gameObject.GetComponent<Enemy>());
    }
    bool IfThereIsPlayer(List<Hero> allFighters)
    {
        return allFighters.Exists(x => x.gameObject.GetComponent<Player>());
    }
    private void NextTurnOrNextRound(List<Hero> allFighters)
    {
        if (allFighters.Exists(x => x.heroData.initiative > 0))
        {
            print("NEXT TURN");
            InitializeNewTurn();
        }
        else
        {
            OnNewRound();
            print("NEXT ROUND");
            InitializeNewTurn();
        }
    }
    public void CheckForPoison(List<Hero> allFighters)
    {
        foreach (Hero hero in allFighters)
        {
            hero.health.PoisonCheck();
        }
    }
}
