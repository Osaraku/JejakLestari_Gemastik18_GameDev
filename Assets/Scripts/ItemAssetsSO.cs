using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemAssetsSO", menuName = "ScriptableObjects/ItemAssetsSO", order = 2)]
public class ItemAssetsSO : ScriptableObject
{
    public Transform prefab;
    public Sprite sprite;
    public String itemName;
}
