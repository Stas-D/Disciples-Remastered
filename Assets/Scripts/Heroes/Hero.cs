using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hero : MonoBehaviour
{
    public BattlePlace parentPlace;
    public UnitAttributes heroData;
    StartBTN startBTN;
    public Health health;
    BattleController battleController;
    Turn turn;
    private void Awake()
    {
        heroData.SetCurrentAttributes();//loads the current characteristics of the hero from SO
        battleController = FindObjectOfType<BattleController>();
        turn = FindObjectOfType<Turn>();
    }
    private void Start()
    {
        StorageMNG.OnClickOnGrayIcon += DestroyMe; //subscribes the DestroyMe method to an OnRemoveHero event
        startBTN = FindObjectOfType<StartBTN>();
        health = GetComponentInChildren<Health>();
        Turn.OnNewRound += SetInitiative;
        parentPlace = GetComponentInParent<BattlePlace>();
        SetInitiative();
    }
    public abstract void DealsDamage(BattlePlace target);

    private void DestroyMe(UnitAttributes SOofHero)//destroys this object
    {
        if (SOofHero == heroData)// compares the player’s choice with the hero
        {
            startBTN.ControlStartBTN();//checks if it's time to hide the Start button
            Destroy(gameObject);
        }
    }
    void OnDisable()//It is activated when the object is destroyed or disabled
    {
        StorageMNG.OnClickOnGrayIcon -= DestroyMe;//unsubscribes from notifications
    }
    public abstract void DefineTargets();
    public virtual void HeroIsAtacking()//starts an attack
    {
        battleController.SetDisableBlockButton();
    }
    public void PlayersTurn()
    {
        DefineTargets();//displays potencial targets
    }
    public void HeroIsKilled()
    {
        Turn.OnNewRound -= SetInitiative;
        battleController.RemoveHeroWhenItIsKilled(this);
    }
    public void SetInitiative() // set random attack order using initiative
    {
        if (GetComponent<Enemy>() == null)
        {
            heroData.initiative = Random.Range(1, 10);
        }
        else
        {
            heroData.initiative = Random.Range(11, 20);
        }
    }
}
