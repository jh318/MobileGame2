using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	void Awake(){
		if(instance == null){
			instance = this;
			DontDestroyOnLoad(gameObject);
		} 
		else Destroy(gameObject);
	}

	void OnEnable(){
		PlayerController.playerDeath += PlayerDeath;
		SceneManager.sceneLoaded += SceneLoaded;
	}

	void OnDisable(){
		PlayerController.playerDeath -= PlayerDeath;
		SceneManager.sceneLoaded -= SceneLoaded;
	}

	void Update(){
		StartGame();
		GameOverToStart();
	}

	//Functions
	private void PlayerDeath(){
		SceneManager.LoadScene("GameOverScene");
	}

	private void SceneLoaded(Scene scene, LoadSceneMode mode){
		if(scene.name == "GameOverScene"){
			Debug.Log("Game Over");
		}
		if(scene.name == "StartScene"){
			Debug.Log("StartScene");
		}
		if(scene.name == "GameScene"){
			Debug.Log("GameScene");
		}
	}

	private void StartGame(){
		if(Input.GetKeyDown(KeyCode.Space)){
			if(SceneManager.GetActiveScene().name == "StartScene"){
				SceneManager.LoadScene("GameScene");
			}
		}
	}

	public void StartGameTouch(){
		SceneManager.LoadScene("GameScene");
	}

	private void GameOverToStart(){
		if(Input.GetKeyDown(KeyCode.Space)){
			if(SceneManager.GetActiveScene().name == "GameOverScene"){
				SceneManager.LoadScene("StartScene");
			}
		}
	}

	public void GameOverToStartTouch(){
		SceneManager.LoadScene("StartScene");
	}

	


}
