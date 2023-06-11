
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VardaParadisana : MonoBehaviour {
	public GameObject ConnectionTesterStatus;
	public string text;
	public GameObject inputField;
	public GameObject textAppear;
	public void saveText(){
		text = inputField.GetComponent<Text> ().text;
		textAppear.GetComponent<Text>().text = "Sveiki, " +text.ToUpper()+"!";
	}

}