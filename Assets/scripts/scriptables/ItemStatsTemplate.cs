using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemStatsTemplate", menuName = "ItemStatsTemplate")]
public class ItemStatsTemplate : ScriptableObject
{
    public FoodType foodType;
    public float fallSpeed;
}
