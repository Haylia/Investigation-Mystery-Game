using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private ProtagInfo protagInfo;
    private CharacterInfo characterInfo;

    public float pressure = 0;

    Dictionary<int, string> pressureResponse = new Dictionary<int, string>();

    Dictionary<string, Dictionary<string, string>> allDialogue = new Dictionary<string, Dictionary<string, string>>();
    //dialogue option to dict of flag to responses
    Dictionary<string, List<string>> flagToDialogueOptions = new Dictionary<string, List<string>>();
    Dictionary<string, string> availableDialogue = new Dictionary<string, string>();
    Dictionary<string, string> testimonyToID = new Dictionary<string, string>();
    Dictionary<string, string> idToTestimony = new Dictionary<string, string>();

    Dictionary<string, string> allShow = new Dictionary<string, string>();


    Dictionary<string, bool> characterFlags = new Dictionary<string, bool>();
    Dictionary<string, bool> protagFlags = new Dictionary<string, bool>();
    Dictionary<string, bool> allFlags = new Dictionary<string, bool>();

    public string currentResponse = "";
    public bool responding;

    //string currentShowItem = "";

    //string currentEvidence = "";
    
    // Start is called before the first frame update
    void Start()
    {
        responding = false;
        protagInfo = GameObject.Find("Protag").GetComponent<ProtagInfo>();

        characterInfo = gameObject.GetComponent<CharacterInfo>();
        pressureResponse = characterInfo.getPressureResponse();

        allDialogue = characterInfo.getAllTalk();
        flagToDialogueOptions = characterInfo.getFlagToDialogueOptions();
        testimonyToID = characterInfo.getTestimonyToID();
        idToTestimony = characterInfo.getIDToTestimony();

        allShow = characterInfo.getAllShow();
    }

    public void characterClicked()
    {
        characterFlags = characterInfo.getAllFlags();
        protagFlags = protagInfo.getAllFlags();
        allFlags = characterFlags;
        foreach (KeyValuePair<string,bool> p in protagFlags)
        {
            allFlags.Add(p.Key,p.Value);
        }
        setAvailableTalk();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void talk()
    {
        // call when talk option clicked
        setAvailableTalk();

    }

    public void talking(string option)
    {
        currentResponse = availableDialogue[option];
    }

    public void talkEnd()
    {
        currentResponse = "";
    }

    public void show(string currentShowItem)
    {
        //wait for player to select item to show and get item name
        if (allShow.ContainsKey(currentShowItem))
        {
            currentResponse = allShow[currentShowItem];
        }
        else
        {
            currentResponse = characterInfo.getDefaultShow();
        }

    }

    public void showEnd(string currentShowItem)
    {
        currentResponse = "";
        characterInfo.setFlag("shown" + currentShowItem, true);
    }

    public void accuse()
    {
        if (characterInfo.getAccused())
        {
            currentResponse = characterInfo.getAccuseAgain();
        }
        else
        {
            characterInfo.setPressure(0);
            //currentResponse = pressureResponse[0];
            protagInfo.accusationBegin();
        }
    }

    public void presentEvidence(string currentEvidence)
    {
        // should loop until threshhold
        protagInfo.presentEvidence(currentEvidence, gameObject);
        pressure = characterInfo.getPressure();
        //currentEvidence = "";
        currentResponse = pressureResponse[(int)System.Math.Floor(pressure)];
    }

    public void retractAccusation()
    {
        //initiated by player, loses life
        protagInfo.loseLife();
        accuseEnd();
    }

    public void failedAccusation()
    {
        //occures automatically if pressure gets too low, loses life
        protagInfo.loseLife();
        accuseEnd();
    }

    public void successfulAccusation()
    {
        characterInfo.setSuccessful(true);
        characterInfo.setFlag("successful", true);
    }

    void accuseEnd()
    {
        currentResponse = "";
        characterInfo.setAccused(true);
        characterInfo.setFlag("accused", true);
        //currentEvidence = "";
    }

    public void recordTestimony()
    {
        protagInfo.addTestimony(testimonyToID[currentResponse], currentResponse, gameObject);
    }


    void setAvailableTalk()
    {
        availableDialogue.Clear();
        List<string> options = new List<string>();
        foreach (string flag in flagToDialogueOptions.Keys) //loop though sets of dialogue options depending on flag
        {
            if (allFlags.TryGetValue(flag, out bool value))
            {
                options.AddRange(flagToDialogueOptions[flag]);
            }
        }

        if (options.Count == 0)
        {
            options = flagToDialogueOptions["default"];
        }

        foreach (string op in options)  //gets a response for each option depending on flags
        {
            string res = "";
            foreach (string flag in allDialogue[op].Keys)
            {
                if (allFlags.TryGetValue(flag, out bool value))
                {
                    res = allDialogue[op][flag];
                }
            }

            if (res.Equals(""))
            {
                res = allDialogue[op]["default"];
            }

            availableDialogue.Add(op, idToTestimony[res]);
        }

    }


    public Dictionary<string,string> getAvailableTalk()
    {
        return availableDialogue;
    }
}
