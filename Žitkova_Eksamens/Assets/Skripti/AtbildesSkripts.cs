﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtbildesSkripts : MonoBehaviour {
	public bool pareizs = false;
	public GalvenaisKods galvenaisKods;

	public void Atbilde(){
		if (pareizs) {
			Debug.Log ("Pareiza atbilde!");
			galvenaisKods.pareizi ();
		} else {
			Debug.Log ("Nepareiza atbilde!");
			GetComponent<Image> ().color = Color.red;
			galvenaisKods.nepareizi ();
		}
	}
}
