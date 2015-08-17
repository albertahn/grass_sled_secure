using UnityEngine;
using System.Collections;

using Boomlagoon.JSON;


public class loginScriptSharp : MonoBehaviour {

	//GUISkin mySkin = GUI.skin;
	
	public bool UsernameCORRECT = false;
	public	bool PasswordCORRECT = false;

	string GameOwner;
	string GameOwnerPassword;

//audio
	public string PlayerUsername ;
	public	string PlayerPassword;


	public int LoaderHeight;

	public int LoaderWidth ;
	public int GeneralWidth, GenHeight  ; 

	
	public int UserHeight ;
	public int UserWidth ;
	
	public int feedbackWidth ;
	public int feedHeight ;

	
	public int PassHeight;
	public int PassWidth ;

	
	public int LogHeight ;
	public int LogWidth ;


	//single player;

	public int singleLeft, singleRight, singleTop, singleBottom;


//player username logged afteer
	public bool loggedin;
	private string username;
	private string hintPart;

	public int login_btn_height;
	public GUIStyle style= new GUIStyle();
	public GUIStyle inputstyle = new GUIStyle();
	private Server LoginServer; //= GetComponent<Server>();

	public int screenWidth;
	public int screenHeight;

	// Use this for initialization
	void Start () {
		Screen.SetResolution (800, 480, true);

		LoginServer = GetComponent<Server>();

		screenWidth =  Screen.width;
		screenHeight=Screen.height;

		PlayerPassword = ""; //PlayerPassword = "";

		LoaderHeight = 10;
	    LoaderWidth = 10;
		GeneralWidth = (int) (Screen.width/2-Screen.height*.25);

		GenHeight  = (int) (Screen.width/2-Screen.height*.5);
		
		
		UserHeight = (int) (Screen.width/2-Screen.height*.25)/2 ;
		UserWidth = 1; 
		feedbackWidth =170;
		feedHeight =170;

		login_btn_height= (int) (Screen.width/2-Screen.height*.02) ;
		
			PassHeight = (int) (Screen.width/2-Screen.height*.25) ;
	    PassWidth = 1;

		LogHeight = (int) (Screen.width/2-Screen.height*.5)+ 101;
		LogWidth = (int) (Screen.width/2-Screen.height*.25)+ 163;
		//notloggedin

		if (PlayerPrefs.GetString ("user_index")=="") {
			loggedin = false;
				} else {

			loggedin = true;

			//Debug.Log("index: " +PlayerPrefs.GetString ("user_index"));
				}



		//Single player ints

		singleLeft  = (int)(Screen.width / 12);
		singleRight = (int)(Screen.width / 2);
		singleTop = (int)(Screen.width / 9);
		singleBottom = (int)(Screen.width / 5);

		style.normal.textColor = Color.black;
		style.fontSize = login_btn_height/10;

		//style.fontSize = 130;
	
		//input stype
		inputstyle.fontSize = login_btn_height/10;

		//guiTexture.color = Color.green;





		//new GUIStyle(GUI.skin.textField);

		inputstyle.normal.textColor = Color.white;

	}
	


void Update () {

		//Debug.Log("gameown"+PlayerUsername+":GameOwnerPassword:"+PlayerPassword);

	}

