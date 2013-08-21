using UnityEngine;
using System.Collections;

public class ProfileTest : Menu {
	ArrayList questions,responses;
	int[] ansInt=new int[44];
	int width=600;
	int height=30;
	int posx=25;
	int posy=25;
	int count=0;
	int Extravrt=0;
	int Agreebl=0;
	int Cons=0;
	int Neursm=0;
	int Openess=0;
	public bool next=false;
	bool scored=false;
	enum pages{
		
		page1,
		page2,
		page3,
		page4
	};
	pages currentpage=pages.page1;
	string[] answers={"Strongly Disagree","Disagree","Neutral","Agree","Strongly Agree"};
	string[] myArray={"Is talkative","Tends to find fault in others","Does a thorough job","Is depressed, blue","Is original, comes up with new ideas",
		"Is reserved","Is helpful and unselfish with others","Can be somewhat careless","Is relaxed, handles stress well",
		"Is curious about many different things","Is full of energy","Starts quarrels with others","Is a reliable worker","Can be tense",
		"Is ingenious, a deep thinker","Generates a lot of enthusiasm","Has a forgiving nature","Tends to be disorganized","Worries a lot",
		"Has an active imagination","Tends to be quiet","Is generally trusting","Tends to be lazy","Is emotionally stable, not easily upset","Is inventive",
		"Has an assertive personality","Can be cold and aloof","Perseveres until the task is finished","Can be moody","Values artistic, aesthetic experiences",
		"Is sometimes shy, inhibited","Is considerate and kind to almost everyone","Does things efficiently","Remains calm in tense situations",
		"Prefers work that is routine","Is outgoing, sociable","Is sometimes rude to others","Makes plans and follows through with them","Gets nervous easily",
		"Likes to reflect, play with ideas","Has few artistic interests","Likes to cooperate with others","Is easily distracted",
		"Is sophisticated in art music, or literature"};
	// Use this for initialization
	public override void Initialize (float screenheight, float screenwidth, float buttonheight, float buttonwidth,float fieldheight,float fieldwidth) {
		base.Initialize(screenheight,screenwidth,buttonheight,buttonwidth,fieldheight,fieldwidth);	
		
		
		
		
		
	}
	
	public override void drawGUI(){
		posx=400;
		posy=100;
		
		if(currentpage==pages.page1){
			for(int i=0; i<12;i++){
				
				
				ansInt[i]=GUI.Toolbar (new Rect(posx,posy,width,height),ansInt[i],answers);
				//posx+=10;
				//string mystring=questions[i].ToString;
			
				GUI.Label (new Rect(120,posy,width,height),myArray[i]);
				posy+=45;	
					
			
			}
		}
		else if(currentpage==pages.page2){
			posy=100;
			for(int i=12; i<24;i++){
			
			
			ansInt[i]=GUI.Toolbar (new Rect(posx,posy,width,height),ansInt[i],answers);
			//posx+=10;
			//string mystring=questions[i].ToString;
		
			GUI.Label (new Rect(120,posy,width,height),myArray[i]);
			posy+=45;	
			}
			
		}
		else if(currentpage==pages.page3){
			
			posy=100;
			for(int i=24; i<36;i++){
			
			
			ansInt[i]=GUI.Toolbar (new Rect(posx,posy,width,height),ansInt[i],answers);
			//posx+=10;
			//string mystring=questions[i].ToString;
		
			GUI.Label (new Rect(120,posy,width,height),myArray[i]);
			posy+=45;	
			}
			
		}
		else if(currentpage==pages.page4){
				posy=100;
			for(int i=36; i<44;i++){
			
			
			ansInt[i]=GUI.Toolbar (new Rect(posx,posy,width,height),ansInt[i],answers);
			//posx+=10;
			//string mystring=questions[i].ToString;
		
			GUI.Label (new Rect(120,posy,width,height),myArray[i]);
			posy+=45;	
			}
			
		}
		if(currentpage<pages.page4){
			if(GUI.Button (new Rect(700,700,100,30),"Next")){
						currentpage++;
			}
		}
		if(currentpage==pages.page4){
			
			if(GUI.Button (new Rect(700,700,100,30),"Submit")){
				for(int i=0; i<44;i++){
					scoring(i,ansInt[i]);
				}
				scored=true;
				currentpage++;
						//next=true;
			}
		}
		//if(currentpage>3)
		if(scored){
			posy=100;
			GUI.Label(new Rect(120,posy,width,height),"Extraversion "+Extravrt);
			posy+=45;
			GUI.Label(new Rect(120,posy,width,height),"Agreeableness "+Agreebl);
			posy+=45;
			GUI.Label(new Rect(120,posy,width,height),"Conscientiousness "+Cons);
			posy+=45;
			GUI.Label(new Rect(120,posy,width,height),"Neuroticism "+Neursm);
			posy+=45;
			GUI.Label(new Rect(120,posy,width,height),"Openness "+Openess);
			posy+=45;
			if(GUI.Button(new Rect(700,700,100,30),"Continue")){
				
				next=true;
			}
		}
			
		if(currentpage>0){
			
			if(GUI.Button (new Rect(200,700,100,30),"Prev")){
					currentpage--;
			}
		}
		base.drawGUI();
	}
	
	public override void updateScreen(){
		
		base.updateScreen();
		buttonHeight=screenHeight*0.05f;
		buttonWidth=screenWidth*0.2f;
		fieldHeight=screenHeight*0.05f;
		fieldWidth=screenWidth*0.3f;
	}
	void scoring(int questionNum,int score){
		score=score+1;
		if((questionNum==1)||(questionNum==6)||(questionNum==11)||(questionNum==16)||(questionNum==21)||(questionNum==26)||(questionNum==31)||(questionNum==36)){
			if((questionNum==6)||(questionNum==21)||(questionNum==31)){
				score=reverseScoring(score);
			}
			Extravrt+=score;
		}
		else if((questionNum==2)||(questionNum==7)||(questionNum==12)||(questionNum==17)||(questionNum==22)||(questionNum==27)||(questionNum==32)||(questionNum==37)||(questionNum==42)){
			
			if((questionNum==2)||(questionNum==12)||(questionNum==27)||(questionNum==37)){
				score=reverseScoring(score);
			}
			Agreebl+=score;
		}
		else if((questionNum==3)||(questionNum==8)||(questionNum==13)||(questionNum==18)||(questionNum==23)||(questionNum==28)||(questionNum==33)||(questionNum==38)||(questionNum==43)){
			
			if((questionNum==8)||(questionNum==18)||(questionNum==23)||(questionNum==43)){
				score=reverseScoring(score);
			}
			Cons+=score;
		}
		else if((questionNum==4)||(questionNum==9)||(questionNum==14)||(questionNum==19)||(questionNum==24)||(questionNum==29)||(questionNum==34)||(questionNum==39)){
			
			if((questionNum==9)||(questionNum==24)||(questionNum==34)){
				score=reverseScoring(score);
			}
			Neursm+=score;
		}
		else if((questionNum==5)||(questionNum==10)||(questionNum==15)||(questionNum==20)||(questionNum==25)||(questionNum==30)||(questionNum==35)||(questionNum==40)||(questionNum==41)||(questionNum==44)){
			
			if((questionNum==35)||(questionNum==41)){
				score=reverseScoring(score);
			}
			Openess+=score;
		}
	}
	int reverseScoring(int score){
		if(score==5)
			score=1;
		else if(score==4)
			score=2;
		else if (score==2)
			score=4;
		else if(score==1)
			score=5;
		return score;
	}
}
