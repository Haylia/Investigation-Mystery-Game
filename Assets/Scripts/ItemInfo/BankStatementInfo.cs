using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankStatementInfo : ItemInfo
{
    string itemName = "BankStatement";

    public bool canPickUp = true;
    public bool pickedUp = false;

    bool inspected = false;
    int inspectCount = 0;

    Dictionary<string, string> allInspect = new Dictionary<string, string>();
    Dictionary<string, string> allCombine = new Dictionary<string, string>();

    Dictionary<string, bool> allFlags = new Dictionary<string, bool>();

    void Start()
    {

        allInspect.Add("default", @"A set of papers detailing the last three months of transactions from bank accounts owned by both Heather and Silvia.
                        Notably, Life insurance has been bought for Heather from the bank account of Silvia on the bottom sheet.");
        allInspect.Add("hasLedger", @"A set of papers detailing the last three months of transactions from bank accounts owned by both Heather and Silvia.
                        Notably, Life insurance has been bought for Heather from the bank account of Silvia on the bottom sheet.
                        There is also a regular income that matches mysterious outgoing payments in Silvia's company Ledger.");
        //allInspect.Add("inspected", "You have already inspected this item. A set of papers detailing the last three months of transactions from bank accounts owned by both Heather and Silvia. Notably, Life insurance has been bought for Heather from the bank account of Silvia on the bottom sheet.");


        //SHOWN FLAGS: "shown" + itemName
        //RECORDED TESTIMONY FLAG: "heard" + testimony id

        //if maid photo found: "You recognise an elderly and young man in a picture. They are the Maids father and brother."

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

