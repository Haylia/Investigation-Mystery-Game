using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TestimonyMasterList
{
    public static string testimonyID = "testimony contents";

    //<MAID>
    //Maid dialogue options
    public static string MaidDefIntro = "Who are you?";
    public static string MaidDefHost = "What were you feelings towards {Host}?";
    public static string MaidDefLocation = "Where were you at the time of the murder?";
    public static string MaidDefThoughts = "Is there anything else you want to tell me?";
    public static string MaidSecrets = ""; //#SpouseHostSecrets
    //Maid dialogue responses (ids from Miro board)
    public static string MaidIntro = "I am {MAID NAME} the Maid, and I am responsible for the upkeep of this house. If you need anything done do ask me.";
    public static string MaidLying = "";
    public static string MaidHost = @"I’ve been working in this house for the last 7 years and I know {HOST NAME} on a personal level. 
                                    I believe this family looks out for me back as I do for them";
    public static string MaidLocation = "I was in my room in the Servants' Quarters";
    public static string Firing = @"I found this hidden earlier when I was cleaning. I showed it to {HOST} as I thought I would be looking out for them.
                                   They seemed so very upset by {SPOUSE}.
                                   *** YOU AQUIRED [NOTICE OD DISMISSAL]";
    //Maid show responses
    public static string MaidDenial = "These are just some random newspapers they have nothing to do with me."; //SHOW Newspaper

    //<BUTLER>
    public static string ButlerDefIntro = "";
    public static string ButlerDefHost = "";
    public static string ButlerDefLocation = "";
    public static string ButlerDefThoughts = "";
    public static string ButlerConfirmBreak = ""; //#StaffBreak
    public static string ButlerBreakRounds = ""; //#ButlerBreak
    public static string ButlerChefThoughts = ""; //#ChefThoughts

    public static string ButlerIntro = "";
    public static string ButlerHost = "";
    public static string ButlerLocation = "";
    public static string ButlerThoughts = "";
    public static string ButlerBreak = "";
    public static string ButlerRounds = "";
    public static string ButlerReaction = "";

    //<PARTNER>
    public static string PartnerDefIntro = "";
    public static string PartnerDefHost = "";
    public static string PartnerDefLocation = "";
    public static string PartnerDefThoughts = "";
    public static string PartnerSharesReason = ""; //#SpousePartner
    public static string PartnerSharesHost = ""; //#SpousePartner

    public static string PartnerIntro = "";
    public static string PartnerHost = "";
    public static string PartnerLocation = "";
    public static string PartnerThoughts = "";
    public static string SharesReason = "";
    public static string SharesHost = "";

    //<CHEF>
    public static string ChefDefIntro = "";
    public static string ChefDefHost = "";
    public static string ChefDefLocation = "";
    public static string ChefDefThoughts = "";
    public static string ChefKnifeLocation = ""; //shownKnife
    public static string ChefKnifeOthers = ""; //shownKnife

    public static string ChefIntro = "";
    public static string ChefHost = "";
    public static string ChefLocation = "";
    public static string ChefThoughts = "";
    public static string KnifeLocation = "";
    public static string KnifeOthers = "";

    public static string KnifeSource = ""; //SHOW Knife

    //<GUEST>
    public static string GuestDefIntro = "";
    public static string GuestDefHost = "";
    public static string GuestDefLocation = "";
    public static string GuestDefThoughts = "";
    public static string GuestHostKnow = ""; //shownLoveLetters
    public static string GuestMutual = ""; //shownLoveLetters
    public static string GuestSharesWhy = ""; //#SpousePartner
    public static string GuestSharesPartner = ""; //#SpousePartner

    public static string GuestIntro = "";
    public static string GuestHostDefault = "";
    public static string GuestHostLove = ""; //shownLoveLetters
    public static string GuestLocation = "";
    public static string GuestThoughts = "";
    public static string GuestLoveLettersHost = "";
    public static string GuestLoveLettersMutual = "";
    public static string GuestSharesReason = "";
    public static string GuestSharesReaction = "";

    public static string GuestLoveLetters = ""; //SHOW LoveLetters

    //<SPOUSE>
    public static string SpouseDefIntro = "";
    public static string SpouseDefHost = "";
    public static string SpouseDefLocation = "";
    public static string SpouseDefThoughts = "";
    public static string SpouseDefHostWhy = "";
    public static string SpouseDefHostWhen = "";
    public static string SpouseDefOther = "";
    public static string SpouseLocationAlibi = ""; //#SpouseLocation
    public static string SpouseEmbezzlementReason = ""; //hasLedger&BankStatement
    public static string SpouseEmbezzlementHost = ""; //hasLedger&BankStatement
    public static string SpouseFiredReason = ""; //#Firing
    public static string SpouseFiredHost = ""; //#Firing
    public static string SpouseLoveMutual = ""; //hasLoveLetters
    public static string SpouseLoveHost = ""; //hasLoveLetters

    public static string SpouseIntro = "";
    public static string SpouseHostDefault = "";
    public static string SpouseHostSecrets = ""; //#FiredHost
    public static string SpouseLocation = "";
    public static string SpousePartner = "";
    public static string HostNecklace = "";
    public static string HostReason = "";
    public static string HostTiming = "";
    public static string StaffBreak = "";
    public static string EmbezzlementReason = "";
    public static string EmbezzlementHost = "";
    public static string FiredDefault = "";
    public static string FiredReason = ""; //#EmbezzlementReason
    public static string FiredHost = "";
    public static string SpouseLoveLettersMutual = "";
    public static string SpouseLoveLettersHost = "";
}
