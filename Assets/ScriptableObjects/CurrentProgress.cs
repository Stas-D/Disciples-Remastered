﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CurrentProgress", menuName = "CurrentProgress/Bar")]
public class CurrentProgress : ScriptableObject
{
    [SerializeField] internal List<UnitAttributes> heroesOfPlayer;
    [SerializeField] internal List<UnitAttributes> enemies;
}
