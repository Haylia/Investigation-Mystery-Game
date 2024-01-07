using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleCharacter : CharacterInfo
{
    string characterName = "Example Character";

    bool accused = false;
    bool successful = false;

   
    float pressure = 0;
    //character dialogue used in accusation
    Dictionary<int, string> pressureResponse = new Dictionary<int, string>();

    //dialogue option to dict of flag to responses
    //each dialogue option has multiple responses depending on flags
    Dictionary<string, Dictionary<string,string>> allDialogue = new Dictionary<string, Dictionary<string, string>>();

    //dialogue options are available depending on flags
    Dictionary<string, List<string>> flagToDialogueOptions = new Dictionary<string, List<string>>();
    Dictionary<string, string> availableDialogue = new Dictionary<string, string>();

    //show an item only has one response for each item
    Dictionary<string, string> allShow = new Dictionary<string, string>();

    Dictionary<string, string> idToTestimony = new Dictionary<string, string>();
    Dictionary<string, string> testimonyToID = new Dictionary<string, string>();

    Dictionary<string, bool> allFlags = new Dictionary<string, bool>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override string getName()
    {
        return characterName;
    }

    public override string getDefaultShow()
    {
        return "Default show";
    }

    public override string getAccuseAgain()
    {
        return "I've already been accused";
    }

    override public Dictionary<string, Dictionary<string, string>> getAllTalk()
    {
        return allDialogue;
    }

    public override Dictionary<string, List<string>> getFlagToDialogueOptions()
    {
        return flagToDialogueOptions;
    }

    override public Dictionary<string, string> getAvailableTalk()
    {
        return availableDialogue;
    }

    override public Dictionary<string, string> getAllShow() 
    {
        return allShow;
    }

    override public Dictionary<string,string> getTestimonyToID()
    {
        return testimonyToID;
    }

    override public Dictionary<string, string> getIDToTestimony()
    {
        return idToTestimony;
    }

    public override Dictionary<string, bool> getAllFlags()
    {
        return allFlags;
    }

    /*
    void setAvailableTalk()
    {
        availableDialogue.Clear();
        List<string> options = new List<string>();
        foreach (string flag in flagToDialogueOptions.Keys) //loop though sets of dialogue options depending on flag
        {
            if (allFlags.TryGetValue(flag, out bool value))
            {
                options = flagToDialogueOptions[flag];
            }
        }

        if (options.Count == 0)
        {
            options = flagToDialogueOptions["default"];
        }

        foreach (string op in options)
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

            availableDialogue.Add(op, res);
        }


    }
    */

    override public void setFlag(string flag, bool b)
    {
        if (allFlags.ContainsKey(flag))
        {
            allFlags[flag] = b;
        }
        else
        {
            allFlags.Add(flag, b);
        }
    }

    override public float getPressure()
    {
        return pressure;
    }

    override public Dictionary<int,string> getPressureResponse()
    {
        return pressureResponse;
    }

    public override void increasePressure(float p)
    {
        pressure += p;
    }

    public override void decreasePressure(float p)
    {
        pressure -= p;

    }

    public override void setPressure(float p)
    {
        pressure = 0;
    }

    public override void setAccused(bool b)
    {
        accused = b;
    }

    public override bool getAccused()
    {
        return accused;
    }

    public override void setSuccessful(bool b)
    {
        successful = b;
    }

    public override bool getSuccessful()
    {
        return successful;
    }
}
