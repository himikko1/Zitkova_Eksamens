using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GalvenaisKods : MonoBehaviour {
	public List<Atbilde> JuA;
	public GameObject[] opcijas;
	public int jautajumsTagad;

	public Text JautajumsTxt;
	private void Start(){
		genereJautajumu();
	}

	public void pareizi(){
		JuA.RemoveAt (jautajumsTagad);
		genereJautajumu ();
	}

	void Atbildes(){
		for (int i = 0; i < opcijas.Length; i++) {
			opcijas [i].GetComponent<AtbildesSkripts>().pareizs = false;
			opcijas [i].transform.GetChild (0).GetComponent<Text> ().text = JuA [jautajumsTagad].atbildes [i];
			if (JuA [jautajumsTagad].pareizaAtbilde == +1) {
				opcijas [i].GetComponent<AtbildesSkripts> ().pareizs = true;
			}
		}
	}

	void genereJautajumu(){
		jautajumsTagad = Random.Range (0, JuA.Count);
		JautajumsTxt.text = JuA [jautajumsTagad].jautajums;
		Debug.Log (JuA [jautajumsTagad].jautajums);
		Atbildes ();

	}
}
