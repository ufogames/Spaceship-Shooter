﻿using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

	//script GC
	private		_GC				_GC;

	//corpo do inimigo
	private		Rigidbody2D		enemyRB;

	[Header("Moviment")]
	//variável de velocidade do inimigo
	public		float			velocidade;
	public 		float 			movimentX, movimentY;

	[Header("Life Enemy")]
	//vida do inimigo
	public		GameObject		explosionPrefab;
	public		int 			HP;

	[Header("Ponctuation")]
	//variáveis de pontuação
	public		int				pointsEnemy;

	[Header("Loot")]
	//variáveis do loot
	public		GameObject		loot; 
	public		GameObject		loot2;
	public		int 			chanceDrop;
	private		int 			randomDrop;

	[Header("Type Enemy")]
	//tipo de inimigo para o som
	public		string			typeEnemy;

	// Use this for initialization
	void Start () {
		//inicializando o RB do inimigo
		enemyRB = GetComponent<Rigidbody2D> ();

		//inicializando o script
		_GC = FindObjectOfType(typeof(_GC)) as _GC;
	}
	
	// Update is called once per frame
	void Update () {
		//adicionando velocidade ao inimigo
		enemyRB.velocity = new Vector2 (movimentX * velocidade, movimentY * velocidade);
	}

	//função para detectar colisão com triggers
	void OnTriggerEnter2D (Collider2D col){
		switch(col.gameObject.tag){
			case "laserPlayer":
				damage (1);
			break;
		}
	}

	//função para detectar colisão com colliders
	void OnCollisionEnter2D (Collision2D col){
		switch(col.gameObject.tag){
			case "Player":
				dead ();
			break;
		}
	}

	//função para receber dano
	void damage(int getDamage){
		HP -= getDamage;
		if (HP <= 0) {
			dead ();
		}
	}

	//função para spawnar a animação de explosão ao morrer e powerUps
	void dead(){
		GameObject tempExplosion = Instantiate (explosionPrefab) as GameObject;
		tempExplosion.transform.position = transform.position;
		tempExplosion.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 1);
		_GC.points += pointsEnemy;

		//função para instaciar os sons para cara tipo de inimigo
		switch (typeEnemy) {
			case "Heavy":
				soundFX.playSound (sound.explosionHeavyEnemy);
			break;
			case "Light":
				soundFX.playSound (sound.explosionLightEnemy);
			break;
		}

		//função para spawnar loot
		randomDrop = Random.Range (0, 100);

		if (randomDrop <= chanceDrop) {
			randomDrop = Random.Range (0, 100);
			if (randomDrop <= 95) {
				GameObject tempPrefabDrop = Instantiate (loot) as GameObject;
				tempPrefabDrop.transform.position = transform.position;
			} else if (randomDrop > 95) {
				GameObject tempPrefabDrop = Instantiate (loot2) as GameObject;
				tempPrefabDrop.transform.position = transform.position;
			}
		}

		//linha para destruir o objeto deposi do tempo escolhido
		Destroy (tempExplosion, 1);
		Destroy (this.gameObject);
	}
}
