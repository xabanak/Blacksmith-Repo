﻿using UnityEngine;
using System.Collections;

public class SellItem : MonoBehaviour {

    public GameObject craftedItem;

    public void setCraftedItem(GameObject item)
    {
        craftedItem = item;
    }

    public GameObject getCraftedItem()
    {
        return craftedItem;
    }

}
