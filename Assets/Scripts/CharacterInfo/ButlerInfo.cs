using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButlerInfo : CharacterInfo
{
    string characterName = "Bartholomew";

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
        //pressure response

        idToTestimony.Add("ButlerIntro", TestimonyMasterList.ButlerIntro);
        idToTestimony.Add("ButlerHost", TestimonyMasterList.ButlerHost);
        idToTestimony.Add("ButlerLocation", TestimonyMasterList.ButlerLocation);
        idToTestimony.Add("ButlerThoughts", TestimonyMasterList.ButlerThoughts);
        idToTestimony.Add("ButlerBreak", TestimonyMasterList.ButlerBreak);
        idToTestimony.Add("ButlerRounds", TestimonyMasterList.ButlerRounds);
        idToTestimony.Add("ButlerReaction", TestimonyMasterList.ButlerReaction);

        foreach (KeyValuePair<string, string> entry in idToTestimony)
        {
            testimonyToID.Add(entry.Value, entry.Key);
        }

        Dictionary<string, string> def0 = new Dictionary<string, string>();
        Dictionary<string, string> def1 = new Dictionary<string, string>();
        Dictionary<string, string> def2 = new Dictionary<string, string>();
        Dictionary<string, string> def3 = new Dictionary<string, string>();
        Dictionary<string, string> b = new Dictionary<string, string>();
        Dictionary<string, string> rounds = new Dictionary<string, string>();
        Dictionary<string, string> reaction = new Dictionary<string, string>();

        def0.Add("default", "ButlerIntro");
        def1.Add("default", "ButlerHost");
        def2.Add("default", "ButlerLocation");
        def3.Add("default","ButlerThoughts");
        b.Add("default", "ButlerBreak");
        rounds.Add("default", "ButlerRounds");
        reaction.Add("default", "ButlerReaction");

        allDialogue.Add(TestimonyMasterList.ButlerDefIntro,def0);
        allDialogue.Add(TestimonyMasterList.ButlerDefHost, def1);
        allDialogue.Add(TestimonyMasterList.ButlerDefLocation, def2);
        allDialogue.Add(TestimonyMasterList.ButlerDefThoughts, def3);
        allDialogue.Add(TestimonyMasterList.ButlerConfirmBreak, b);
        allDialogue.Add(TestimonyMasterList.ButlerBreakRounds, rounds);
        allDialogue.Add(TestimonyMasterList.ButlerChefThoughts, reaction);

        List<string> defaultOps = new List<string>();
        defaultOps.Add(TestimonyMasterList.ButlerDefIntro);
        defaultOps.Add(TestimonyMasterList.ButlerDefHost);
        defaultOps.Add(TestimonyMasterList.ButlerDefLocation);
        defaultOps.Add(TestimonyMasterList.ButlerDefThoughts);
        List<string> bOp = new List<string>();
        bOp.Add(TestimonyMasterList.ButlerConfirmBreak);
        List<string> roundsOp = new List<string>();
        roundsOp.Add(TestimonyMasterList.ButlerBreakRounds);
        List<string> chefOp = new List<string>();
        chefOp.Add(TestimonyMasterList.ButlerChefThoughts);

        flagToDialogueOptions.Add("default", defaultOps);
        flagToDialogueOptions.Add("heardStaffBreak", bOp);
        flagToDialogueOptions.Add("heardButlerBreak", roundsOp);
        flagToDialogueOptions.Add("heardChefThoughts", chefOp);

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
