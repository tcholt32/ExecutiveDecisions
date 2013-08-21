using UnityEngine;
using System.Collections;

public class TheGame : Menu
{
	// Use this for initialization
	public override void Initialize (float screenheight, float screenwidth, float buttonheight, float buttonwidth,float fieldheight,float fieldwidth) {
		base.Initialize(screenheight,screenwidth,buttonheight,buttonwidth,fieldheight,fieldwidth);
	}
		
	public override void drawGUI(){
		
		if(GUI.Button (new Rect((screenWidth-buttonWidth)*0.2f,screenHeight*0.7f,buttonWidth,buttonHeight),"Option 1")){
		
		}
		if(GUI.Button (new Rect((screenWidth-buttonWidth)*0.2f,screenHeight*0.8f,buttonWidth,buttonHeight),"Option2")){
		
		}
		if(GUI.Button (new Rect((screenWidth-buttonWidth)*0.8f,screenHeight*0.7f,buttonWidth,buttonHeight),"Option 3")){

		}
		if(GUI.Button (new Rect((screenWidth-buttonWidth)*0.8f,screenHeight*0.8f,buttonWidth,buttonHeight),"Option 4")){

		}
		if(GUI.Button (new Rect((screenWidth-buttonWidth)*0.5f,screenHeight*0.9f,buttonWidth,buttonHeight),"Exit Game")){
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

