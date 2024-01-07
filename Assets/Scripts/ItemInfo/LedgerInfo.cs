using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgerInfo : ItemInfo
{
    string itemName = "Ledger";

    public new bool canPickUp = true;
    public bool pickedUp = false;

    bool inspected = false;
    int inspectCount = 0;

    Dictionary<string, string> allInspect = new Dictionary<string, string>();
    Dictionary<string, string> allCombine = new Dictionary<string, string>();

    Dictionary<string, bool> allFlags = new Dictionary<string, bool>();

    void Start()
    {
        allInspect.Add("default", @"A ledger detailing finances for Silvia's company.
                        There are regular outgoing payments that seem unusual.");
        allInspect.Add("hasBankStatement", @"A ledger detailing finances for Silvia's company.
                        There are regular outgoing payments that seem unusual.
                        These payments match incoming payments on the Bank Statement.");
        //allInspect.Add("inspected", "already inspected");

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
