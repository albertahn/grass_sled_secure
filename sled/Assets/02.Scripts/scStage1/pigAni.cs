using UnityEngine;
using System.Collections;

public class pigAni : MonoBehaviour {
	[System.Serializable]
	public class Anim{
		public AnimationClip walk;
		public AnimationClip tramble;
	}
	public Anim anim;
	public Animation _animation;
	pigCtrl _pigCtrl;


	// Use this for initialization
	void Start () {
		_pigCtrl = GetComponent<pigCtrl> ();
		_animation = GetComponentInChildren<Animation>();
		_animation.clip = anim.walk;
		_animation.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if (_pigCtrl.moveSpeed <= 1.0f) {
						_animation.CrossFade (anim.tramble.name, 0.3f);
		} else if (_pigCtrl.moveSpeed >= 4.9f) {
			_animation.CrossFade(anim.walk.name,0.3f);
		}
	
	}
}
