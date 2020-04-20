using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class _GC : MonoBehaviour {
	
	//conversar com o script do player para poder pegar o transform
	private		player 			playerScript;

	[Header("Visible Verification")]
	//variável para verificar se o player está na tela
	//public		bool			visible;

	[Header("Spawn")]
	//variáveis de spawn para o player
	public		Transform 		spawnPlayer;
	public		GameObject 		player;

	[Header("Ponctuation")]
	//variáveis de pontuação
	public		Text			ponctuation;
	public		int				points;

	[Header("Lifes")]
	//variáveis de vida
	public		Text			lifesTXT;
	public		int 			lifes;

	// Use this for initialization
	void Start () {
		//inicializando o script do player
		playerScript = FindObjectOfType (typeof(player)) as player;

		//iniciando a função de spawnar o player
		spawnStart();
	}
	
	// Update is called once per frame
	void Update () {
		//convertendo a pontuação para texto
		ponctuation.text = points.ToString();

		//convertendo a vidas para text
		lifesTXT.text = lifes.ToString();
	}

	//função responsável por spawnar o player
	void spawnStart(){
		GameObject tempSpawnPlayer = Instantiate (player) as GameObject;
		tempSpawnPlayer.transform.position = spawnPlayer.position;
		tempSpawnPlayer.name = "Player";
	}

	//função para Game Over
	public void dead(){
		if (lifes > 0) {
			lifes -= 1;
			Invoke ("spawnStart", 2.5f);
		} else if (lifes == 0) {
			Invoke ("GameOver", 5f);
		}
	}

	//função para chamar Cena do GameOver
	public void GameOver(){
		//PlayerPrefs.SetInt ("recorde", points);

		if (points > PlayerPrefs.GetInt ("recorde")) {
			PlayerPrefs.SetInt ("recorde", points);
		}

		SceneManager.LoadScene ("GameOver");
	}

	//função para iniciar o jogo
	public void play(){
		SceneManager.LoadScene ("Stage1");
	}
}
