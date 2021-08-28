using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : ScriptableObject
{

    public new string name;
    public string description;

    [HideInInspector] public ItemType itemType;

}

public enum ItemType
{
    Weapon,
}