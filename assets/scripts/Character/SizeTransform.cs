using UnityEngine;
using System.Collections;

public class SizeTransform : MonoBehaviour {

	private Vector3 originalScale = new Vector3 (0.55f, 0.55f, 0.55f); 
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		float multiplier = GameManager.Instance.Health / 100f;
		Debug.Log (multiplier);
		if (multiplier > 0.2) {
			gameObject.transform.localScale = originalScale * multiplier;
		}
	}
}
