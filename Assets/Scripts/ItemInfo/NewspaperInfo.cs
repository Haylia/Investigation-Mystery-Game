using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewspaperInfo : ItemInfo
{
    string itemName = "Newspaper";

    public new bool canPickUp = true;
    public bool pickedUp = false;

    bool inspected = false;
    int inspectCount = 0;

    Dictionary<string, string> allInspect = new Dictionary<string, string>();
    Dictionary<string, string> allCombine = new Dictionary<string, string>();

    Dictionary<string, bool> allFlags = new Dictionary<string, bool>();

    void Start()
    {
        allInspect.Add("default", @"Multiple torn out scraps from several newspapers. All of them have one theme: Embezzlement. 
                                    Specifically embezzlement from Silvia's company. She's even quoted in one, mentioning how she feels 'betrayed by a trusted friend'.
                                    One scrap has details blotted out in black ink.");
        allInspect.Add("hasMaidFamilyPhoto", @"Multiple torn out scraps from several newspapers. All of them have one theme: Embezzlement. 
                                    Specifically embezzlement from Silvia's company. She's even quoted in one, mentioning how she feels 'betrayed by a trusted friend'.
                                    One scrap has details blotted out in black ink.
                                    The embezzler pictured in the clippings can be recognised in the Maid's Family Photo.");
        //allInspect.Add("inspected", "You have already inspected this item. Multiple torn out scraps from several newspapers. All of them have one theme: Embezzlement. One scrap has details blotted out in black ink.");

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

