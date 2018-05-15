using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour {

    [Header("Setup Stuff")]
    public Letter letterData;
    public Sprite FlippedTileBad;
    public Sprite FlippedTileGood;
    AudioSource[] sounds;

    private string theWord;
    private Sprite currentTileImage;
    private bool tileMatch = false;

    GameManager gameManager;

    void Start() {
        GetComponent<SpriteRenderer>().sprite = letterData.letterImage;
        theWord = GameManager.word;
        sounds = GetComponents<AudioSource>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }


    void OnMouseDown() {
        tileMatch = false;

        for (int i = 0; i < theWord.Length; i++) {
            if (theWord[i] == letterData.letter) {
                tileMatch = true;
                gameManager.FlipThisTile(i,letterData.letterID);
            } 
        }

        // Flip Tile
        GetComponent<BoxCollider2D>().enabled = false;
        if (tileMatch) {
            GetComponent<SpriteRenderer>().sprite = FlippedTileGood;
            sounds[1].Play();
        } else {
            GetComponent<SpriteRenderer>().sprite = FlippedTileBad;
            sounds[0].Play();
            gameManager.HangTime();
        }


    }

}
