using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMaster : MonoBehaviour
{
    private CharacterInfo[] characters;
    private ProtagInfo protagInfo;
    // Start is called before the first frame update
    void Start()
    {
        characters = GameObject.Find("Characters").GetComponentsInChildren<CharacterInfo>();
        protagInfo = GameObject.Find("Protag").GetComponent<ProtagInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkEndingReached()
    {
        string ending= "";
        if (protagInfo.lives == 0)
        {
            ending = "failed";
        }
        else
        {
            foreach (CharacterInfo c in characters)
            {
                if (c.getSuccessful() == true)
                {
                    ending = c.getName();
                    break;
                }
            }
        }

        if (protagInfo.getAllFlags().ContainsKey("hasLedger&BankStatement") && ending == "Margaret")
        {
            ending = ending + "2";
        }

        if (ending != "")
        {
            endingStart(ending);
        }
    }

    public void endingStart(string e)
    {

    }
}
