using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ItemSO : ScriptableObject
{
    public Transform preFab;
    public Sprite sprite;
    public string objectName;
    public int priority;
}
