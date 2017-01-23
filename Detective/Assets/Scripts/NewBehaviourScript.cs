using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewBehaviourScript : MonoBehaviour {
	public GameObject chest;
	public GameObject secretPathway;
	public GameObject pathwayDoor;
	public GameObject friend;
	public GameObject girlfriend;
	public GameObject son;
	public GameObject detective;
	public GameObject houseKeeper;
	public GameObject player;
	public GameObject gun;
	public GameObject insurance;
	public GameObject iou;
	public GameObject map;
	public GameObject suitcase;
	public GameObject houseContract;
	public GameObject testament;
	public GameObject photof;
	public GameObject SPB;
	public GameObject stock;
	public GameObject throwup;
	public GameObject secretroom;
	public GameObject body;
	public GameObject cut;
	public GameObject sword;
	public GameObject saltWater;
	public GameObject planeTicket;
	public GameObject planeTicket1;
	public GameObject envelop;
	public GameObject cash;
	public GameObject photog;
	public GameObject newspaper;
	public GameObject note;
	public GameObject lB;
	public GameObject iG;
	public GameObject start;
	public GameObject doorhandle;
	public GameObject doorhandle1;
	//friend
	string fgreetingM = "Ahhh! Good morning Mr. XXX! So glad to see someone getting up as early as I do, especially during Winter time!";
	string fgreetingW = "Ahhh! Good morning Ms. XXX! So glad to see someone getting up as early as I do, especially during Winter time!";
	string ftiming = "The last time I saw him was when everybody were chatting during dinner,and then I went to bed directly after dinner. I had never seen him after that.";
	string faccess = "Sure! Mr.XXX have been my friend for over thirty years. I would like to do anything beneficial to him.";
	string ftestament = "Yes. He planned to give me all the paintings he collected. Our company lost a lot of money because of his decision. I never blamed him. But he knows I love to collect paintings, so he plans to give all his paintings to me as compensation.";
	string ftestament1 = "Ehhh... Yes, after the painting was found again, he crossed it from the list he is going to send to me. What a pity! I was there when he made this decision. ";
	string fcontract = "Yes, this house was own by my family for the last century. But my father gave it to him, since he believes that Mr.XXX would be a great man in the future. He gave him all the paintings he collected, too!";
	string fsleepingPillBox = "I have a hard time falling a sleep these days. So that I have to use this medicine.";
	string fstock = "Well, Mr.XXX is a great businessman, very ambitious and earned a whole bunch of money, but stubborn, which may lead to disasters.";
	//girlfriend
	string gtiming = "Well, after dinner, I went to bed directly with S, never saw him later.";
	string gaccess = "Sincerely, I don't like him a lot. You know, because of his attitude towards my relationship with S. But, yes, if you need to.";
	string gsuitcase = "I don't think that by far this suitcase has anything to do with the case, so I am not going to open that for you. But if you really need it, you can try to open it by yourself.";
	//son
	string stiming = "I went to bed with my darling. Don't even want to spend any extra second with my father. He never likes my Girlfriend";
	string saccess = "Ehhh... I hate people coming into my room.So, I would say, you may only enter the room if you have direct evidence towards me.";
	string sboyIOU = "That has nothing to do with the case, right?";
	string sboyCollections = "That...Humm... My father gave them to me. I am his son, afterall.";
	string sinsurance = "I need to make sure that if anything happened to him someday, I would get the insurance.";
	string sinsurance1 = "Come on! You have seen that I do gamble and I need money. But I could never do any harm to my father! I don't dare to! I was just sleeping!";
	string sconstruction = "Seriously speaking, I got that to see if my father puts his treasures in somewhere else in the house. But I found nothing and I have no idea what these means!";
	string sconstruction1 = "Told you I have no idea what these red crossings mean.";
	//detective
	string dMono = "As everyone have seen or heard. "
		+ "There was a fight in Mr.XXX's room happened last night or earlier today. "
		+ "\nAnd now, Mr.XXX is missing. \nJust now, you have all claimed that you have never seen Mr.XXX this morning, and I believe in you, sincerely. "
		+ "\nYet, I have just checked the footprints and talked to the people at the gate, "
		+ "\nMr.XXX had never left the house.Therefore, he must still be in here, somewhere."
		+ "\n And as his private detective, I am to figure this out. I need your cooperation.";
	string dtiming = "Now, please everyone, could you tell me when did you last meet Mr.XXX?"; 
	string daccess = "Thanks, now would you mind it if I need to check your belongings if there is anything related to it?";
	string dintoBedroom = "Thank you all for your suppport. Now, please, stay here before everything ends. "
		+ "\nAnd, during this time, Miss XXX shall be my assistant, please treat her as how you treat me.";
	string dcallPlayerW = "Miss XXX, could you come out with me for a second, please?"
		+ "\nI appreciate your ability in the case of XXXX, would you also like to help this time?";
	string dcallPlayerM = "Mr. XXX, could you come out with me for a second, please?"
		+ "\nI appreciate your ability in the case of XXXX, would you also like to help this time?";
	string drules = "As what I just mentioned, Mr.XXX is still in the room. Though we don't know what happened to him yet. So we should either find him or find the person who had the fight with him."
	                + "\n Apparently, there are liers among people sitting inside, I will try to find more informations by asking them. And you can go to Mr.XXX's room to find more clues. "
	                + "\nCome back and ask them if necessary, don't hesitate to access their room if needed.";
	string dgfriend = "Tell me you did not do it!";
	//housekeeper
	string htiming = "The last time I saw him was during midnight actually. He had his stomach ache， again. So, I went there to give him some pills.";
	string haccess = "Sure, if it helps. I have been working for him since when I was a girl. All my belongings were given by him.";
	string hcash1 = "What do you prepare this amount of money for?";
	string hplaneticket = "Yes, He is planning to travel for two months. I am going with him to take care of him.";
	string hplaneticket1 = "Ehhh... Yes. But Mr.XXX always makes the right decision, so I trust him. ";
	string hsaltWater = "Mr.XXX always has stomachache, He feels that drinking salt water after throw up helps. So I went there to give him some salt water.";
	string hthreatened = "";
	string hnoidea = "I am not sure who owns this.";
	string hcash = "It is 5000 dollars.";
	//player
	string pmono = "Ehhh...Why am I feeling so dizzy... I must be very drunk last night...\t I need to go out and get a cup of water.";
	string plock = "It seems that the lock is broken...Hey, is anybody out there? \nUmm...It is only seven o'clock. They are probably still asleep.\nWait...";
	string panotherPerson =  "Someone else must have been here. There is nobody else in the room though. \n He or she must have found another way to get out of here.";
	string psecretPathway = "It seems that this chest has been moved before.There is probably something behind or under it...";
	string pstudy = "What happened in here? There is bullet, a broken bottle, and a piece of glass. \nThere must have been a fight, between Mr.XXX and who came in through the secret pathway.";
	string pblood = "Look, there is blood around and in the scratch of carpet, which must be cut by something fairly sharp...\n Someone must have been hurt!";
	string pgreeting = "Hi, Mr.XX, have you seen Mr.XXX this morning? He is not in his room... I have something important to ask him!";
	string ptiming = "I am the one who found out it first. I woke up and found that my door lock was broken. Somebody else came in and accidentally locked the door which can't be locked."
		+ "\nYet, since there is nobody in the room, I believe that that someone must had gotten out of the room in another way. "
		+ "\nIn a while, I found the secret pathway and entered Mr.XXX's bedroom, which is the place the fighting happened. ";
	string paccess = "I barely have any belongings with me. But you are welcome to go in and check anytime.";
	string phelp = "Wait... What's going on?";
	string pbedetect = "Sure! Glad you trust me and give me this chance! Though, how shall we start it?";
	string pbbedroom = "Oh! This is a nice bedroom...but a little bit messy!";
	string paskboyIOU = "Why did you borrow money?";
	string paskboyCollection = "Could you please explain that why are these collections in your room?";
	string paskboyInsurance = "Why do you keep the photo of your insurance?";
	string paskboyInsurance1 = "You do need a large amount of money, don't you?";
	string pgiveComfort = "Alright! Alright! Calm down! I am not sending you to prison. I am just asking!";
	string paskboyCons = "Nice! you have got a construction map of the house here! What do these red crossings mean?";
	string pdecoratingSword = "This must be the thing that cut through the carpet. I need to ask them about this and see how they reflect.";
	string phousekeeperplaneticket = "You are going to XXX with Mr.XXX, right?";
	string phousekeeperplaneticket1 = "Do you know that this plane is going to crash?";
	string pthrowUp = "Mr.XXX didn't have a easy night last night. It seems that he had his heavy stomachache again.";
	string psecretRoom = "Ahhh! Now this is the secret room on the construction map";
	string pbody = "Mr.XXX! Mr.XXX! Can you hear me? Are you okay?";
	string psex = "";
	//object
	string ogun = "A gun";
	string oinsurance = "Unnatural Death Insurance";
	string opromissorynote = "XXXX...Wow! This is the painting Mr.XXX claimed lost days before. But why is it here in his room?";
	string omap = "Construction map of the house.";
	string osuitcase = "A locked suitcase";
	string ohouseContract = "The house contract.";
	string otestament = "Mr.XXX's testament";
	string ophotof = "An old photo of Mr.XXX & Mr.X's family";
	string oSPB = "A Sleeping pill box";
	string oStock = "Stock of Mr.XXX's company invested by Mr.X";
	string othrowUp = "Mr.XXX throw up last night.";
	string osecretRoom = "Entrance to the secret room";
	string obody = "Mr.XXX's body.";
	string ocut = "The cut on the body.";
	string osword = "Decorating sword";
	string osaltWater = "Salt water";
	string oplaneTicket = "Mr.XXX's Plane ticket";
	string oplaneTicket1 = "Mrs. XXX's Plane ticket.";
	string oenvelop = "envelop";
	string ocash = "A large amount of cash";
	string ophotog = "a photo of girlfriend and Detective";
	string onewspaper = "Newspaper.";
	string onote = "note with girlfriend's mother's death date on";
	string odoorHandle = "A broken doorHandle";


	// Use this for initialization
	void Start () {
		print ("Choose your character: B/G");
		if(sex == "B"){
			print ("Mr._");
			psex = "B";
		}else{
			print("Miss._");
			psex = "G";
			start.SetActive;
		}

		SecretRoom ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void SecretRoom(){
		print (pmono);
		if(doorhandle.activeSelf == false) {
			print (plock);
			print (panotherPerson);
			if (chest.activeSelf == false) {
				print (psecretPathway);				
			
				if (pathwayDoor.activeSelf == false) {
					//animation into secretpathway

				}
			}
		}

	}
}