	public void OnGUI(){

		if(false){//loggedin

			GUI.backgroundColor=Color.cyan;


			GUILayout.Label("Welcome "+ PlayerPrefs.GetString("username"));

			//show single play button
			if (GUI.Button (new Rect (singleLeft, singleTop, singleRight,singleBottom), "<color=white><size=30*screenWidth/800>Play Single</size></color>")) {
				
				Application.LoadLevel ("singleSelect");

				//Debug.Log ("singleman");
					
			}//endifelse


			//show multiplay button
			if (GUI.Button (new Rect (singleLeft, singleTop*3, singleRight,singleBottom), "<color=white><size=30*screenWidth/800>Multiplayer</size></color>")) {
				
				Application.LoadLevel ("scMulty");
				//Application.

				Debug.Log ("smeman");
				
			}//endifelse

			//show multiplay button
			if (GUI.Button (new Rect (singleLeft*8, singleTop*3, singleRight/2,singleBottom), "<color=white><size=30*screenWidth/800>Logout</size></color>")) {
				
				//Application.LoadLevel ("scNet");
				
				Debug.Log ("logout");

				PlayerPrefs.SetString("email", "");
				
				PlayerPrefs.SetString("username", "");
				
				PlayerPrefs.SetString("user_index", "");

				PlayerPrefs.SetInt("points",0);

				loggedin = false;
				
			}//endifelse

			if (GUI.Button (new Rect (singleLeft*8, singleTop*1, singleRight/2,singleBottom), "<color=white><size=30*screenWidth/800>Exit</size></color>")) {
				Application.Quit();

				Debug.Log("quit");
			}//

		}else{ // not loggedin

			GUI.Label (new Rect (130,140,150,100), "<size=30>Email:</size>");

			GUI.backgroundColor = Color.red;

			GUI.Label (new Rect (80,280,150,100), "<size=30>Password:</size>");

			GUILayout.Label(""+hintPart);


		//Text area for the username

			PlayerUsername = GUI.TextArea (new Rect(250,140,350,60),PlayerUsername, 100);

			// Debug.Log("widthscreenman :"+ Screen.width);

		//Text area for the password
			PlayerPassword = GUI.PasswordField(new Rect (250,280,350,60), PlayerPassword, "*"[0], 25); //(new Rect(GeneralWidth,PassHeight,100,20),PlayerPassword);


		// login 
			if (GUI.Button (new Rect (250,400,150,60), "<size=20>Log-In</size>")) {


            //login button
				 StartCoroutine (GetLoginData(PlayerUsername, PlayerPassword));

				 }//endifelsegui


			// Loads level (0). This map can be set in the build settings
			if (GUI.Button (new Rect (410,400,150,60), "<size=20>Cancel</size>")) {
				
				Application.LoadLevel ("scPreStart");
				//login button
				//StartCoroutine (GetLoginData(PlayerUsername, PlayerPassword));
			}//endifelsegui
		}//end else notlogged in
	}//end gui

//getlogin data

	private IEnumerator GetLoginData (string email, string password)
	{

		yield return StartCoroutine (LoginServer.LoginUser(PlayerUsername, PlayerPassword));

		string emailman = LoginServer.fuckdata.GetString("password");

		//Debug.Log("mailman:  "+ password);

		// LoginServer.hello ();
		//if (_server.data.ContainsKey ("character")) {
		
		//Debug.Log("emailman : "+ LoginServer.fuckdata.GetString("email")) ;

		username = LoginServer.fuckdata.GetString("username");

		if(username !=""){

			loggedin= true;

//			Debug.Log("loggedin fucker : "+LoginServer.fuckdata.GetString("email")) ;

			PlayerPrefs.SetString("email", LoginServer.fuckdata.GetString("email"));

			//Debug.Log("hello:"+LoginServer.fuckdata.GetString("points"));
			PlayerPrefs.SetString("points", LoginServer.fuckdata.GetString("points"));

			PlayerPrefs.SetString("username", LoginServer.fuckdata.GetString("username"));

			PlayerPrefs.SetString("user_index", LoginServer.fuckdata.GetString("index"));
						
			PlayerPrefs.SetInt("IsLogIn",1);

			//Debug.Log("points = "+LoginServer.fuckdata.GetString("points"));

			//Debug.Log(PlayerPrefs.GetString("points"));
			Application.LoadLevel("scStart");

		}else{
			loggedin= false;

			hintPart ="Username or Password was Incorrect";

			Debug.Log("not logged in : "+LoginServer.fuckdata.GetString("email")) ;
		}		
		yield return null;		
	}
}