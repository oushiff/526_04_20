using UnityEngine;
using System.Collections;

public class Jag : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider2d)
	{
		if (collider2d.gameObject.tag == "PlayerSnow" || collider2d.gameObject.tag == "PlayerCloud")
		{
			GetAttacked();
		}
	}


	[SerializeField]
	private float healthDecrease = 20;

	private void GetAttacked()
	{
		GameManager.Instance.Health += healthDecrease;
		if (GameManager.Instance.Health <= 0) {
			//GameManager.Instance.RestartGame ();
			transform.parent.gameObject.AddComponent<GameOver>();
		}

	}
}
