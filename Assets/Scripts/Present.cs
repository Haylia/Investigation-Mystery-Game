using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Present : MonoBehaviour
{
    private EvidenceSelect e;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void present()
    {
        e = GameObject.Find("EvidenceSelect").GetComponent<EvidenceSelect>();
        e.selected(gameObject.GetComponentInParent<ItemInfo>().getName());
    }
}
