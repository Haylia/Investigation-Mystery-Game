using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpouseScript : CharacterInfo
{
    string characterName = "Silvia";

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
        idToTestimony.Add("SpouseIntro", TestimonyMasterList.SpouseIntro);
        idToTestimony.Add("SpouseHostDefault", TestimonyMasterList.SpouseHostDefault);
        idToTestimony.Add("SpouseHostSecrets", TestimonyMasterList.SpouseHostSecrets);
        idToTestimony.Add("SpouseLocation", TestimonyMasterList.SpouseLocation);
        idToTestimony.Add("SpousePartner", TestimonyMasterList.SpousePartner);
        idToTestimony.Add("HostReason", TestimonyMasterList.HostReason);
        idToTestimony.Add("HostTiming", TestimonyMasterList.HostTiming);
        idToTestimony.Add("HostNecklace", TestimonyMasterList.HostNecklace);
        idToTestimony.Add("StaffBreak", TestimonyMasterList.StaffBreak);
        idToTestimony.Add("EmbezzlementReason", TestimonyMasterList.EmbezzlementReason);
        idToTestimony.Add("EmbezzlementHost", TestimonyMasterList.EmbezzlementHost);
        idToTestimony.Add("FiredDefault", TestimonyMasterList.FiredDefault);
        idToTestimony.Add("FiredReason", TestimonyMasterList.FiredReason);
        idToTestimony.Add("FiredHost", TestimonyMasterList.FiredHost);
        idToTestimony.Add("SpouseLoveLettersMutual", TestimonyMasterList.SpouseLoveLettersMutual);
        idToTestimony.Add("SpouseLoveLettersHost", TestimonyMasterList.SpouseLoveLettersHost);

        Dictionary<string, string> def0 = new Dictionary<string, string>();
        Dictionary<string, string> def1 = new Dictionary<string, string>();
        Dictionary<string, string> def2 = new Dictionary<string, string>();
        Dictionary<string, string> def3 = new Dictionary<string, string>();
        Dictionary<string, string> def4 = new Dictionary<string, string>();
        Dictionary<string, string> def5 = new Dictionary<string, string>();
        Dictionary<string, string> def6 = new Dictionary<string, string>();

        def0.Add("default", "SpouseIntro");
        def1.Add("default", "SpouseHostDefault");
        def1.Add("heardFiredHost", "SpouseHostSecrets");
        def2.Add("default", "SpouseLocation");
        def2.Add("default", "SpousePartner");
        def2.Add("default", "HostReason");
        def2.Add("default", "HostTiming");
        def2.Add("default", "HostNecklace");

        allDialogue.Add(TestimonyMasterList.SpouseDefIntro, def0);
        allDialogue.Add(TestimonyMasterList.SpouseDefHost, def1);
        allDialogue.Add(TestimonyMasterList.SpouseDefLocation, def2);
        allDialogue.Add(TestimonyMasterList.SpouseDefThoughts, def3);
        allDialogue.Add(TestimonyMasterList.SpouseDefHostWhy, def4);
        allDialogue.Add(TestimonyMasterList.SpouseDefHostWhen, def5);
        allDialogue.Add(TestimonyMasterList.SpouseDefOther, def6);

        List<string> defaultOps = new List<string>();
        defaultOps.Add(TestimonyMasterList.SpouseDefIntro);
        defaultOps.Add(TestimonyMasterList.SpouseDefHost);
        defaultOps.Add(TestimonyMasterList.SpouseDefLocation);
        defaultOps.Add(TestimonyMasterList.SpouseDefThoughts);
        defaultOps.Add(TestimonyMasterList.SpouseDefHostWhy);
        defaultOps.Add(TestimonyMasterList.SpouseDefHostWhen);
        defaultOps.Add(TestimonyMasterList.SpouseDefOther);

        flagToDialogueOptions.Add("default", defaultOps);

        Dictionary<string, string> location = new Dictionary<string, string>();

        location.Add("default", "StaffBreak");

        allDialogue.Add(TestimonyMasterList.SpouseLocationAlibi, location);

        List<string> locOp = new List<string>();
        locOp.Add(TestimonyMasterList.SpouseLocationAlibi);

        flagToDialogueOptions.Add("heardSpouseLocation", locOp);

        Dictionary<string, string> embezzle0 = new Dictionary<string, string>();
        Dictionary<string, string> embezzle1 = new Dictionary<string, string>();

        embezzle0.Add("default", "EmbezzlementReason");
        embezzle1.Add("default", "EmbezzlementHost");

        allDialogue.Add(TestimonyMasterList.SpouseEmbezzlementReason, embezzle0);
        allDialogue.Add(TestimonyMasterList.SpouseEmbezzlementHost, embezzle1);

        List<string> embezzlementOps = new List<string>();
        embezzlementOps.Add(TestimonyMasterList.SpouseEmbezzlementReason);
        embezzlementOps.Add(TestimonyMasterList.SpouseEmbezzlementHost);

        flagToDialogueOptions.Add("hasLedger&BankStatement",embezzlementOps);

        Dictionary<string, string> fired0 = new Dictionary<string, string>();
        Dictionary<string, string> fired1 = new Dictionary<string, string>();

        fired0.Add("default", "FiredDefault");
        fired0.Add("heardEmbezzlementReason", "FiredReason");
        fired1.Add("default", "FiredHost");

        allDialogue.Add(TestimonyMasterList.SpouseFiredReason, fired0);
        allDialogue.Add(TestimonyMasterList.SpouseFiredHost, fired1);

        List<string> firedOps = new List<string>();
        firedOps.Add(TestimonyMasterList.SpouseFiredReason);
        firedOps.Add(TestimonyMasterList.SpouseFiredHost);

        flagToDialogueOptions.Add("heardFiring", firedOps);

        Dictionary<string, string> love0 = new Dictionary<string, string>();
        Dictionary<string, string> love1 = new Dictionary<string, string>();

        love0.Add("default", "SpouseLoveLettersMutual");
        love1.Add("default", "SpouseLoveLettersHost");

        allDialogue.Add(TestimonyMasterList.SpouseLoveMutual, love0);
        allDialogue.Add(TestimonyMasterList.SpouseLoveHost, love1);

        List<string> loveOps = new List<string>();
        loveOps.Add(TestimonyMasterList.SpouseLoveMutual);
        loveOps.Add(TestimonyMasterList.SpouseLoveHost);

        flagToDialogueOptions.Add("hasLoveLetters", loveOps);

        pressureResponse.Add(0, "You have no evidence pointing to me");
        pressureResponse.Add(1, "It's just a misunderstanding, you can see that. That by itself doesn't really prove anything anyway");
        pressureResponse.Add(2, "You have it all wrong, I can explain!");
        pressureResponse.Add(3, "Ahem... it looks bad for me... but I maintain my innocence!");
        pressureResponse.Add(4, "I won't stand for this! This is ridiculous!");
        pressureResponse.Add(5, "I feel so exposed... but I didn't do it!");
        pressureResponse.Add(6, "Oh god... surely some of this stuff is planted...");
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
