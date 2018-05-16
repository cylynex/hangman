using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showWord : MonoBehaviour {

    public Text wordSlot;

	// Use this for initialization
	void Start () {
        wordSlot.text = GameManager.word;
        GameManager.word = null;
	}
	
	
}
