using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemStatsTemplate", menuName = "ItemStatsTemplate")]
public class ItemStatsTemplate : ScriptableObject
{
    public float fallSpeed;
	public int pointValue;
	public EnumValue itemType;
	public EnumValue itemTier;
}
