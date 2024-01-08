using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeInfo : ItemInfo
{

    string itemName = "Knife";


    public new bool canPickUp = true;
    public bool pickedUp = false;

    bool inspected = false;
    int inspectCount = 0;

    Dictionary<string, string> allInspect = new Dictionary<string, string>();
    Dictionary<string, string> allCombine = new Dictionary<string, string>();

    Dictionary<string, bool> allFlags = new Dictionary<string, bool>();

    void Start()
    {
        allInspect.Add("default", "A knife found in the master bedroom. This looks incriminating, and is most likely the murder weapon.");

        allInspect.Add("KnifeSource", "A knife found in the master bedroom. This looks incriminating, and is most likely the murder weapon. Chef identified it as one of the kitchen knives.");


        //SHOWN FLAGS: "shown" + itemName
        //RECORDED TESTIMONY FLAG: "heard" + testimony id

        //heard chef: Matches other knives found in the kitchen.

        //RECORDED ITEM FLAG; "has" + itemName

        allFlags.Add("inspected", inspected);
        allFlags.Add("canPickUp", canPickUp);
        allFlags.Add("pickedUp", pickedUp);
    }

    public override string getName()
    {
        return itemName;
    }

    public override bool getCanPickUp()
    {
        return canPickUp;
    }

    public override void setCanPickUp(bool b)
    {
        canPickUp = b;
    }

    override public Dictionary<string, string> getAllInspect()
    {
        return allInspect;
    }

    override public Dictionary<string, string> getAllCombine()
    {
        return allCombine;
    }

    override public Dictionary<string, bool> getAllFlags()
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
