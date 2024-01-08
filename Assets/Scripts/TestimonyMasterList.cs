using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TestimonyMasterList
{
    public static string testimonyID = "testimony contents";

    //<MAID>
    //Maid dialogue options
    public static string MaidDefIntro = "Who are you?";
    public static string MaidDefHost = "What were you feelings towards Heather?";
    public static string MaidDefLocation = "Where were you at the time of the murder?";
    public static string MaidDefThoughts = "Is there anything else you want to tell me?";
    public static string MaidSecrets = "Silvia says you are lying about telling Heather"; //#SpouseHostSecrets
    //Maid dialogue responses (ids from Miro board)
    public static string MaidIntro = "I am Margaret the Maid, and I am responsible for the upkeep of this house. If you need anything done do ask me.";
    public static string MaidLying = "I am not! I would never!";
    public static string MaidHost = @"I’ve been working in this house for the last 7 years and I know Heather on a personal level. 
    I believe this family looks out for me back as I do for them";
    public static string MaidLocation = "I was in my room in the Servants' Quarters";
    public static string Firing = @"I found this hidden earlier when I was cleaning. I showed it to Heather as I thought I would be looking out for them.
    They seemed so very upset by Silvia.
    I also heard Silvia talking on the phone about something called a bee settlement? I Silvia didn't hurt any bees!
    *** YOU AQUIRED [NOTICE OF DISMISSAL]";
    //Maid show responses
    public static string MaidDenial = "These are just some random newspapers they have nothing to do with me."; //SHOW Newspaper

    //<BUTLER>
    public static string ButlerDefIntro = "Who are you?";
    public static string ButlerDefHost = "What were your feelings towards Heather?";
    public static string ButlerDefLocation = "Where were you at the time of the murder?";
    public static string ButlerDefThoughts = "Is there anything you want to tell me?";
    public static string ButlerConfirmBreak = "Apparently, you and the rest of the staff were given a break by Silvia."; //#StaffBreak
    public static string ButlerBreakRounds = "What did you do in the break?"; //#ButlerBreak
    public static string ButlerChefThoughts = "The Chef thinks you may have resented the amount of work you do and how little time you were given to do it"; //#ChefThoughts

    public static string ButlerIntro = "Yes, Bartholomew is my name and I was on duty last night. I met every guest at the door and can confirm that the people gathered here were the only people on the premises last night.";
    public static string ButlerHost = "I’ve been the family butler for 5 years, and I was previously a chef hand for another 5. The chef didn’t need my help and the previous butler wasn’t as good a fit as I believe I am for the position. All these decisions were overseen by Heather so I felt like an understood employee";
    public static string ButlerLocation = "Last night I was on guard duty between the entrance and parlour all night. I even ate my dinner at my post so there's no chance anyone slipped past me.";
    public static string ButlerThoughts = "I have sensed no ill will from any of the members of this household. These events are shocking and horrifying.";
    public static string ButlerBreak = "I confirm we were given a break, and I informed the rest of the staff";
    public static string ButlerRounds = "I didn't see anyone go to the top floor on my rounds. There are hidden routes for the servant crew to move around the house while not disturbing the residents. The residents would never use any of these paths.";
    public static string ButlerReaction = "How dare he! How dare you undermine the work I do and my relationship with my employers. I will be having some stern words once this is sorted out!";

    //<PARTNER>
    public static string PartnerDefIntro = "Who are you?";
    public static string PartnerDefHost = "What were your feelings towards Heather?";
    public static string PartnerDefLocation = "Where were you at the time of the murder?";
    public static string PartnerDefThoughts = "Is there anything you want to tell me?";
    public static string PartnerSharesReason = "I found evidence that you wanted Heather's part in the business. What do you have to say to this?"; //#SpousePartner
    public static string PartnerSharesHost = "And what happened?"; //#SpousePartner

    public static string PartnerIntro = "I’m Bernard, Co-owner of a business with Heather. As an entrepreneur, I would consider it to be my best…and only…success. I live across town with my family";
    public static string PartnerHost = "We met around 10 years ago now, in a bar in the next city. I had just declared bankruptcy, she had just bombed a pitch meeting. We hit it off, came up with the business in a drunken stupor, and the rest is history. I particularly respect her work ethic. She did well for herself and Silvia.";
    public static string PartnerLocation = "I spent most of the evening in the parlour, with the exception of sitting down for dinner of course! ";
    public static string PartnerThoughts = "All I'll add is Silvia and Heather must have been doing better than me, I'm not sure how but they make their income go further than I do for my family. I put it down to clever investments.";
    public static string SharesReason = "Well... It doesn't exactly paint me in the best light, but in the interest of the truth and justice I'll lay it out for you. I wanted Heather's share of our business, to keep it in my family. Don't get me wrong though, thats not motive for me to kill Heather!";
    public static string SharesHost = "Heather refused my offer. Unfortunate really, but I saw Heather in a renewed light, like she was doubling down on the work and investments she'd already put in. Really, it would benefit me much mroe if she were still with us...";

    //<CHEF>
    public static string ChefDefIntro = "Who are you?";
    public static string ChefDefHost = "What were your feelings towards Heather?";
    public static string ChefDefLocation = "Where were you at the time of the murder?";
    public static string ChefDefThoughts = "Is there anything you want to tell me?";
    public static string ChefKnifeLocation = "So where was the knife before the murder happened?"; //shownKnife
    public static string ChefKitchenOthers = "Who did you see going in and out of the kitchen?"; //shownKnife

    public static string ChefIntro = "I'm Chef.";
    public static string ChefHost = "No real opinion. They pay me, I work for them, I live another day. What's not to like?";
    public static string ChefLocation = "Where do you think? I'm the Chef. I was in the kitchen most of the night, but I left briefly for a break.";
    public static string ChefThoughts = "Hmm, only thing I can think of is Barty the Butler may have been at his limit. He's seemed a bit uptight and stressed, particularly lately. ";
    public static string KnifeLocation = "That knife was in the kitchen before the party and I hav'nt seen it since. Probably wasn't even washed.";
    public static string KitchenOthers = "While I was in the kitchen, there were no non staff. Not something I usually pay attention to. There were no visitors I wasn't expecting.";

    public static string KnifeSource = "Ah, that's one of mine! And what a state it's in too..."; //SHOW Knife

    //<GUEST>
    public static string GuestDefIntro = "Who are you?";
    public static string GuestDefHost = "What were your feelings towards Heather?";
    public static string GuestDefLocation = "Where were you at the time of the murder?";
    public static string GuestDefThoughts = "Is there anything you want to tell me?";
    public static string GuestHostKnow = "Did Heather know of your doting on Silvia?"; //shownLoveLetters
    public static string GuestMutual = "Was your love mutual?"; //shownLoveLetters
    public static string GuestSharesWhy = "Do you know why your boss wanted Heather's shares in the business?"; //#SpousePartner
    public static string GuestSharesPartner = "Do you have more insight on Bernards reaction to his offer being turned down?"; //#SpousePartner

    public static string GuestIntro = "I'm Agnes! Bernard's assistant! I've never been in this house before because I wasn't allowed! Its sooo fancy!";
    public static string GuestHostDefault = "Oooohh... purely professional relationship! We don't talk outside of work usually!";
    public static string GuestHostLove = "Okayyy so maybe I have a secret love...is that such a crime?! So what if I wrote these letters?"; //shownLoveLetters
    public static string GuestLocation = "I thinkkk I was in the parlour...I'm not sure who I was with but whoever it was was very funny!";
    public static string GuestThoughts = "Nowww I don't want to point fingers... But I think the staff in this house are VERY shifty! Most definitely up to something but I couldn't tell you what!";
    public static string GuestLoveLettersHost = "Did Heather know? I hope not! My letters were very secret...I dont think she knew.";
    public static string GuestLoveLettersMutual = "One day I hope it is!!!";
    public static string GuestSharesReason = "All I know is there was money in it for me! Our business is very profitable so Bernard and I want a bigger slice of the pie!";
    public static string GuestSharesReaction = "Oh he turned soooo red! The angriest I have EVER seen him!";

    public static string GuestLoveLetters = "oohhhh... soooo about that... Well, I wrote those... haha"; //SHOW LoveLetters

    //<SPOUSE>
    public static string SpouseDefIntro = "Who are you?";
    public static string SpouseDefHost = "What were your feelings towards Heather?";
    public static string SpouseDefLocation = "Where were you at the time of the murder?";
    public static string SpouseDefHostWhy = "Why did Heather leave the Parlour before the rest of the party?";
    public static string SpouseDefHostWhen = "Do you know roughly what time she left? What else was happening at the time?";
    public static string SpouseDefOther = "Is there anything else you want to tell me?";
    public static string SpouseLocationAlibi = "Can anyone vouch for your whereabouts when you left the parlour?"; //#SpouseLocation
    public static string SpouseEmbezzlementReason = "I found these while looking around. Care to explain?"; //hasLedger&BankStatement
    public static string SpouseEmbezzlementHost = "Did Heather know you were doing this?"; //hasLedger&BankStatement
    public static string SpouseFiredReason = "Why were you fired?"; //#Firing
    public static string SpouseFiredHost = "What was Heather's reaction to you being fired?"; //#Firing
    public static string SpouseLoveMutual = "Was your love for the person who wrote these letters mutual?"; //hasLoveLetters
    public static string SpouseLoveHost = "Did Heather know about the love letters?"; //hasLoveLetters
    public static string SpouseDefThoughts = "What are your opinions on the other people present today?";


    public static string SpouseIntro = @"Oh my turn darling? I'm Heather's wife Silvia! We've been married 25 years as of last weekend
    hence the party I co-hosted! Truly a drag that such a wonderful night has been ruined.";
    public static string SpouseHostDefault = @"Our relationship was just dandy! As with all couples we had our little tiffs but 
    Heather was truly all I could ask for in a spouse";
    public static string SpouseHostSecrets = @"Oh the firing...No I didn't tell Heather. With my expertise and experience I was hoping
    to find another job and put on a show about wanting a fresh environment"; //#FiredHost
    public static string SpouseLocation = @"Well I was in the parlour with the rest of the party guests, and retired to the study early to
    finish off some work I started earlier";
    public static string SpousePartner = "Heather told me recently that Bernard over there tried to buy out her share in the business.";
    public static string HostNecklace = @"I noticed that Heather's Diamond necklace that she was wearing today was missing. If you come across that
    do let me know as I am quite worried!";
    public static string HostReason = "Ah Heather told me she was feeling unwell and wanted to lie down for a bit. She assured me she would be okay and would come back soon";
    public static string HostTiming = "Well, I left the room first but as I say she told me she was going to lie down. I didn't see or hear her leave as I wasn't there. I didn't see any staff while I was walking about the house";
    public static string StaffBreak = "On the way out, I told the butler to put the rest of the staff on a break as they had been working ever so hard for the party this evening.";
    public static string EmbezzlementReason = @"Well, I got such a kick out of doing it the first time that I just had to keep doing
    it. The rush I got was simply unparalled and the thist to keep going remained unquenched";
    public static string EmbezzlementHost = "Oh Heather had no idea! That was all part of the fun!";
    public static string FiredDefault = "That note means nothing. Just a fake document to make me look bad.";
    public static string FiredReason = "Well obviously you know I was embezzling... why even ask the question?"; //#EmbezzlementReason
    public static string FiredHost = "Heather didn't know I was fired. She never mentioned it and obviously neither did I.";
    public static string SpouseLoveLettersMutual = "Don't be preposterous! This party was for 25 years of marriage not three months of silly letters!";
    public static string SpouseLoveLettersHost = "Wyh would I bother Heather with my fan mail?";
}
