using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour {

    public Letter letterData;
    private string theWord;
    private Sprite currentTileImage;

    void Start() {
        GetComponent<SpriteRenderer>().sprite = letterData.letterImage;
        theWord = GameManager.word;
    }


    void OnMouseDown() {
        Debug.Log("Clicked: " + letterData.letter);
        Debug.Log("comparing to: " + theWord);

        for (int i = 0; i < theWord.Length; i++) {
            Debug.Log(theWord[i]+ " - "+letterData.letter);
            if (theWord[i] == letterData.letter) {
                Debug.Log("Letter Matched Flip Tile");
            }
        }

    }

}
