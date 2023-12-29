using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadeLabel : MonoBehaviour
{
    public string shadeLabel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string getShadeLabel()
    {
        return shadeLabel;
    }

    public void setShadeLabel(string newString)
    {
        shadeLabel = newString;
    }
}
