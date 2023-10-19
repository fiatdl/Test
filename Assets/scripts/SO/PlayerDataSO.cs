using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class PlayerDataSO : ScriptableObject
{
    public int currentLV;
    public int currentStar;
    public int currentCoin;
    public int currentLife;
    public int currentCardSlot;
    public int CurrentLV { get => currentLV; set => currentLV = value; }
    public int CurrentStar { get => currentStar; set => currentStar = value; }
    public int CurrentCoin { get => currentCoin; set => currentCoin = value; }
    public int CurrentLife { get => currentLife; set => currentLife = value; }
    public int CurrentCardSlot { get => currentCardSlot; set => currentCardSlot = value; }
}
