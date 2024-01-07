using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    private GameObject closeButton;
    private GameObject openButton;
    private GameObject instructionsText;
    // Start is called before the first frame update
    void Start()
    {
        openButton = transform.Find("InstructionsOpen").gameObject;
        closeButton = transform.Find("InstructionsClose").gameObject;
        instructionsText = transform.Find("Instructions/Text (TMP)").gameObject;
        instructionsText.GetComponent<TextMeshProUGUI>().SetText(getInstructions());
        closeButton.SetActive(false);
        instructionsText.SetActive(false);
        openButton.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openInstructions()
    {
        instructionsText.SetActive(true);
        closeButton.SetActive(true);
        openButton.SetActive(false);
    }

    public void close()
    {
        closeButton.SetActive(false);
        instructionsText.SetActive(false);
        openButton.SetActive(true);
    }

    private string getInstructions()
    {
        var i = @"
The goal is to identify a suspect for the murder and successfully accuse them.
Each of the characters can be accused at any point but evidence is needed for it to be successful.
Evidence can be in the form of Items and Testimony that have been recorded in your Inventory and Notebook respectfully.
Items can be Recorded. Characters can Talk or be Shown Items. The Responses from these interactions can be Recorded.
Sometimes Recording Items and Testimony can unlock new Talk options or update previous responses and itme descriptions.

Once you think you have enough evidence you can Accuse a character.
During the accusation you will be asked to present evidence against the character.
If, in a row, a certain amount of opportunies to present evidence pass and the presented evidence does not support your case or only minimally supports it, the the accusation fails.
Once you have provided enought evidence to support your case, the accusation is successful.
Each character can only be accused once and you have two chances to accuse.

The ending is dependent on the outcome of your accusation.";
        return i;
    }
}
