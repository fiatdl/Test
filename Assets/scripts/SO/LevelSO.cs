using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu()]
public class LevelSO : ScriptableObject
{
    [SerializeField]
    public int nextLevel;
   [SerializeField] public List<int>numberOfItemList=new List<int>(10);
    [SerializeField] public float Timer;


}
