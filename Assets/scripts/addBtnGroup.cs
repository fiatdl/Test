using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addBtnGroup : MonoBehaviour
{
    [SerializeField] Transform[] btnGroup;
    [SerializeField] PlayerDataSO playerDataSO;
    void Start()
    {
        for (int i = 0; i <8; i++)
        {
            btnGroup[i].gameObject.SetActive(true);
        }
        for (int i = 0; i < playerDataSO.currentCardSlot; i++)
        {
            btnGroup[i].gameObject.SetActive(false);    
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenSlot()
    {
        playerDataSO.currentCardSlot ++;
        GameManagement.maximunCartContainer=playerDataSO.currentCardSlot;
        playerDataSO.currentCoin -= 500;
        btnGroup[playerDataSO.currentCardSlot-1].gameObject.SetActive(false);
    }
}
