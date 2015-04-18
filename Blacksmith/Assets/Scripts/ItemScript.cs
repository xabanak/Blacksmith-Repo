using UnityEngine;
using System.Collections;

public class ItemScript : MonoBehaviour 
{
    private string material;
    private string item;
    private string quality;
    private int power;

    public void SetItemStats(string material, string item, string quality, int power)
    {
        this.material = material;
        this.item = item;
        this.quality = quality;
        this.power = power;
    }

    public int GetPower()
    {
        return power;
    }

    public string GetItem()
    {
        return item;
    }

    public string GetMaterial()
    {
        return material;
    }

    public string GetItemDescription()
    {
        return material + " " + item + " (" + quality + ")";
    }
}
