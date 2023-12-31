using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeInfo : ItemInfo
{
    string itemName = "SpeakingTube";

    public new bool canPickUp = true;
    public bool pickedUp = false;

    bool inspected = false;
    int inspectCount = 0;

    Dictionary<string, string> allInspect = new Dictionary<string, string>();
    Dictionary<string, string> allCombine = new Dictionary<string, string>();

    Dictionary<string, bool> allFlags = new Dictionary<string, bool>();

    void Start()
    {

        allInspect.Add("default", "Concealed speaking tube found between the Maid's and Chef's quarters and in the Master Bedroom. This can be used to communitcate throughout the house.");
        //allInspect.Add("inspected", "You have already inspected this item. Concealed speaking tube found between the maid's and chef's quarters. This could have been used to communicate without anyone else knowing.");


        //SHOWN FLAGS: "shown" + itemName
        //RECORDED TESTIMONY FLAG: "heard" + testimony id
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

