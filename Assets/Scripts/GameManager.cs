using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public enum GameState { PLAYING, GAMEOVER, PAUSE };
	[SerializeField] public GameState gamestate;

	public static GameManager instance;
	[SerializeField] Slider volumeSlider;
	[SerializeField] TMP_Text countdownText;
	[SerializeField] TMP_Text scoreText;
	[SerializeField] Canvas HUD;
	[SerializeField] RoadSpawner roadSpawner;
	[SerializeField] int score;


	private void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

		gamestate = GameState.PLAYING;
		score = 0;
	}

	private void Start()
	{
		SetVolume();
	}

	public void StartGame()
	{
		gamestate = GameState.PAUSE;
		SceneManager.LoadScene(1);
		StartCoroutine(GameStartIntro());
	}

	private void AssignUI()
	{
		HUD = FindFirstObjectByType<Canvas>();
		countdownText = HUD.GetComponentsInChildren<TMP_Text>()[1];
		scoreText = HUD.GetComponentsInChildren<TMP_Text>()[0];
	}

	public void SetVolume()
	{
		if(volumeSlider == null) return;
		AudioListener.volume = volumeSlider.value;
	}

	public void UpdateScore()
	{
		if (scoreText == null) return;
		scoreText.text = $"Score: {score}";
	}

	public void AddScore()
	{
		score++;
		UpdateScore();
	}

	public IEnumerator GameStartIntro()
	{
		yield return new WaitForSeconds(.1f);
		AssignUI();
		score = 0;
		roadSpawner = FindFirstObjectByType<RoadSpawner>();
		yield return new WaitForSeconds(1.5f);
		countdownText.text = "2";
		yield return new WaitForSeconds(1.5f);
		countdownText.text = "1";
		yield return new WaitForSeconds(1.5f);
		countdownText.text = "GO!";
		yield return new WaitForSeconds(1.5f);
		roadSpawner.SpawnStart();
		countdownText.gameObject.SetActive(false);
		gamestate = GameState.PLAYING;
	}
}
