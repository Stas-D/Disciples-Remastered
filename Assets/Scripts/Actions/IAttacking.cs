using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttacking 
{
    void HeroIsDealingDamage(Hero atacker, Hero Target); // to choose a method of dealing damage
}
