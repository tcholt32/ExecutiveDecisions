using UnityEngine;
using System.Collections;

public class Game1 : MonoBehaviour {
	
	
	//Login loginscreen=ScriptableObject.CreateInstance<Login>();
	// Use this for initialization
	//MonoBehaviour f;
	public Login loginScreen;
	public MainMenu gameMenu;
	public CreateProfile newuserScreen;
	public TheGame scenario;
	private float buttonHeight;
	private float buttonWidth;
	private float fieldHeight;
	private float fieldWidth;
	
	public enum gameStates{
		
		login,
		createProfile,
		profileTest,
		mainMenu,
		loadMenu,
		inGame,
		exitGame
	};
	gameStates currentState;
	
	public void Awake(){
		
		
	}
	public void Start () {
	currentState=gameStates.login;
	//loginscreen.Initialize();
	loginScreen.Initialize(Screen.height,Screen.width,buttonHeight,buttonWidth,fieldHeight,fieldWidth);
	gameMenu.Initialize(Screen.height,Screen.width,buttonHeight,buttonWidth,fieldHeight,fieldWidth);	
	}
	public void OnGUI(){
		//LoginScreen
	//loginscreen.drawGUI();
		if(currentState==gameStates.login){
			if(loginScreen.newUser==true){
				
				currentState=gameStates.createProfile;
				loginScreen.newUser=false;
				
			}
			else if(loginScreen.loggedIn==true){
				
				currentState=gameStates.mainMenu;
			}
			else{
				loginScreen.updateScreen();
				loginScreen.drawGUI();
			}
		}
		else if(currentState==gameStates.createProfile){
			if(newuserScreen.backPage==true){
				currentState=gameStates.login;
				newuserScreen.backPage=false;
			}
			else if(newuserScreen.newAccount==true){
				currentState=gameStates.mainMenu;
			}
			else{
				
			newuserScreen.updateScreen();
			newuserScreen.drawGUI();
			}
		}
		else if(currentState==gameStates.mainMenu){
			
			if(gameMenu.startGame==true){
			currentState=gameStates.inGame;	
			}
			else{
			gameMenu.updateScreen ();
			gameMenu.drawGUI ();
			}
		}
		else if(currentState==gameStates.loadMenu){
			
		}
		else if(currentState==gameStates.inGame){ 
			
			scenario.updateScreen();
			scenario.drawGUI();
		}
	}
	// Update is called once per frame
	public void Update () {
		//loginscreen.updateScreen();
		
	}
}
