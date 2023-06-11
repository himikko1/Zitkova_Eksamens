
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VardaParadisana : MonoBehaviour {
	
	public GameObject vards;
	public GameObject dropDown;
	public GameObject tests;
	public string text;
	public GameObject inputField;
	public GameObject textAppear;
	public void saveText(){
		text = inputField.GetComponent<Text> ().text;
		textAppear.GetComponent<Text>().text = "Sveiki, " +text.ToUpper()+"!";
		tests.SetActive (true);
		vards.SetActive (false);
	}
	void Start(){
		dropDown.SetActive (false);
		tests.SetActive (false);
	}

}