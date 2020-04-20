using UnityEngine;
using System.Collections;

public class becameInvisible : MonoBehaviour {
	//função para destruir o objeto ao sair da visão da câmera
	void OnBecameInvisible () {
		Destroy (this.gameObject);
	}

	//função para destruir o tiro ao sofrer colisão com o inimigo, atravessar outros triggers
	void OnTriggerEnter2D (Collider2D col){
		if (!col.isTrigger || col.tag == "fireDestroy") {
			Destroy (this.gameObject);
		}
	}
}
