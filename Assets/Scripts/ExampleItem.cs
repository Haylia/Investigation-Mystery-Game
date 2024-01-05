using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleItem : ItemInfo
{
    string itemName = "Example Item";

    public new bool canPickUp = true;
    public bool pickedUp = false;

    bool inspected = false;
    int inspectCount = 0;

    Dictionary<string, string> allInspect = new Dictionary<string, string>();
    Dictionary<string, string> allCombine = new Dictionary<string, string>();

    Dictionary<string, bool> allFlags = new Dictionary<string, bool>();

    void Start()
    {
        allInspect.Add("default", "default inspect response");
        allInspect.Add("inspected", "already inspected");

        allFlags.Add("inspected", inspected);
        allFlags.Add("canPickUp", canPickUp);
        allFlags.Add("pickedUp", pickedUp);
    }

    public override string getName()
    {
        return itemName;
    }

    override public Dictionary<string,string> getAllInspect()
    {
        return allInspect;
    }

    override public Dictionary<string,string> getAllCombine()
    {
        return allCombine;
    }

    override public Dictionary<string,bool> getAllFlags()
    {
        return allFlags;
    }

    override public void setFlag(string flag, bool b)
    {
        if (allFlags.ContainsKey(flag))
        {
            allFlags[flag] = b;
        }
        else
        {
            allFlags.Add(flag, b);
        }
    }
}
