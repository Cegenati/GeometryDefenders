﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //Unity wil save and load values of this class for us, making them visible in the inspector

public class TurretBlueprint
{
    public GameObject prefab;
    public int cost;

    public GameObject upgradedPrefab;
    public int upgradeCost;

    public int GetSellAmount()
    {
        return cost/2;
    }
}
