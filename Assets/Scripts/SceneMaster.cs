using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMaster : MonoBehaviour
{
    private CharacterInfo[] characters;
    private ProtagInfo protagInfo;
    private GameObject endTextObj;
    TMPro.TextMeshProUGUI tmp;
    private GameObject endTextcanvas;
    // Start is called before the first frame update
    void Start()
    {
        characters = GameObject.Find("Characters").GetComponentsInChildren<CharacterInfo>();
        protagInfo = GameObject.Find("Protag").GetComponent<ProtagInfo>();
        endTextObj = GameObject.Find("TheEndText");
        tmp = endTextObj.GetComponent<TMPro.TextMeshProUGUI>();
        endTextcanvas = GameObject.Find("Ending Text");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkEndingReached()
    {
        Debug.Log(protagInfo.lives);
        string ending= "";
        if (protagInfo.lives == 0)
        {
            ending = "failed";
        }
        else
        {
            foreach (CharacterInfo c in characters)
            {
                if (c.getSuccessful() == true)
                {
                    ending = c.getName();
                    break;
                }
            }
        }

        if (protagInfo.getAllFlags().ContainsKey("hasLedger&BankStatement") && ending == "Margaret")
        {
            ending = ending + "2";
        }
        Debug.Log(ending);
        if (ending != "")
        {
            endingStart(ending);
        }
        
    }

    public void endingStart(string e)
    {
        Debug.Log("setting ending text");
        //if statement to decide text
        string endText;
        if(e == "failed")
        {
            endText = "You were ridiculed and removed from the scene... try looking at the evidence more closely!";
        }
        else if(e == "Bartholomew") 
        {
            endText = @"You accused Bartholomew of the murder of Heather.
                        He goes to jail, and no one pays his bail.
                        During his grossly one-sided trial, Silvia is murdered in her home in the dead of night.
                        Despite all the proceedings and investigation, the necklace was never found.
                        This event does little for your career as a detective, as the man behind bars had little of a public profile.
                        As for the other characters:
                        Margaret was never seen or heard from again. It seems she distanced herself from all involved.
                        Chef decided to keep his cooking talents to himself and retire
                        Bernard took over Heathers side of the business
                        Agnes, When seen in public, only wore black with a veil covering her face."; //butler goes to jail, spouse gets killed off after. protag career is a ok. necklace spontaneously combusts?????
        }
        else if (e == "Chef")
        {
            endText = @"You accused Chef of the murder of Heather.
                        He goes to jail, and no one pays his bail.
                        During his grossly one-sided trial, Silvia is murdered in her home in the dead of night.
                        Despite all the proceedings and investigation, the necklace was never found.
                        This event does little for your career as a detective, as the man behind bars had little of a public profile.
                        As for the other characters:
                        Margaret was never seen or heard from again. It seems she distanced herself from all involved.
                        Bartholomew had no issue finding other, incredibly similar employment. His repute for hard work and a job well done paid off.
                        Bernard took over Heathers side of the business.
                        Agnes, When seen in public, only wore black with a veil covering her face."; //Chef goes to jail, spouse gets killed off, protag career is thriving. necklace spontaneously combusts?????
        }
        else if (e == "Agnes")
        {
            endText = @"You accused Agnes of the murder of Heather.
                        She goes to jail, but her bail is paid for in full by Bernard
                        During the bail proceedings, Silvia is murdered in her home in the dead of night.
                        Despite all the proceedings and investigation, the necklace was never found.
                        This event does little for your career as a detective, as you failed to keep anyone in jail and no prized prosession was recovered.
                        After some time had passed, Agnes released a ghostwritten novel detailing her trauma in the happenings of the night, becoming a national bestseller.
                        As for the other characters:
                        Margaret was never seen or heard from again. It seems she distanced herself from all involved.
                        Chef decided to keep his cooking talents to himself and retire
                        Bartholomew had no issue finding other, incredibly similar employment. His repute for hard work and a job well done paid off.
                        Bernard took over Heathers side of the business"; //agnes is tried but is bailed out by bernard, but not before Silvia is murdered! Agnes hires a ghostwriter and becomes a national bestseller, and the necklace is off into the void
        }
        else if (e == "Bernard")
        {
            endText = @"You accused Bernard of the murder of Heather.
                        He pays his own bail before even going past the front desk at the police station.
                        During the bail proceedings, Silvia is murdered in her home, almost like someone was just waiting for the authorities to leave to finish the job.
                        After a legal battle, the business eventually goes in its entirety to Bernard. With it and Bernard's damaged reputation, any plans for future success were ruined before they even began
                        Despite all the proceedings and investigation, the necklace was never found.
                        This event initially does little for your career as a detective, as you failed to keep anyone in jail and no prized prosession was recovered,
                        but in less than a year Bernard comes after you and sues for damages as he blames you for the business failure and leaves you penniless
                        As for the other characters:
                        Margaret was never seen or heard from again. It seems she distanced herself from all involved.
                        Chef decided to keep his cooking talents to himself and retire
                        Bartholomew had no issue finding other, incredibly similar employment. His repute for hard work and a job well done paid off.
                        Agnes, When seen in public, only wore black with a veil covering her face."; //bernard got some of that cash cash so hes fine. after some trial he acquires heathers business shares, but due to the news his reputation is damaged. spouse is killed while bernard is on trial. bernard sues protag after his own trial
        }
        else if (e == "Silvia")
        {
            endText = @"You accused Silvia of the murder of Heather.
                        She is found guilty, and due to previous scandal has her bail set far too high for any respectable person
                        You are hailed a hero for bringing her in, and you get a boost in your career standing
                        The only person to visit Silvia in jail is Agnes
                        As for the other characters:
                        Margaret was never seen or heard from again. It seems she distanced herself from all involved.
                        Chef decided to keep his cooking talents to himself and retire
                        Bartholomew had no issue finding other, incredibly similar employment. His repute for hard work and a job well done paid off.
                        Agnes, When seen in public, only wore black with a veil covering her face.
                        Bernard took over Heathers side of the business."; //Silvia jailed for multiple crimes, protag hailed as a hero. Silvia is visited in jail by agnes. necklace never found. people arent sure where she found time to do the murdering
        }
        else if (e == "Margaret")
        {
            endText = @"You accused Margaret of the murder of Heather.
                        She is immediately found guilty, and as the missing necklace was found on her person her sentance doubled
                        You feel accomplished as a detective, but cant escape the feeling of there being some loose ends left.
                        As for the other characters:
                        Chef decided to keep his cooking talents to himself and retire
                        Bartholomew had no issue finding other, incredibly similar employment. His repute for hard work and a job well done paid off.
                        Agnes, When seen in public, only wore black with a veil covering her face.
                        Silvia took over Heathers side of the business, and Bernard made the same offer to take over which Silvia accepts."; //this is maid ending 1: maid jailed for murder and necklace found (you feel like there are some loose ends left hanging)
        }
        else if (e == "Margaret2")
        {
            endText = @"You accused Margaret of the murder of Heather.
                        She is immediately found guilty, and as the missing necklace was found on her person her sentance doubled.
                        Silvia is investigated for financial crimes, eventually found guilty, and spends the rest of her days in jail.
                        You feel accomplished as a detective, and feel a sense of pride knowing you have gotten to the bottom of the mystery.
                        The only person who visits Silvia in Jail is Agnes, who whenever seen in public is always wearing a black veil.
                        As for the other characters:
                        Chef decided to keep his cooking talents to himself and retire
                        Bartholomew had no issue finding other, incredibly similar employment. His repute for hard work and a job well done paid off.
                        Bernard took over Heathers side of the business.

                        Misfortune tests the sincerity of friends."; //TRUE ENDING:  maid jailed for the murder, necklace found on her person. silvia gets investigated for past financial crimes and eventually arrested. protag career improved
        }
        else
        {
            endText = "";
        }
        //place text on a panel

        endText = endText + "\n press alt+f4 to exit";
        endTextcanvas.SetActive(true);
        endTextObj.SetActive(true);
        Debug.Log("endText = " + endText);
        tmp.text = endText;
        //Butler found new employer
        //Unable to track down Maid
        //Chef vibing in retirement
        //Partner took over business
        //Guest now only appears in public in black
    }
}
