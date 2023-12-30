using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protag : MonoBehaviour
{
    private GameObject notebook;
    private GameObject inventory;
    // Start is called before the first frame update
    void Start()
    {
        notebook = GameObject.Find("Notebook");
        notebook.SetActive(false);
        inventory = GameObject.Find("Inventory");
        inventory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openNotebook()
    {
        notebook.SetActive(true);
        notebook.GetComponent<Notebook>().onOpen();
    }

    public void closeNotebook()
    {
        notebook.SetActive(false);
    }

    public void openInventory()
    {
        inventory.SetActive(true);
        inventory.GetComponent<Inventory>().onOpen();
    }

    public void closeInventory()
    {
        inventory.SetActive(false);
    }
}
