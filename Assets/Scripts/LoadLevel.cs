using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManager;

public class LoadLevel : MonoBehaviour {

    public void LoadNewLevel(string levelToLoad) {
        SceneManager.loadScene(levelToLoad);
    }

}
