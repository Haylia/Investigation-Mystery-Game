using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartnerInfo : CharacterInfo
{
    string characterName = "Bernard";

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

        idToTestimony.Add("PartnerIntro",TestimonyMasterList.PartnerIntro);
        idToTestimony.Add("PartnerHost", TestimonyMasterList.PartnerHost);
        idToTestimony.Add("PartnerLocation", TestimonyMasterList.PartnerLocation);
        idToTestimony.Add("PartnerThoughts", TestimonyMasterList.PartnerThoughts);
        idToTestimony.Add("SharesReason", TestimonyMasterList.SharesReason);
        idToTestimony.Add("SharesHost", TestimonyMasterList.SharesHost);

        foreach (KeyValuePair<string, string> entry in idToTestimony)
        {
            testimonyToID.Add(entry.Value, entry.Key);
        }

        Dictionary<string, string> def0 = new Dictionary<string, string>();
        Dictionary<string, string> def1 = new Dictionary<string, string>();
        Dictionary<string, string> def2 = new Dictionary<string, string>();
        Dictionary<string, string> def3 = new Dictionary<string, string>();
        Dictionary<string, string> shares0 = new Dictionary<string, string>();
        Dictionary<string, string> shares1 = new Dictionary<string, string>();

        def0.Add("default", "PartnerIntro");
        def1.Add("default", "PartnerHost");
        def2.Add("default", "PartnerLocation");
        def3.Add("default", "PartnerThoughts");
        shares0.Add("default", "SharesReason");
        shares1.Add("default", "SharesHost");

        allDialogue.Add(TestimonyMasterList.PartnerDefIntro, def0);
        allDialogue.Add(TestimonyMasterList.PartnerDefHost, def1);
        allDialogue.Add(TestimonyMasterList.PartnerDefLocation, def2);
        allDialogue.Add(TestimonyMasterList.PartnerDefThoughts, def3);
        allDialogue.Add(TestimonyMasterList.PartnerSharesReason, shares0);
        allDialogue.Add(TestimonyMasterList.PartnerSharesHost, shares1);

        List<string> defaultOps = new List<string>();
        defaultOps.Add(TestimonyMasterList.PartnerDefIntro);
        defaultOps.Add(TestimonyMasterList.PartnerDefHost);
        defaultOps.Add(TestimonyMasterList.PartnerDefLocation);
        defaultOps.Add(TestimonyMasterList.PartnerDefThoughts);
        List<string> sharesOps = new List<string>();
        sharesOps.Add(TestimonyMasterList.PartnerSharesReason);
        sharesOps.Add(TestimonyMasterList.PartnerSharesHost);

        flagToDialogueOptions.Add("default", defaultOps);
        flagToDialogueOptions.Add("heardSpousePartner", sharesOps);

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
