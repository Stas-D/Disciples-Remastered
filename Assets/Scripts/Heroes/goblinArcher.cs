using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblinArcher : Hero
{
     [SerializeField] Arrow arrow;
     [SerializeField] internal Vector3 initialPosCorrection;//adjusts arrow position
    IAttacking dealsDamage = new SimpleMeleeAttack();//simple attack behavior reference
    public override void DealsDamage(BattlePlace target)
    {
        dealsDamage.HeroIsDealingDamage(this, BattleController.currentTarget);
    }
    public override void DefineTargets()
    {
        IDefineTarget wayToLookForTargets = new TargetPlayerRange(); //range targets behavior reference
        wayToLookForTargets.DefineTargets(this);
    }
    public override void HeroIsAtacking()//starts the attack
    {
        base.HeroIsAtacking();
        GetComponent<Animator>().SetTrigger("isAttackingRange");
        InstantiateArrow();
    }
     private void InstantiateArrow()//instantiates an arrow
    {
        //position where the arrow will appear
        Vector3 positionForArrow = new Vector3(transform.position.x,transform.position.y + initialPosCorrection.y, transform.position.z);                                
        Quaternion rotation = new Quaternion(); ;//determines the angle of rotation for the arrow
        Arrow Arrow = Instantiate(arrow, positionForArrow, rotation, transform);//instantiates an arrow object
        Arrow.FireArrow(dealsDamage);
    }
}
