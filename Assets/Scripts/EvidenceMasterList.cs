using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvidenceMasterList : MonoBehaviour
{
    //holds all evidence, characters affective against and score
    public Dictionary<string, Dictionary<string, float>> evidenceToCharacters;

    private void Start()
    {

        string butler = "Bartholomew";
        string maid = "Margaret";
        string chef = "Chef";
        string guest = "Agnes";
        string spouse = "Silvia";
        string partner = "Bernard";

        Dictionary<string, float> butlerLocation = new Dictionary<string, float>
    {
        {butler,1 }
    };

        Dictionary<string, float> staffBreak = new Dictionary<string, float>
    {
        {spouse, 1},
        {maid, 1},
        {butler, 1},
        {chef, 1}
    };

        Dictionary<string, float> spouseLocation = new Dictionary<string, float>
    {
        {spouse, 2}
    };

        Dictionary<string, float> butlerBreak = new Dictionary<string, float>
    {
        {maid, 1},
        {butler, 3},
        {chef, 1}
    };

        Dictionary<string, float> hostNecklace = new Dictionary<string, float>
    {
        {maid, 1},
        {butler, 1},
        {chef, 1},
        {guest, (float) 0.5}
    };

        Dictionary<string, float> guestOthers = new Dictionary<string, float>
        {
            //{chef, 1}
        };

        Dictionary<string, float> guestHostLove = new Dictionary<string, float>
    {
        {guest, 2}
    };

        Dictionary<string, float> chefLocation = new Dictionary<string, float>
    {
        {chef, 2},
        {guest, 1},
        {partner, 1}
    };

        Dictionary<string, float> butlerRounds = new Dictionary<string, float>
    {
        {spouse, 1},
        {maid, 1},
        {butler, 1},
        {chef, 1}
    };

        Dictionary<string, float> ledger = new Dictionary<string, float>
    {
        {spouse, (float) 0.5}
    };

        Dictionary<string, float> bankStatement = new Dictionary<string, float>
    {
        {spouse, 1}
    };

        Dictionary<string, float> hostTiming = new Dictionary<string, float>
    {
        {spouse, 2},
        {guest, 1},
        {partner, 1}
    };

        Dictionary<string, float> guestLocation = new Dictionary<string, float>
    {
        {partner, 2}
    };

        Dictionary<string, float> chefThoughts = new Dictionary<string, float>
    {
        {butler, 1}
    };

        Dictionary<string, float> knifeSource = new Dictionary<string, float>
    {
        {spouse, (float) 0.5},
        {maid, (float) 0.5},
        {butler, (float) 0.5},
        {chef, 1},
        {guest, (float) 0.25},
        {partner, (float) 0.25},
    };

        Dictionary<string, float> guestLoveLettersMutual = new Dictionary<string, float>
    {
        {spouse, 1},
        {guest, 2}
    };

        Dictionary<string, float> kitchenOthers = new Dictionary<string, float>
    {
        {spouse, (float) 0.5},
        {maid, (float) 0.5},
        {butler, (float) 0.5},
        {chef, 3},
        //{guest, (float) 0.25},
        //{partner, (float) 0.25},

    };

        Dictionary<string, float> knifeLocation = new Dictionary<string, float>
        {
            //{spouse, (float) 0.5},
            //{maid, (float) 0.5},
            //{butler, (float) 0.5},
            //{chef, 1},
            //{guest, (float) 0.25},
            //{partner, (float) 0.25},
        };

        Dictionary<string, float> speakingTube = new Dictionary<string, float>
    {
        {maid, 1},
        {chef, 1}
    };

        Dictionary<string, float> noticeOfDismissal = new Dictionary<string, float>
    {
        {spouse, 2}
    };

        Dictionary<string, float> firedHost = new Dictionary<string, float>
    {
        {spouse, 1}
    };

        Dictionary<string, float> loveLetters = new Dictionary<string, float>
    {
        {spouse, 1},
        {guest, 2}
    };

        Dictionary<string, float> maidFamilyPhoto = new Dictionary<string, float>
    {
        {maid, (float) 0.5}

    };

        Dictionary<string, float> newspaper = new Dictionary<string, float>
    {
        {spouse, 1},
        {maid, (float) 0.5}
    };

        Dictionary<string, float> firing = new Dictionary<string, float>
    {
        {spouse, 2}
    };

        Dictionary<string, float> guestSharesReaction = new Dictionary<string, float>
    {
        {partner, 2}
    };

        evidenceToCharacters = new Dictionary<string, Dictionary<string, float>>
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
    }


}
