using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilyPhotoInfo : ItemInfo
{
    string itemName = "MaidFamilyPhoto";

    public new bool canPickUp = true;
    public bool pickedUp = false;

    bool inspected = false;
    int inspectCount = 0;

    Dictionary<string, string> allInspect = new Dictionary<string, string>();
    Dictionary<string, string> allCombine = new Dictionary<string, string>();

    Dictionary<string, bool> allFlags = new Dictionary<string, bool>();

    void Start()
    {
        allInspect.Add("default", @"A low detail rendering picturing the young maid with a similar age man and two elderly people. There is a tear in the bottom left corner. 
                                    This was concealed behind a dresser in the maids room, and appears to have been moved from its hiding spot frequently.");
        allInspect.Add("hasNewspaper", @"A low detail rendering picturing the young maid with a similar age man and two elderly people. There is a tear in the bottom left corner. 
                                    This was concealed behind a dresser in the maids room, and appears to have been moved from its hiding spot frequently.
                                    One of the figures in the photo can be recognised in the Newspaper.");
        //allInspect.Add("inspected", "You have already inspected this item. A low detail rendering picturing the young maid with a similar age man and two elderly people. There is a tear in the bottom left corner. This was concealed behind a dresser in the maids room, and appears to have been moved from its hiding spot frequently.");


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
