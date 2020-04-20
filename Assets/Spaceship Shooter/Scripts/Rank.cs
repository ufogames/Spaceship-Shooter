using UnityEngine;
using System.Collections;

public class Rank : MonoBehaviour {

	public int[] vetRank;
	// Use this for initialization
	void Start () {
		vetRank = new int[10]; // array do rank
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < vetRank.Length; i++) {
			vetRank [i] = Random.Range (0, 100); // atribuindo valores randomicos para o array
		}

		for (int i = 0; i < vetRank.Length; i++) {
			PlayerPrefs.SetInt ("rank"+i.ToString(), vetRank [i]); // armazendo os valores do rank no playprefs chamado "rank0", "rank1", "rank2" ... "rankN"
		}

		for (int i = 0; i < vetRank.Length; i++) {
			PlayerPrefs.GetInt ("rank"+i.ToString()); // adquirindo os valores do rank no playprefs
		}
	}
}
