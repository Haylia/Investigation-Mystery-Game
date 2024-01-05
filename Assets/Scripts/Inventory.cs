using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Inventory : MonoBehaviour // shows picked up items
{
    private ProtagInfo protagInfo;
    private GameObject inventoryView;
    private GameObject inventoryContent;

    List<GameObject> inventory = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        //protagInfo = GameObject.Find("Protag").GetComponent<ProtagInfo>();
        protagInfo = gameObject.GetComponentInParent<ProtagInfo>();
        inventoryView = transform.Find("InventoryView").gameObject;
        inventoryContent = inventoryView.transform.Find("Viewport/InventoryContent").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onOpen()
    {
        inventory = protagInfo.getInventory();

        foreach (GameObject item in inventory)
        {
            if (item.transform.parent != inventoryContent.transform)
            {
                item.transform.SetParent(inventoryContent.transform);
            }
        }
    }
}
