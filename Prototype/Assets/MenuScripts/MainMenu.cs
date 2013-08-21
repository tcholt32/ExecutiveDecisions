using UnityEngine;
using System.Collections;

public class MainMenu : Menu {
	
	public bool startGame=false;
	
	// Use this for initialization
	public override void Initialize (float screenheight, float screenwidth, float buttonheight, float buttonwidth,float fieldheight,float fieldwidth) {
		base.Initialize(screenheight,screenwidth,buttonheight,buttonwidth,fieldheight,fieldwidth);	
	}
	
	public override void drawGUI(){
		
		if(GUI.Button (new Rect((screenWidth-buttonWidth)*0.5f,screenHeight*0.3f,buttonWidth,buttonHeight),"Start Game"))
		{
			startGame=true;
		}
		if(GUI.Button (new Rect((screenWidth-buttonWidth)*0.5f,screenHeight*0.4f,buttonWidth,buttonHeight),"Load Game")){
		

		}
		if(GUI.Button (new Rect((screenWidth-buttonWidth)*0.5f,screenHeight*0.5f,buttonWidth,buttonHeight),"Exit Game")){
			Application.Quit ();
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
}