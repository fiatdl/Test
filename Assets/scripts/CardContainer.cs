using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardContainer : MonoBehaviour
{
    public Transform[] CardTransform;
    public Item[] itemsContainer=new Item[7];
    public static CardContainer Instance { get; private set; }

    void Start()
    {
        Instance = this;
    }
    public void CheckAndSendPosition( Item item)
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public Vector2 GetPosition()
    {
        Vector2 pos=new Vector2(itemsContainer[0].transform.position.x, itemsContainer[0].transform.position.y);
        return pos; 
    }
}
