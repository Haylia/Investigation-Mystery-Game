using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaidInfo : CharacterInfo
{
    string characterName = "Maid";

    bool accused = false;
    bool successful = false;


    float pressure = 0;
    //character dialogue used in accusation
    Dictionary<int, string> pressureResponse = new Dictionary<int, string>();

    //dialogue option to dict of flag to responses
    //each dialogue option has multiple responses depending on flags
    //op -> flag -> res
    Dictionary<string, Dictionary<string, string>> allDialogue = new Dictionary<string, Dictionary<string, string>>();

    //dialogue options are available depending on flags
    //flag -> ops
    Dictionary<string, List<string>> flagToDialogueOptions = new Dictionary<string, List<string>>();
    //op -> res
    Dictionary<string, string> availableDialogue = new Dictionary<string, string>();

    //show an item only has one response for each item
    Dictionary<string, string> allShow = new Dictionary<string, string>();

    Dictionary<string, string> idToTestimony = new Dictionary<string, string>();
    Dictionary<string, string> testimonyToID = new Dictionary<string, string>();

    Dictionary<string, bool> allFlags = new Dictionary<string, bool>();
    // Start is called before the first frame update
    void Start()
    {
        //set pressure responses

        //set all show
        allShow.Add("Newspaper", TestimonyMasterList.MaidDenial);


        //set id to testimony & testimony to id

        //idToTestimony.Add("", "");
        idToTestimony.Add("MaidIntro",TestimonyMasterList.MaidIntro);
        idToTestimony.Add("MaidLying", TestimonyMasterList.MaidLying);
        idToTestimony.Add("MaidHost", TestimonyMasterList.MaidHost);
        idToTestimony.Add("MaidLocation", TestimonyMasterList.MaidLocation);
        idToTestimony.Add("Firing", TestimonyMasterList.Firing);

        foreach(KeyValuePair<string,string> entry in idToTestimony)
        {
            testimonyToID.Add(entry.Value, entry.Key);
        }

        //use ids for responses

        //set dialogue option to responses
        // new dictionary for each op
        // dict flag to response 
        Dictionary<string, string> set0 = new Dictionary<string, string>();
        set0.Add("flag", "id");

        //<DEFAULT>
        Dictionary<string, string> def0 = new Dictionary<string, string>();
        def0.Add("default", "MaidIntro");

        Dictionary<string, string> def1 = new Dictionary<string, string>();
        def1.Add("default", "MaidHost");

        Dictionary<string, string> def2 = new Dictionary<string, string>();
        def2.Add("default", "MaidLocation");

        Dictionary<string, string> def3 = new Dictionary<string, string>();
        def3.Add("default", "Firing");

        // dict set1.Add("op1",dict of flags to responses)
        allDialogue.Add(TestimonyMasterList.MaidDefIntro, def0);
        allDialogue.Add(TestimonyMasterList.MaidDefHost, def1);
        allDialogue.Add(TestimonyMasterList.MaidDefLocation, def2);
        allDialogue.Add(TestimonyMasterList.MaidDefThoughts, def3);

        //set dialogue sets by flag
        //flag to list of dialogue options

        List<string> defaultOps = new List<string>();
        defaultOps.Add(TestimonyMasterList.MaidDefIntro);
        defaultOps.Add(TestimonyMasterList.MaidDefHost);
        defaultOps.Add(TestimonyMasterList.MaidDefLocation);
        defaultOps.Add(TestimonyMasterList.MaidDefThoughts);
        flagToDialogueOptions.Add("default", defaultOps);

        //<SPOUSEHOSTSECRETS>
        Dictionary<string, string> secret = new Dictionary<string, string>();
        secret.Add("default", "MaidLying");
        allDialogue.Add(TestimonyMasterList.MaidSecrets, secret);
        List<string> secretOp = new List<string>();
        secretOp.Add(TestimonyMasterList.MaidSecrets);
        flagToDialogueOptions.Add("heardSpouseHostSecrets", secretOp);


        //SHOWN FLAGS: "shown" + itemName
        //RECORDED TESTIMONY FLAG: "heard" + testimony id
        //RECORDED ITEM FLAG; "has" + itemName



        //set all dialogue (not organised into sets)
        //dict of ops to dict of flags to res
    }

    public override string getDefaultShow()
    {
        return "Default show";
    }

    public override string getAccuseAgain()
    {
        return "I've already been accused";
    }


    //keep same

    public override string getName()
    {
        return characterName;
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

    override public Dictionary<string, string> getTestimonyToID()
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

    override public Dictionary<int, string> getPressureResponse()
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
