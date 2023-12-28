using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour // shows picked up items
{
    public ProtagInfo protagInfo;

    List<GameObject> inventory = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onOpen()
    {
        inventory = protagInfo.getInventory();
    }
}
