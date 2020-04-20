using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//função para iniciar o jogo
	public void play(){
		SceneManager.LoadScene ("Stage1");
	}

	//função para retornar ao jogo
	public void retry(){
		SceneManager.LoadScene ("Stage1");
	}

	//função para retornar ao menu principal
	public void menuPrincipal(){
		SceneManager.LoadScene ("Menu");
	}

	//função para sair do jogo
	public void quitGame(){
		Application.Quit ();
	}
}
