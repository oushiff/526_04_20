using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> {

	private float _timeRemaining;

	public float TimeRemaining 
	{
		get { return _timeRemaining; }
		set { _timeRemaining = value; }
	}

	private int _numCoins;

	public int NumCoins {
		get { return _numCoins; }
		set { _numCoins = value; }
	}

    private float _timeConsumed;

    public float TimeConsumed
    {
        get { return _timeConsumed; }
        set { _timeConsumed = value; }
    }

    private int _coinsGot;

    public int CoinsGot
    {
        get { return _coinsGot; }
        set { _coinsGot = value; }
    }

	[SerializeField]
	private float _health = 100f;

	public float Health
	{
		get { return _health; }
		set { _health = value; }
	}

	private string _status = "PlayerSnow";

	public string Status
	{
		get{ return _status; }
		set{ _status = value; }
	}

	private bool _invincible = false;

	public bool Invincible
	{
		get{
			return _invincible;
		}

		set{
			_invincible = value;
		}
	}

	private float _invincibleTime = 0f;

	public float InvincibleTime{
		get{
			return _invincibleTime;
		}

		set{
			_invincibleTime = value;
		}

	}

	private bool _bleeding  = false;

	public bool Bleeding{
		get{
			return _bleeding;
		}

		set{
			_invincible = value;
		}
	}


	private float _bleedingTime = 0f;

	public float BleedingTime{
		get{
			return _bleedingTime;
		}

		set{
			_bleedingTime = value;
		}
	}

	[SerializeField]
	private float bleedingTimeMax = 2.0f;

	public void EnableBleeding(){
		Bleeding = true;
		BleedingTime = bleedingTimeMax;
	}

	private float maxTime = 180; // In seconds.

	private float maxHealth = 100; // The max health of the hero

	// Use this for initialization
	void Start () {
		TimeRemaining = maxTime;
		Health = maxHealth;
	}

	public void DecreaseHealth(float DecreaseValue){
		Health -= DecreaseValue;
	}


	// Update is called once per frame
	void Update () {
		//Modify later to unify the place of restart
		if (Health <= 0) {
			transform.parent.gameObject.AddComponent<GameOver>();
		}

		TimeRemaining -= Time.deltaTime;

		if (TimeRemaining <= 0) {
			//RestartGame ();
			transform.parent.gameObject.AddComponent<GameOver>();
		}

		if (InvincibleTime > 0 && Invincible == true) {
			InvincibleTime -= Time.deltaTime;
			/*
			Debug.LogError (Invincible);
			Debug.LogError (InvincibleTime);
			*/
			if (InvincibleTime <= 0) {
				InvincibleTime = 0f;
				Invincible = false;

				//Debug.LogError (Invincible);
				//Debug.LogError (InvincibleTime);
			}
		}

		if (BleedingTime > 0 && Bleeding == true) {
			BleedingTime -= Time.deltaTime;

			if (BleedingTime <= 0) {
				BleedingTime = 0f;
				Bleeding = false;
			}
		}
	}

	void FixedUpdate(){

		if (Status == "PlayerCloud" && Invincible == false) 
		{
			Debug.LogError("PlayerCloud Heath:" + Health);
			//Health -= CloudStateHeathMinusValue;
			Health -= 0.01f;
		}

	}


	public void RestartGame(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		ResetPlayerProperty ();
	}

	public void ResetPlayerProperty(){
		TimeRemaining = maxTime;
		NumCoins = 0;
		Health = maxHealth;
		Status = "PlayerSnow";
	}
}
