using UnityEngine;
using System.Collections;

public class playerAni : MonoBehaviour {
	private float h;
	private float v;
	private playerCtrl _playerCtrl;
	public GameObject WaterFall1;
	public GameObject WaterFall2;


	[System.Serializable]
	public class Anim{
		public AnimationClip idle;
		public AnimationClip left;
		public AnimationClip right;
		public AnimationClip _break;
		public AnimationClip accel;
		public AnimationClip felt;
	}

	public Anim anim;
	public Animation _animation;


	public AudioClip pig_sound;
	public AudioClip coin_sound;
	public AudioClip man_scream;

	public AudioClip swoosh_turn;

	public AudioClip musicback;

	private GameMgr _gameMgr;


	// Use this for initialization
	void Start () {

		_gameMgr = GameObject.Find ("GameManager").GetComponent<GameMgr> ();
		_animation = GetComponentInChildren<Animation> ();
		_animation.clip = anim.idle;
		_animation.Play ();
		_playerCtrl = GetComponent<playerCtrl> ();
		WaterFall1 = GameObject.Find ("/player/WaterFall1");
		WaterFall2 = GameObject.Find ("/player/WaterFall2");

		//StartCoroutine(this.PlaySfx(musicback,0.9f));
	}
	
	// Update is called once per frame
	void Update () {
		if (!_playerCtrl.isDead) {
						h = _playerCtrl.h;
						v = _playerCtrl.v;

			switch(playerState.state){
				case 0:
				_animation.CrossFade (anim.accel.name, 0.3f);
				break;
				case 1:
				_animation.CrossFade (anim._break.name, 0.3f);					
					break;
				case 2:
				_animation.CrossFade (anim.right.name, 0.3f);

				//StartCoroutine(this.justplaySfx(swoosh_turn,1));

				break;
				case 3:
				_animation.CrossFade (anim.left.name, 0.3f);	

				//StartCoroutine(this.justplaySfx(swoosh_turn,0.9f));
				break;
				case 4:
				_animation.CrossFade (anim.idle.name, 0.3f);				
				break;
				case 5:
				_animation.CrossFade (anim.felt.name, 0.3f);				
				break;
			}



			if(_playerCtrl.vspeed<20){
				WaterFall1.particleEmitter.minSize=0.2f;
				WaterFall1.particleEmitter.maxSize=0.5f;

				WaterFall2.particleEmitter.minSize=0.2f;
				WaterFall2.particleEmitter.maxSize=0.5f;

			}else if(_playerCtrl.vspeed>=20&&_playerCtrl.vspeed<30){
				WaterFall1.particleEmitter.minSize=0.5f;
				WaterFall1.particleEmitter.maxSize=1.0f;
				
				WaterFall2.particleEmitter.minSize=0.5f;
				WaterFall2.particleEmitter.maxSize=1.0f;

			}else if(_playerCtrl.vspeed>=30){
				WaterFall1.particleEmitter.minSize=1.0f;
				WaterFall1.particleEmitter.maxSize=1.5f;
				
				WaterFall2.particleEmitter.minSize=1.0f;
				WaterFall2.particleEmitter.maxSize=1.5f;

			} 
		}
	}

	void OnCollisionEnter(Collision coll)
	{
		if (coll.collider.tag == "TREE"||coll.collider.tag == "PIG") {
			if(coll.collider.tag=="PIG")
				StartCoroutine(this.PlaySfx(pig_sound,0.9f));
			_playerCtrl.isDead=true;
			PlayerPrefs.SetString("points",_gameMgr.coin.ToString());
			//Debug.Log ("hihi : "+_gameMgr.coin.ToString());
			StartCoroutine(this.PlaySfx(man_scream,0.6f));
			StartCoroutine(dead());
			_animation.CrossFade(anim.felt.name,0.3f);
		}
	}

	void OnTriggerEnter(Collider coll){
		if (coll.collider.tag == "COIN") {
			StartCoroutine(this.PlaySfx(coin_sound,0.9f));
		}
	}

	IEnumerator dead(){

		yield return new WaitForSeconds(3.0f);


		Application.LoadLevel("scDeath");
	}

	IEnumerator PlaySfx(AudioClip _clip,float volume){
		audio.PlayOneShot (_clip, volume);
		yield return null;
	}

	IEnumerator justplaySfx(AudioClip _clip,float volume){
		//audio.PlayOneShot (_clip, volume);
		audio.PlayOneShot (_clip, volume);
	
		yield return null;
	}
}
