using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickOnMe : MonoBehaviour, IPointerClickHandler
{
    BattlePlace place;
    public FieldManager fieldManager;
    BattleController battleController;
    void Awake()
    {
        place = GetComponent<BattlePlace>();
        fieldManager = FindObjectOfType<FieldManager>();
        battleController = FindObjectOfType<BattleController>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (place.potencialTarget)
        {
            battleController.events.gameObject.SetActive(false); // disables click response
            BattleController.currentTarget = this.GetComponentInChildren<Hero>();
            BattleController.currentAtacker.HeroIsAtacking();
            return;
        }
    }
}