using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    public RowManager[] allRows;
    public static BattlePlace[,] allPlacesArray;// contains all Places in the BattleField
    public RowEnemyManager[] allEnemyRows;
    public static BattlePlace[,] allEnemyPlacesArray;
    [SerializeField] public BattlePlace[] enemyRow1;
    [SerializeField] public BattlePlace[] enemyRow2;
    public static BattlePlace[] enemyRow_1;
    public static BattlePlace[] enemyRow_2;
    [SerializeField] public BattlePlace[] playerRow1;
    [SerializeField] public BattlePlace[] playerRow2;
    public static BattlePlace[] playerRow_1;
    public static BattlePlace[] playerRow_2;
    int allRowsLength;
    void Awake()
    {
        allRows = GetComponentsInChildren<RowManager>();
        allEnemyRows = GetComponentsInChildren<RowEnemyManager>();
        CreateallPlacesArray();
        CreateallEnemyPlacesArray();
        enemyRow_1 = enemyRow1;
        enemyRow_2 = enemyRow2;
        playerRow_1 = playerRow1;
        playerRow_2 = playerRow2;
    }
    private void CreateallPlacesArray()
    {
        int heightOfArray = allRows.Length;
        int widthOfArray = allRows[0].allPlacesInRow.Length;
        allPlacesArray = new BattlePlace[widthOfArray, heightOfArray];
        for (int i = 0; i < heightOfArray; i++)
        {
            for (int j = 0; j < widthOfArray; j++)
            {
                allPlacesArray[j, i] = allRows[heightOfArray - i - 1].
                                      allPlacesInRow[widthOfArray - j - 1];
            }
        }
    }
     private void CreateallEnemyPlacesArray()
    {
        int heightOfArray = allEnemyRows.Length;
        int widthOfArray = allEnemyRows[0].allEnemyPlacesInRow.Length;
        allEnemyPlacesArray = new BattlePlace[widthOfArray, heightOfArray];
        for (int i = 0; i < heightOfArray; i++)
        {
            for (int j = 0; j < widthOfArray; j++)
            {
                allEnemyPlacesArray[j, i] = allEnemyRows[heightOfArray - i - 1].
                                      allEnemyPlacesInRow[widthOfArray - j - 1];
            }
        }
    }
}
