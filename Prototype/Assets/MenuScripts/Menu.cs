using UnityEngine;
using System.Collections;

public abstract class Menu: MonoBehaviour  {
	
	public float screenHeight;
	public float screenWidth;
	public float buttonHeight;
	public float buttonWidth;
	public float fieldHeight;
	public float fieldWidth;
	
	
	public virtual void Initialize (float screenheight, float screenwidth, float buttonheight, float buttonwidth,float fieldheight,float fieldwidth) {
		screenHeight=screenheight;
		screenWidth=screenwidth;
		buttonHeight=buttonheight;
		buttonWidth=buttonwidth;
		fieldHeight=fieldheight;
		fieldWidth=fieldwidth;
	}
	
	public virtual void drawGUI(){}
	public virtual void updateScreen(){
		
		screenHeight=Screen.height;
		screenWidth=Screen.width;
		
	}
	public virtual void reset(){
		
		
	}
	
}
