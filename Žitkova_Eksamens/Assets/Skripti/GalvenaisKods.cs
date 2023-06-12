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

	public bool noPirmasReizes= true;

	public Text JautajumsText;
	public Text PunktiTxt;
	int JautajumsTagad = 0;
	public int punkti;

	//public Text JautajumsTxt;
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
		Debug.Log ("Pareizi nak jautajums");
		if (noPirmasReizes == false) {
			noPirmasReizes = true;
		} else {
			punkti += 1;
		}
		JuA.RemoveAt (jautajumsTagad);
		genereJautajumu ();
		for(int i=0; i<opcijas.Length;i++){
			opcijas [i].GetComponent<Image>().color = Color.white;
		}
	}

	public void nepareizi(){
		//kad atbildi nepareizi
		noPirmasReizes = false;
		Atbildes ();
	}

	void Atbildes(){
		for (int i = 0; i < opcijas.Length; i++) {
			opcijas [i].GetComponent<AtbildesSkripts>().pareizs = false;
			opcijas [i].transform.GetChild (0).GetComponent<Text> ().text = JuA [jautajumsTagad].atbildes [i];
			if (JuA [jautajumsTagad].pareizaAtbilde == i) {
				opcijas [i].GetComponent<AtbildesSkripts> ().pareizs = true;
			}
			Debug.Log ("Opcija = "+opcijas[i]+"="+opcijas [i].GetComponent<AtbildesSkripts>().pareizs);
		}
	}

	void genereJautajumu(){
		if (JuA.Count > 0) {
			jautajumsTagad = Random.Range (0, JuA.Count);
			JautajumsText.text = JuA [jautajumsTagad].jautajums;
			Debug.Log (JuA [jautajumsTagad].jautajums);
			Atbildes ();
		} else {
			Debug.Log ("Out of Questions");
			SpeleBeidzas ();
		}

	}
}
