using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feature : MonoBehaviour
{
    [SerializeField] private PlayerDataSO playerDataSO;
    [SerializeField] private Transform[] features;
   private  int[] lvFeature = { 3, 5, 15, 25 };
  
    void Start()
    {
        for(int i = 0; i < lvFeature.Length; i++)
        {
            if (lvFeature[i] <= mainUI.levelIndex)
            {
                features[i].gameObject.SetActive(true);
            }
            else
            {
                features[i].gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
