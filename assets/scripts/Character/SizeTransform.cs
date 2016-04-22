using UnityEngine;
using System.Collections;

public class SizeTransform : MonoBehaviour {

	private Vector3 originalScale = new Vector3 (1, 1, 1); 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		float multiplier = GameManager.Instance.Health / 100f;
		Debug.LogError (multiplier);
		if(multiplier > 0.2)	gameObject.transform.localScale = originalScale * multiplier;
		
	}
}
