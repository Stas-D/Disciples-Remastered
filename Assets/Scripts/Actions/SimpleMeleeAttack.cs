using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMeleeAttack : MonoBehaviour, IAttacking
{
    DamageCounter damageController = new DamageCounter();//access to damage calculation
    int targetHealth;//final HP after the attack
    public void HeroIsDealingDamage(Hero atacker, Hero Target)
    {
        //calculates the final HP of the attacked hero
        targetHealth = damageController.CountTargetHealth(atacker, Target);
        Target.GetComponent<Animator>().SetTrigger("IsTakingDamage");
        Target.heroData.hp = targetHealth;
        Target.health.DisplayCurrentHealth();
        print("Damaged and updated");
    }

}
