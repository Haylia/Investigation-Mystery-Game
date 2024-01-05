using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protag : MonoBehaviour
{
    private GameObject notebook;
    private GameObject inventory;
    private GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        notebook = transform.Find("ProtagCanvas/Notebook").gameObject;
        notebook.SetActive(false);
        inventory = transform.Find("ProtagCanvas/Inventory").gameObject;
        inventory.SetActive(false);
        menu = transform.Find("ProtagCanvas/ProtagMenu").gameObject;
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        openMenu();
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

    public void openMenu()
    {
        menu.SetActive(true);
    }

    public void closeMenu()
    {
        menu.SetActive(false);
    }
}
