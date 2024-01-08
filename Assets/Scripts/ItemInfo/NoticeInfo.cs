using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoticeInfo : ItemInfo
{
    string itemName = "NoticeOfDismissal";

    public bool canPickUp = true;
    public bool pickedUp = false;

    bool inspected = false;
    int inspectCount = 0;

    Dictionary<string, string> allInspect = new Dictionary<string, string>();
    Dictionary<string, string> allCombine = new Dictionary<string, string>();

    Dictionary<string, bool> allFlags = new Dictionary<string, bool>();

    void Start()
    {

        allInspect.Add("default", "A Notice of Dismissal addressed to Silvia.");
        //allInspect.Add("inspected", "You have already inspected this item. A small note scribbled on some scrap paper detailing break times for the staff. Of note, Todays evening break was changed from 9pm to 10:30pm");


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
