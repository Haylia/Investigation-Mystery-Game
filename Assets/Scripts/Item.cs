using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject notebook;
    public ProtagInfo protagInfo;
    private ItemInfo itemInfo;

    List<string> availableInteractions = new List<string>();

    Dictionary<string, bool> itemFlags;
    Dictionary<string, bool> protagFlags;

    Dictionary<string, string> allInspect;
    Dictionary<string, string> allCombine;

    public string currentInspect = "";
    public string currentCombineItem = "";
    public string currentCombineResponse = "";

    // Start is called before the first frame update
    void Start()
    {
        itemInfo = gameObject.GetComponent<ItemInfo>();
        allInspect = itemInfo.getAllInspect();
        allCombine = itemInfo.getAllCombine();

    }

    public void itemClicked()
    {
        //only need to check flags once per click
        itemFlags = itemInfo.getAllFlags();

        ///////////////////////////////////////////
        //protagFlags = protagInfo.getAllFlags();//
        ///////////////////////////////////////////
        availableInteractions.Clear();

        if (itemFlags["canPickUp"])
        {
            availableInteractions.Add("PickUp");
        }

        if (itemFlags["pickedUp"])
        {
            availableInteractions.Add("Combine");
        }

        availableInteractions.Add("Inspect");
    }

    // Update is called once per frame
    void Update()
    {
        /*
        itemFlags = itemInfo.getAllFlags();
        protagFlags = protagInfo.getAllFlags();
        */
    }

    public void Inspect()
    {
        // call when inspect button clicked
        foreach (string flag in allInspect.Keys)
        {
            Debug.Log(flag);
            Debug.Log(itemFlags);
            if (itemFlags.ContainsKey(flag))
            {
                if (itemFlags[flag])
                {
                    currentInspect = allInspect[flag];
                }
            }
            /*////////////////////////////
            if (protagFlags.ContainsKey(flag))
            {
                if (protagFlags[flag])
                {
                    currentInspect = allInspect[flag];
                }
            }
            *////////////////////////////
        }
        if (currentInspect.Equals(""))
        {
            currentInspect = allInspect["default"];
        }
    }

    public void InspectEnd()
    {
        // call when click to end inspect
        itemInfo.setFlag("inspected", true);
        currentInspect = "";
    }

    public void Combine()
    {
        //wait until user selects another item then get name
        if (allCombine.ContainsKey(currentCombineItem))
        {
            currentCombineResponse = allCombine[currentCombineItem];
        }
        else
        {
            currentCombineResponse = "???";
        }

    }

    public void CombineEnd()
    {
        currentCombineItem = "";
        currentCombineResponse = "";
    }

    public void PickUp()
    {
        if (itemFlags["canPickUp"])
        {
            //add item to inventory
            //remove from map
            
            //////////////////////////////////////
            //protagInfo.pickUpItem(gameObject);//
            //////////////////////////////////////
            itemInfo.setFlag("pickedUp", true);
            itemInfo.setFlag("canPickUp", false);
        }
    }
}
