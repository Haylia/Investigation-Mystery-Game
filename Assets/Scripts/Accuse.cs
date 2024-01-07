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
    private GameObject explain;
    private ProtagInfo protagInfo;
    // Start is called before the first frame update
    void Start()
    {
        character = gameObject.GetComponentInParent<Character>();
        dialogeBox = character.transform.Find("Canvas/CharacterMenu/DialogueBox").gameObject;
        evidenceSelect = transform.Find("EvidenceSelect").gameObject;
        waiting = false;
        protagMenu = GameObject.Find("ProtagMenu");
        explain = GameObject.Find("Explain");
        protagInfo = GameObject.Find("Protag").GetComponent<ProtagInfo>();
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
            protagMenu.SetActive(false);

            //wait for protag dialogue to end
            protagInfo.explaining = true;
            explainStart();
            yield return new WaitWhile(() => protagInfo.explaining);

            //character response
            dialogeBox.GetComponent<TextMeshProUGUI>().SetText(character.currentResponse);
            character.responding = true;
            dialogeBox.SetActive(true);

            yield return new WaitWhile(() => character.responding);

            //wait for  character response to end

            //evidenceSelect.GetComponent<EvidenceSelect>().clear();

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

        }

        if (pressureNow > 5)
        {
            character.successfulAccusation();
        }
        else
        {
            character.failedAccusation();
        }

        GameObject.Find("SceneMaster").GetComponent<SceneMaster>().checkEndingReached();
    }

    private void explainStart()
    {
        explain.SetActive(true);
        string dialogue = protagMenu.GetComponentInParent<ProtagInfo>().currentAccuseDialogue;
        Stack<string> organisedDialogue = new Stack<string>();
        string[] dialogueSplit = dialogue.Split("***");
        foreach (string s in dialogueSplit)
        {
            organisedDialogue.Push(s);
        }
        explain.GetComponent<TextMeshProUGUI>().SetText(organisedDialogue.Pop());
        explain.GetComponent<ExplainQueue>().explainQueue = organisedDialogue;
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