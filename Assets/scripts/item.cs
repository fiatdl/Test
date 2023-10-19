using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Item : MonoBehaviour
{
    [SerializeField]public ItemSO itemSO;
    card target;
   
    private float moveSpeed;
    private bool isInstan;
    private Item newItem;
    private bool isMoving;
    private Vector3 desPosion;
    void Start()
    {
     
        isInstan = false;
        moveSpeed = 25f;
    }

    // Update is called once per frame
    void Update()
    {

        if (isMoving)
        {
            if (Vector3.Distance(transform.position, desPosion) < 10f)
            {
                isMoving = false;
            }
            Move(desPosion);
        }

            if(target!= null) {
            if(isInstan==false) { Transform ItemTemplate = Instantiate(itemSO.preFab, target.transform); 
            ItemTemplate.localScale -= new Vector3(6.4f, 1f, 8.4f);
            Item item = ItemTemplate.GetComponent<Item>();
            item.gameObject.SetActive(false);
                item.GetComponent<EventTriggerItem>().enabled=false;
                target.item = item;
                isInstan = true;
                newItem = item;
                if (GameManagement.Instance.lastCard == target)
                { GameManagement.Instance.lastItemAdded = item; }
            }
           

            if (Vector3.Distance(transform.position,target.HoldPoint.position)>2f)
        {
                
            Move(target.transform.position);
        }
        else{   if (newItem)
                { newItem.gameObject.SetActive(true); }
                target = null;
               
                Destroy(gameObject);
                }
        
            }
        

    }
    public void HandleMoveToPos(card pos)
    {
        target = pos;
      
   
       

    }
    public void SettingPropertyForBack(Vector3 des)
    {
        isMoving=true;
        desPosion = des;
    }
    public void DestroySefl()
    {
        Destroy(gameObject);
    }
  

    private void Move(Vector3 destination)
    {
        Vector3 dir = new Vector3(destination.x - transform.position.x, destination.y - transform.position.y, destination.z - transform.position.z);
     transform.position += dir * Time.deltaTime * moveSpeed;
    }
}
