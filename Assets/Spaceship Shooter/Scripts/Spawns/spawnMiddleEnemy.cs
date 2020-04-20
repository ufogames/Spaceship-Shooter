using UnityEngine;
using System.Collections;

public class spawnMiddleEnemy : MonoBehaviour {

	//variável para receber o prefab do inimigo
	public 		GameObject		enemy, enemy2;

	//variáveis para receber o tempo de spawn, posições e tempo
	public		float 			delay;
	public		Transform		left, right;
	public		float 			tempTime;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		tempTime += Time.deltaTime;
		if (tempTime >= delay) {
			tempTime = 0;
			spawn ();
		}
	}

	//função para instanciar o prefab do inimigo na posição desejada
	void spawn(){
		float rand = Random.Range (0, 100);
		if (rand <= 25) {
			GameObject tempSpawn = Instantiate (enemy) as GameObject;
			tempSpawn.transform.position = left.transform.position;
			tempSpawn.name = "Left Light Enemy";
		} else if (rand >= 75) {
			GameObject tempSpawn = Instantiate (enemy2) as GameObject;
			tempSpawn.transform.position = right.transform.position;
			tempSpawn.name = "Right Light Enemy";
		}
	}
}
