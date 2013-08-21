using UnityEngine;
using System.Collections;

public class Login: Menu  {
	
	
	private string testMessage="",loginNotification="";
	
	
	public string userName ="";
	private string passWord="";
	private GUIStyle loginStyle=GUIStyle.none;
	
	public bool newUser=false;
	public bool loggedIn=false;
	
	IEnumerator loginUser(WWW webForm){
		yield return webForm;
		if(webForm.error==null){
			if(webForm.text=="Success"){
			loginNotification+=webForm.text;
			reset ();
			//this.currentMenu=gameMenu;
			loggedIn=true;
			}
			else
				loginNotification +=webForm.text;
		}
		
		else{
			loginNotification+="Error: " + webForm.error +'\n';
		}
		
	}
	
	
	
	// Use this for initialization
	public override void Initialize (float screenheight, float screenwidth, float buttonheight, float buttonwidth,float fieldheight,float fieldwidth) {
		loginStyle.normal.textColor=Color.red;
		reset ();
		base.Initialize(screenheight,screenwidth,buttonheight,buttonwidth,fieldheight,fieldwidth);
		
	}
	public override void drawGUI(){
		
		GUI.Box (new Rect((screenWidth-fieldWidth)*0.5f,screenHeight*0.24f,fieldWidth,fieldHeight),loginNotification,loginStyle);
		GUI.Label(new Rect((screenWidth-fieldWidth)*0.5f,screenHeight*0.27f,fieldWidth,fieldHeight),"Username: ");
		userName=GUI.TextField(new Rect((screenWidth-fieldWidth)*0.5f,screenHeight*0.3f,fieldWidth,fieldHeight),userName);
		GUI.Label (new Rect((screenWidth-fieldWidth)*0.5f,screenHeight*0.37f,fieldWidth,fieldHeight),"Password: ");
		passWord=GUI.PasswordField(new Rect((screenWidth-fieldWidth)*0.5f,screenHeight*0.4f,fieldWidth,fieldHeight),passWord,"*"[0]);
		if(GUI.Button (new Rect((screenWidth-buttonWidth)*0.5f,screenHeight*0.5f,buttonWidth,buttonHeight),"Login")){
			loginNotification="";
			if(userName==""||passWord==""){
				loginNotification+="Incomplete Fields";
			}
			else{
				WWWForm form= new WWWForm();
				form.AddField ("userName",userName);
				form.AddField ("passWord", passWord);
				WWW webForm = new WWW("http://www.decisiongame.netne.net/login.php", form);
				StartCoroutine(loginUser(webForm));
			}
		}
		if(GUI.Button (new Rect((screenWidth-buttonWidth)*0.5f,screenHeight*0.6f,buttonWidth,buttonHeight),"New User")){
			reset ();
			//this.currentMenu=NewProfile;
			newUser=true;
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
	public override void reset(){
		
		testMessage="";loginNotification="";userName ="";passWord="";
	}
}
