using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveLettersInfo : ItemInfo
{
    string itemName = "LoveLetters";

    public new bool canPickUp = true;
    public bool pickedUp = false;

    bool inspected = false;
    int inspectCount = 0;

    Dictionary<string, string> allInspect = new Dictionary<string, string>();
    Dictionary<string, string> allCombine = new Dictionary<string, string>();

    Dictionary<string, bool> allFlags = new Dictionary<string, bool>();

    void Start()
    {
        allInspect.Add("default", "A set of three love letters found in the bin of the study. They are Addressed to My Sweetheart Silvia and signed from Your Admirer Agnes, with more kisses than you care to count.");
        //allInspect.Add("inspected", "You have already inspected this item. A set of three love letters found in the bin of the study. They are Addressed to My Sweetheart Silvia and signed from Your Admirer Agnes, with more kisses than you care to count.");


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

