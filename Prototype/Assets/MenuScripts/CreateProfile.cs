using UnityEngine;
using System.Collections;

public class CreateProfile : Menu {
	
	public string userName ="";
	private string passWord="", reEntry="", check="",notification="";
	private GUIStyle profileStyle=GUIStyle.none;
	private GUIStyle StyleCheck=GUIStyle.none;
	
	Color green= Color.green;
	Color red = Color.red;
	
	bool correct=false;
	public bool newAccount=false;
	public bool backPage=false;
	IEnumerator signUp(WWW webForm){
		yield return webForm;
		if(webForm.error ==null){
			notification+=webForm.text;
			print (webForm.text);
			if(webForm.text=="Success"){
				newAccount=true;
			}
		}
		
		else
		{
			notification+="Error: " + webForm.error+ "/n";
		}
	}
	// Use this for initialization
	public override void Initialize (float screenheight, float screenwidth, float buttonheight, float buttonwidth,float fieldheight,float fieldwidth) {
		reset ();
		base.Initialize(screenheight,screenwidth,buttonheight,buttonwidth,fieldheight,fieldwidth);
		
	}
	public override void drawGUI(){
		
		GUI.Box (new Rect((screenWidth-fieldWidth)*0.16f,screenHeight*0.06f,fieldWidth,fieldHeight),notification,profileStyle);
		GUI.Label(new Rect((screenWidth-fieldWidth)*0.16f,screenHeight*0.1f,fieldWidth,fieldHeight),"Username: ");
		userName=GUI.TextField(new Rect((screenWidth-fieldWidth)*0.5f,screenHeight*0.1f,fieldWidth,fieldHeight),userName);
		GUI.Label (new Rect((screenWidth-fieldWidth)*0.16f,screenHeight*0.2f,fieldWidth,fieldHeight),"Password: ");
		passWord=GUI.PasswordField(new Rect((screenWidth-fieldWidth)*0.5f,screenHeight*0.2f,fieldWidth,fieldHeight),passWord,"*"[0]);
		GUI.Label (new Rect((screenWidth-fieldWidth)*0.16f,screenHeight*0.3f,fieldWidth,fieldHeight),"Password Re-entry: ");
		reEntry=GUI.PasswordField(new Rect((screenWidth-fieldWidth)*0.5f,screenHeight*0.3f,fieldWidth,fieldHeight),reEntry,"*"[0]);
		GUI.Box(new Rect((screenWidth-fieldWidth)*0.5f,screenHeight*0.36f,fieldWidth,fieldHeight),check,StyleCheck);
			if(reEntry!="")
			{	
				if(passWord==reEntry){
					check="Correct!\n";
					StyleCheck.normal.textColor=green;
					correct=true;
					//StyleCheck.
				}
				else{
					correct=false;
					check="Incorrect!\n";
					StyleCheck.normal.textColor=red;
				}
				
			}
			else
				check="";
	
		if(GUI.Button (new Rect((screenWidth-buttonWidth)*0.4f,screenHeight*0.5f,buttonWidth,buttonHeight),"Sign-Up")){
			notification="";
			
			if(userName==""||passWord==""||reEntry==""){
				profileStyle.normal.textColor=red;
				StyleCheck.normal.textColor=red;
				//reset ();
				notification+= "Fields are not all filled out\n";
				
			}
			else{
				//notification="";
				if(correct){
					
					WWWForm form= new WWWForm();
					form.AddField ("userName",userName);
					form.AddField ("passWord", passWord);
					WWW webForm = new WWW("http://www.decisiongame.netne.net/CreateProfile.php", form);
					StartCoroutine(signUp(webForm));
				}
				
			}
			
		}
		if(GUI.Button (new Rect((screenWidth-buttonWidth)*0.4f,screenHeight*0.6f,buttonWidth,buttonHeight),"Back")){
			reset ();
			StyleCheck.normal.textColor=red;
			profileStyle.normal.textColor=red;
			//this.currentMenu=Login;
			backPage=true;
		}
		base.drawGUI();
	}
	
public override void updateScreen()
	{
		
		base.updateScreen();
		buttonHeight=screenHeight*0.05f;
		buttonWidth=screenWidth*0.2f;
		fieldHeight=screenHeight*0.05f;
		fieldWidth=screenWidth*0.3f;
	}
	
public override void reset()
	{
	
		userName ="";
		passWord=""; reEntry=""; check="";notification="";
	base.reset();
	}
}

