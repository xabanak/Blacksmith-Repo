using UnityEngine;
using System.Collections;

public class ItemScript : MonoBehaviour 
{
    private string material;
    private string item;
    private string quality;
    private int power;

    public void setItemStats(string material, string item, string quality, int power)
    {
        this.material = material;
        this.item = item;
        this.quality = quality;
        this.power = power;
    }

    public int getPower()
    {
        return power;
    }

    public string getItem()
    {
        return item;
    }

    public string getMaterial()
    {
        return material;
    }

    public string getItemDescription()
    {
        return material + " " + item + " (" + quality + ")";
    }
}
