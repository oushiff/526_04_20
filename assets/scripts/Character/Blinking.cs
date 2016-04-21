using UnityEngine;
using System.Collections;

public class Blinking : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(DoBlinks(3f, 0.2f));
	}

	IEnumerator DoBlinks(float duration, float blinkTime) {
		while (duration > 0f) {
			duration -= Time.deltaTime;

			//toggle renderer
			GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;

			//wait for a bit
			yield return new WaitForSeconds(blinkTime);
		}

		//make sure renderer is enabled when we exit
		GetComponent<Renderer>().enabled = true;
	}


	// Update is called once per frame
	void Update () {
	
	}
}
