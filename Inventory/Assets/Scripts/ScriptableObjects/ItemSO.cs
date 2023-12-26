using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSO : ScriptableObject
{
    public GameObject prefab;
    public Sprite sprite;
    public int stackMaxCount;
    public bool isStackable = true;
}
