using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvidenceSelect : MonoBehaviour
{
    private Accuse accuse;
    private List<GameObject> itemEvidence;
    private List<string> testimony;

    // Start is called before the first frame update
    void Start()
    {
        accuse = GetComponentInParent<Accuse>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setEvidence()
    {
        //create UI container for evidence that blocks raycasts
        //get item names from Inventory
        //get testimony as String from Notebook
        //set OnPointerDown to selected(name)
        //set containers as children of EvidenceSelect
    }


    private void selected(string name)
    {
        accuse.evidenceSelected(name);
    }

    public void clear()
    {
        //clear EvidenceSelect
        while(gameObject.transform.childCount > 0)
        {
            Destroy(gameObject.GetComponentInChildren<Selectable>().gameObject);
        }
    }
}
