using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class CardCollection : ScriptableObject
{
  [SerializeField] public ItemSO[] Items;
}
