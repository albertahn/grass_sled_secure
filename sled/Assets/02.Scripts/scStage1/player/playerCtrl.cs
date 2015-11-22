using UnityEngine;
using System.Collections;

public class playerCtrl : MonoBehaviour {
	public float vspeed;
	public float h;
	public float v;

	private Transform tr;
	private float hSpeed;
	public float maxVspeed;
	private float minVspeed;

	public float preTime;
	public bool isDead;

	static public float basicAngle;
	private float sensiAngle;

	private GameMgr _gameMgr;





	// Use this for initialization
	void Start () {

		//screen
		//Screen.SetResolution(600, 1024 , true);


		h = 0.0f;
		v = 0.0f;
		vspeed = 20.0f;
		hSpeed = 40.0f;
		tr = GetComponent<Transform> ();
		isDead = false;
		basicAngle = -0.5f;
		sensiAngle = 0.3f;
		playerState.state = playerState.idle;
		maxVspeed = 40.0f;
		minVspeed = 20.0f;
		_gameMgr = GameObject.Find ("GameManager").GetComponent<GameMgr> ();




	}
	
	// Update is called once per frame
	void Update () {

		if (maxVspeed > minVspeed) {
			minVspeed = minVspeed + Time.time / 200;		
		
		}

		
		
		if (isDead) {

						playerState.state = playerState.felt;
						//vspeed=20.0f;
				} else {

						#if UNITY_ANDROID||UNITY_IPHONE
						h = Input.acceleration.x;
						v = Input.acceleration.y;

						if (Time.time - preTime > 0.1f) {//0.1초마다 실행

								if (v <= basicAngle - sensiAngle) {
										vspeed -= 2;
										playerState.state = playerState._break;
										if (vspeed <= minVspeed)
												vspeed = minVspeed;
								} else {
										//playerState.state = playerState.accel;
										vspeed += 2;
										if (vspeed >= maxVspeed)
												vspeed = maxVspeed;
				
								
									if (h > 0.1f) {
										h = 1.0f;
										playerState.state = playerState.right;
					} else if (h <= -0.1f) {
										h = -1.0f;
										playerState.state = playerState.left;
									} else {
										playerState.state = playerState.idle;
									}
								}
								preTime = Time.time;
						}
								#else
						h = Input.GetAxis ("Horizontal");
						v = Input.GetAxis ("Vertical");


			if(Time.time - preTime > 0.1f){
					if (v <= -0.1f) {
						playerState.state = playerState._break;
						vspeed -= 2;
						if (vspeed <= minVspeed)
							vspeed = minVspeed;
					}else{						
						playerState.state = playerState.accel;
						vspeed += 2;
						if (vspeed >= maxVspeed)
							vspeed = maxVspeed;						
					}
					preTime = Time.time;
				
				if(h>0.1f)
				{
					playerState.state = playerState.right;
				h=1.0f;
			}
			else if(h<=-0.1f)
				{
				playerState.state = playerState.left;
				h=-1.0f;
			}

		
			}
								#endif
						}



		//Vector3 pos = new Vector3 (tr.position.x,tr.position.y,  hSpeed  ); 


						tr.Translate (Vector3.right * hSpeed * h * Time.deltaTime, Space.Self);

		//Vector3 pos = tr.position +Vector3.forward * hSpeed * h*Time.deltaTime*5.0f+ Vector3.left * vspeed * Time.deltaTime*3.0f;


		tr.Translate (Vector3.forward * vspeed * Time.deltaTime, Space.Self);	

//		Debug.Log (pos);
		
		//tr.position = Vector3.Lerp (tr.position, pos, Time.deltaTime*15.0f );//.Translate (Vector3.right * hSpeed * h * Time.deltaTime, Space.Self);

			}

}
