using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    Hero parentHero;
    private int _health;
    public int poisonDamage = 5;
    Turn turn;
    public int poisonTurn;
    public Text textPoison;
    [SerializeField] Slider sliderHealth;
    internal int currentHealth
    {
        get { return _health; }
        set
        {
            if (value > 0) { _health = value; }//excludes negative values
            else { _health = 0; }
        }
    }
    void Start()
    {
        parentHero = GetComponentInParent<Hero>();
        turn = FindObjectOfType<Turn>();        
        DisplayStartHealth();
    }
    public void DisplayStartHealth()//takes the value of hp from the scriptable object
    {
        currentHealth = parentHero.heroData.hp;
        sliderHealth.maxValue = currentHealth;
        sliderHealth.value = currentHealth;      
    }
    public void DisplayCurrentHealth() 
    {     
        currentHealth = parentHero.heroData.hp;
        sliderHealth.value = currentHealth;
        CheckIfHeroIsKilled();
    }
    void CheckIfHeroIsKilled()
    {
        turn = FindObjectOfType<Turn>();
        if (parentHero.heroData.hp == 0)
        {
            parentHero.GetComponent<Animator>().SetTrigger("IsDead");
        }
        else
        {
            turn.TurnIsCompleted();
        }
    }
    public void PoisonCheck() //check if is hero poisoned
    {
        if (poisonTurn < 3)
        {
            if (parentHero.heroData.isPoisoned)
            {
                parentHero.heroData.hp = parentHero.heroData.hp - poisonDamage;
                sliderHealth.value = parentHero.heroData.hp;
                textPoison.text = $"Poison - {poisonDamage}";
                parentHero.GetComponent<Animator>().SetTrigger("IsPoisoned");
                poisonTurn++;
            }
        }
        else parentHero.heroData.isPoisoned = false;
    }
    public void PoisonStart()
    {
        poisonTurn = 0;
        parentHero.heroData.isPoisoned = true;
    }
}