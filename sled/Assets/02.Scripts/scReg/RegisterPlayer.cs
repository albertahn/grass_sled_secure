using UnityEngine;
using System.Collections;

using Boomlagoon.JSON;


public class RegisterPlayer : MonoBehaviour {

	//GUISkin mySkin = GUI.skin;
	
	public bool UsernameCORRECT = false;
	public	bool PasswordCORRECT = false;


	string GameOwner;
	string GameOwnerPassword;

	
	public string PlayerUsername, Email ;
	public	string PlayerPassword;
	public	string RePlayerPassword;

//player username logged afteer
	private string username;
	private string hintPart;

	public int login_btn_height;

	private Server LoginServer; //= GetComponent<Server>();

	//single player;
	
	public int singleLeft, singleRight, singleTop, singleBottom;

	// Use this for initialization
	void Start () {
		Screen.SetResolution (800, 480, true);

		LoginServer = GetComponent<Server>();

	
		PlayerPassword = "";

		//Single player ints
		
		singleLeft  = (int)(Screen.width / 12);
		singleRight = (int)(Screen.width / 2);
		singleTop = (int)(Screen.width / 9);
		singleBottom = (int)(Screen.width / 5);
}
	


void Update () {
		//Debug.Log("gameown"+PlayerUsername+":GameOwnerPassword:"+PlayerPassword);
	}

	public void OnGUI(){
			//email label
			GUI.Label (new Rect (80,80,120,100), "<size=40>Email:</size>");
			//pass label
			GUI.Label (new Rect (80,150,500,200), "<size=40>Password:</size>");
			//re pass
			GUI.Label (new Rect (80,220,500,100), "<size=40>Re-Password:</size>");
			//username
			GUI.Label (new Rect (80,290,500,100), "<size=40>username:</size>");


			GUILayout.Label(""+hintPart);
			GUI.backgroundColor = Color.white;

		//Text area for the username
			Email = GUI.TextArea (new Rect(350,80,400,60),Email,  100);

		//Text area for the password
			PlayerPassword = GUI.PasswordField(new Rect (350,150,400,60), PlayerPassword, "*"[0], 25); //(new Rect(GeneralWidth,PassHeight,100,20),PlayerPassword);
			//repassword
			RePlayerPassword = GUI.PasswordField(new Rect (350,220,400,60), RePlayerPassword, "*"[0], 25);
         //player username 
			PlayerUsername = GUI.TextArea (new Rect(350,290,400,60),PlayerUsername,  100);

		// login 
			if (GUI.Button (new Rect (350,380,100,60), "Submit")) {


            //login button
				StartCoroutine (RegLoginData(Email, PlayerPassword,RePlayerPassword, PlayerUsername ));
				 }//endifelsegui


			// Loads level (0). This map can be set in the build settings
			if (GUI.Button (new Rect (460,380,100,60), "Cancel")) {

				Application.LoadLevel ("scPreStart");

			}//endifelsegui
		
	}//end gui

//getlogin data

	private IEnumerator RegLoginData (string email, string password, string password2, string username)
	{

		yield return StartCoroutine (LoginServer.RegUser(Email, PlayerPassword,RePlayerPassword, PlayerUsername ));

		string emailman = LoginServer.fuckdata.GetString ("password");


		Debug.Log("emailman : "+ LoginServer.fuckdata.GetString("email")) ;

		username = LoginServer.fuckdata.GetString("username");

		if(username !=""){
			Debug.Log("loggedin fucker : "+LoginServer.fuckdata.GetString("email")) ;			
			Application.LoadLevel ("scPreStart");

		}else{
			hintPart ="Username or Password was Incorrect";

			Debug.Log("not logged in : "+LoginServer.fuckdata.GetString("email")) ;
		}

		yield return null;			
	}
}
