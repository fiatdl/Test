using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventTriggerItem : EventTrigger
{

    [SerializeField]private Item item;

    private void Start()
    {
        item=transform.gameObject.GetComponent<Item>();
        
    }






  
}
