using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Deployer : MonoBehaviour
{
    public static FighterIcon readyForDeploymentIcon;//stores information about the icon that the player clicked on
    List<BattlePlace> enemiesPositions = new List<BattlePlace>();//stores places to deploy enemies
    List<UnitAttributes> enemiesToDeploy = new List<UnitAttributes>();// stores enemies' scriptable objects
    static StorageMNG storage;
    int enemiesNum;// to count the number of enemy objects 

    void Start()
    {
        storage = FindObjectOfType<StorageMNG>();
        enemiesToDeploy = storage.currentProgress.enemies;//fill the list with enemies' scriptable objects
        enemiesNum = enemiesToDeploy.Count();//count the number of enemy units
        PlaceEnemies();//places enemy units on the battlefield
    }
    //DeployRegiment method instantiates the hero on the battlefield
    public static void DeployRegiment(BattlePlace parentObject)//hero appears on parentObject
    {
        Hero myHero = readyForDeploymentIcon.unitAttributes.heroSO;// gets the hero prefab
        Hero fighter = Instantiate(myHero, parentObject.transform);

        parentObject.CleanUpDeploymentPosition();//hides the checkmark and disables the collider
        readyForDeploymentIcon.HeroIsDeployed();//marks the icon in gray
        readyForDeploymentIcon = null;//clears a variable to prevent the hero from reappearing
        storage.GetComponent<StartBTN>().ControlStartBTN();//enables the start button
    }
    internal List<BattlePlace> GetEnemiesPos()//returns a list with places for enemies
    {
        enemiesPositions.Clear();//clean the list before a new iteration
        foreach (BattlePlace place in FieldManager.allEnemyPlacesArray)
        {
            enemiesPositions.Add(place);
        }
        return enemiesPositions;
    }
    private void PlaceEnemies()//places enemy units on the battlefield
    {
        List<BattlePlace> enemiesPositions = GetEnemiesPos();//collects all positions for enemies
        for (int i = 0; i < enemiesNum; i++)//use loop in order to exclude occupied positions
        {
            int positionsNum = enemiesPositions.Count();//updates the number of unoccupied positions
            int randomIndex = UnityEngine.Random.Range(0, positionsNum - 1);//returns a random number as an element of the list
            BattlePlace place = enemiesPositions[randomIndex];
            Transform spot = place.transform;
            InstantiateEnemy(enemiesToDeploy[i], spot);//instantiates an enemy
            //prohibits re-occupying the place
            enemiesPositions.RemoveAt(randomIndex);
        }
    }
    private void InstantiateEnemy(UnitAttributes unitAttributes, Transform hexPosition)
    {
        Hero enemy = Instantiate(unitAttributes.heroSO, hexPosition.transform);//instantiates an enemy
        enemy.gameObject.AddComponent<Enemy>();//adds Enemy script to a hero object defined as an enemy
    }
}
