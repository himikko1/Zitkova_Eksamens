using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GalvenaisKods : MonoBehaviour {
	public List<Atbilde> JuA;
	public GameObject[] opcijas;
	public int jautajumsTagad;

	public GameObject JautajumuAttels;
	public GameObject TryAgainButton;

	public Text JautajumsText;
	public Text PunktiTxt;
	int JautajumsTagad = 0;
	public int punkti;

	public Text JautajumsTxt;
	private void Start(){
		JautajumsTagad = JuA.Count;
		JautajumuAttels.SetActive (false);
		genereJautajumu();
	}

	public void retry(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

 void SpeleBeidzas(){
		JautajumuAttels.SetActive (false);
		JautajumuAttels.SetActive (true);
		PunktiTxt.text = punkti + "/" + JautajumsTagad;
	}

	public void pareizi(){
		punkti += 1;
		JuA.RemoveAt (jautajumsTagad);
		genereJautajumu ();
	}

	public void nepareizi(){
		//kad atbildi nepareizi
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
		if (JuA.Count > 0) {
			jautajumsTagad = Random.Range (0, JuA.Count);
			JautajumsTxt.text = JuA [jautajumsTagad].jautajums;
			Debug.Log (JuA [jautajumsTagad].jautajums);
			Atbildes ();
		} else {
			Debug.Log ("Out of Questions");
			SpeleBeidzas ();
		}

	}
}
