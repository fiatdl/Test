using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] private Item item;
    [SerializeField] private SoundSO soundSO;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SendItemToWorkBar()
    {
        SoundManagement.Instance.PlaySound(soundSO.hit);
        GameManagement.Instance.add(item);
    }
  
}
