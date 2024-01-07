using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EvidenceMasterList
{
    //holds all evidence, characters affective against and score

    static public List<string> evidence = new List<string>();


    static public Dictionary<string, Dictionary<string, float>> evidenceToCharacters = new Dictionary<string, Dictionary<string, float>>
    {
        {"ButlerBreak", butlerBreak},
        {"StaffBreak", staffBreak},
        {"SpouseLocation", spouseLocation},
        {"ButlerLocation", butlerLocation},
        {"HostNecklace", hostNecklace},
        {"GuestHostLove", guestHostLove},
        {"ChefLocation", chefLocation},
        {"ButlerRounds", butlerRounds},
        {"Ledger", ledger},
        {"BankStatement", bankStatement},
        {"HostTiming", hostTiming},
        {"GuestLocation", guestLocation},
        {"ChefThoughts", chefThoughts},
        {"KnifeSource", knifeSource},
        {"GuestLoveLettersMutual", guestLoveLettersMutual},
        {"KitchenOthers", kitchenOthers},
        {"KnifeLocation", knifeLocation},
        {"SpeakingTube", speakingTube},
        {"NoticeOfDismissal", noticeOfDismissal},
        {"FiredHost", firedHost},
        {"LoveLetters", loveLetters},
        {"MaidFamilyPhoto", maidFamilyPhoto},
        {"Newspaper", newspaper},
        {"Firing", firing},
        {"GuestSharesReaction", guestSharesReaction}
    };

    static string butler = "Bartholomew";
    static string maid = "Magaret";
    static string chef = "Chef";
    static string guest = "Agnes";
    static string spouse = "Silvia";
    static string partner = "Bernard";

    static public Dictionary<string, float> butlerLocation = new Dictionary<string, float>
    {
        {butler,1 }
    };

    static public Dictionary<string, float> staffBreak = new Dictionary<string, float>
    {
        {spouse, 1},
        {maid, 1},
        {butler, 1},
        {chef, 1}
    };

    static public Dictionary<string, float> spouseLocation = new Dictionary<string, float>
    {
        {spouse, 2}
    };

    static public Dictionary<string, float> butlerBreak = new Dictionary<string, float>
    {
        {maid, 1},
        {butler, 3},
        {chef, 1}
    };

    static public Dictionary<string, float> hostNecklace = new Dictionary<string, float>
    {
        {maid, 1},
        {butler, 1},
        {chef, 1},
        {guest, (float) 0.5}
    };

    static public Dictionary<string, float> guestOthers = new Dictionary<string, float>
    {
        //{chef, 1}
    };

    static public Dictionary<string, float> guestHostLove = new Dictionary<string, float>
    {
        {guest, 2}
    };

    static public Dictionary<string, float> chefLocation = new Dictionary<string, float>
    {
        {chef, 2},
        {guest, 1},
        {partner, 1}
    };

    static public Dictionary<string, float> butlerRounds = new Dictionary<string, float>
    {
        {spouse, 1},
        {maid, 1},
        {butler, 1},
        {chef, 1}
    };

    static public Dictionary<string, float> ledger = new Dictionary<string, float>
    {
        {spouse, (float) 0.5}
    };

    static public Dictionary<string, float> bankStatement = new Dictionary<string, float>
    {
        {spouse, 1}
    };

    static public Dictionary<string, float> hostTiming = new Dictionary<string, float>
    {
        {spouse, 2},
        {guest, 1},
        {partner, 1}
    };

    static public Dictionary<string, float> guestLocation = new Dictionary<string, float>
    {
        {partner, 2}
    };

    static public Dictionary<string, float> chefThoughts = new Dictionary<string, float>
    {
        {butler, 1}
    };

    static public Dictionary<string, float> knifeSource = new Dictionary<string, float>
    {
        {spouse, (float) 0.5},
        {maid, (float) 0.5},
        {butler, (float) 0.5},
        {chef, 1},
        {guest, (float) 0.25},
        {partner, (float) 0.25},
    };

    static public Dictionary<string, float> guestLoveLettersMutual = new Dictionary<string, float>
    {
        {spouse, 1},
        {guest, 2}
    };

    static public Dictionary<string, float> kitchenOthers = new Dictionary<string, float>
    {
        {spouse, (float) 0.5},
        {maid, (float) 0.5},
        {butler, (float) 0.5},
        {chef, 3},
        //{guest, (float) 0.25},
        //{partner, (float) 0.25},

    };

    static public Dictionary<string, float> knifeLocation = new Dictionary<string, float>
    {
        //{spouse, (float) 0.5},
        //{maid, (float) 0.5},
        //{butler, (float) 0.5},
        //{chef, 1},
        //{guest, (float) 0.25},
        //{partner, (float) 0.25},
    };

    static public Dictionary<string, float> speakingTube = new Dictionary<string, float>
    {
        {maid, 1},
        {chef, 1}
    };

    static public Dictionary<string, float> noticeOfDismissal = new Dictionary<string, float>
    {
        {spouse, 2}
    };

    static public Dictionary<string, float> firedHost = new Dictionary<string, float>
    {
        {spouse, 1}
    };

    static public Dictionary<string, float> loveLetters = new Dictionary<string, float>
    {
        {spouse, 1},
        {guest, 2}
    };

    static public Dictionary<string, float> maidFamilyPhoto = new Dictionary<string, float>
    {
        {maid, (float) 0.5}

    };

    static public Dictionary<string, float> newspaper = new Dictionary<string, float>
    {
        {spouse, 1},
        {maid, (float) 0.5}
    };

    static public Dictionary<string, float> firing = new Dictionary<string, float>
    {
        {spouse, 2}
    };

    static public Dictionary<string, float> guestSharesReaction = new Dictionary<string, float>
    {
        {partner, 2}
    };
}
