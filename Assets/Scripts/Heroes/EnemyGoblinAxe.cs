﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGoblinAxe : Hero
{
    IAttacking dealsDamage = new SimpleMeleeAttack();//simple attack behavior reference
    public override void DealsDamage(BattlePlace target)
    {
        dealsDamage.HeroIsDealingDamage(this, BattleController.currentTarget);
    }
    public override void DefineTargets()
    {
        IDefineTarget wayToLookForTargets = new TargetAiMelee();
        wayToLookForTargets.DefineTargets(this);
    }
    public override void HeroIsAtacking()//starts the attack
    {
        GetComponent<Animator>().SetTrigger("isAttacking");
    }
}