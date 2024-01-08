using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Testimony : MonoBehaviour, IPointerDownHandler
{
    private EvidenceSelect e;
    public string id;
    private ProtagInfo p;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (p.accusing)
        {
            e = GameObject.Find("EvidenceSelect").GetComponent<EvidenceSelect>(); //should only find the current active one
            e.selected(id);
            Debug.Log(id + " <- id");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // id = "";
        p = GameObject.Find("Protag").GetComponent<ProtagInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
