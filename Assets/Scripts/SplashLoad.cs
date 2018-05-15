﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashLoad : MonoBehaviour {

    void Start() {
        StartCoroutine("LoadGame");
    }


    IEnumerator LoadGame() {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("Home");
    }
}
