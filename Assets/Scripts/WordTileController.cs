using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WordTileController : MonoBehaviour {

    public Letter letterData;

    void Start() {
        GetComponent<SpriteRenderer>().sprite = letterData.letterImage;
    }


    void OnMouseDown() {
        WordController.theWord += letterData.letter;
        Debug.Log(WordController.theWord);
        Wordpicker.lettersLeft--;
        if (Wordpicker.lettersLeft <= 0) {
            SceneManager.LoadScene("Game");
        }
    }

}
