using UnityEngine;
using System.Collections;

public class SizeTransform : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		if (GameManager.Instance.Bleeding == true) {
			gameObject.transform.localScale /= 1.1f;
		}
	}
}
