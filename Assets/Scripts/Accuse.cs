using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Accuse : MonoBehaviour
{
    private GameObject dialogeBox;
    private Character character;
    private GameObject evidenceSelect;
    private float pressureBefore;
    private float pressureNow;
    private int turns;
    private bool waiting;
    private GameObject protagMenu;
    // Start is called before the first frame update
    void Start()
    {
        character = gameObject.GetComponentInParent<Character>();
        dialogeBox = character.transform.Find("Canvas/CharacterMenu/DialogueBox").gameObject;
        evidenceSelect = transform.Find("EvidenceSelect").gameObject;
        waiting = false;
        protagMenu = GameObject.Find("ProtagMenu");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void accuseStart()
    {
        //GameObject.Find("Protag").GetComponent<ProtagInfo>().accusing = true;

        character.accuse();
        dialogeBox.GetComponent<TextMeshProUGUI>().SetText(character.currentResponse);

        pressureBefore = 0;
        pressureNow = 0;
        turns = 0;

        evidenceSelect.SetActive(false);

        StartCoroutine(accuseLoop());
    }


    IEnumerator accuseLoop()
    {
        //ends if player does not increase pressure fast enough or pressure theshold reached
        while (turns < 4 || pressureNow > 5)
        {
            //evidence selection
            evidenceSelect.SetActive(true);
            waiting = true;
            protagMenu.SetActive(true);
            protagMenu.transform.Find("ClosePMenu").gameObject.SetActive(false);
            yield return new WaitWhile(() => waiting);
            //wait for protag dialogue to end
            protagMenu.SetActive(false);
            //turns goes up if pressure has decreased or little to no change
            if (System.Math.Floor(pressureNow) <= System.Math.Floor(pressureBefore))
            {
                turns++;
            }
            //turns resets if pressure increased by 1
            else
            {
                turns = 0;
            }

            //character response
            dialogeBox.GetComponent<TextMeshProUGUI>().SetText(character.currentResponse);
        }
        //evidenceSelect.GetComponent<EvidenceSelect>().clear();
        if (pressureNow > 5)
        {
            character.successfulAccusation();
        }
        else
        {
            character.failedAccusation();
        }
    }
    
    public void evidenceSelected(string evidence)
    {
        pressureBefore = pressureNow;
        character.presentEvidence(evidence);
        pressureNow = character.pressure;
        evidenceSelect.SetActive(false);
        waiting = false;
    }

    public void retractAccuse()
    {
        //character.retractAccusation();
        turns = 4;
    }
}