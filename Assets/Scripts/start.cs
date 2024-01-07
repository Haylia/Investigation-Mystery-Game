using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour
{

    public void clickStart()
    {
        GameObject.Find("ExplainCanvas").SetActive(false);
        GameObject.Find("ProtagMenu").SetActive(false);

        gameObject.SetActive(false);
    }

}
