using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [Header("Letters")]
    public Letter[] letters;
    public GameObject letterPrefab;
    public Transform letterHolder;
    public GameObject blankLetterPrefab;
    public Transform blankLetterHolder;
    public Sprite underscore;
    public Transform[] underscores;

    [Header("Word")]
    public static string word = "cylynex";

    private Vector3 letterSpot;
    private Quaternion letterRotation;
    private float zRot;

    private float letterSpotX;
    private float letterSpotY;

    private int numLetters;
    private int numLettersLeft;
    int misses = 0;

    // Hangman stuff
    public GameObject[] hangParts;


    void Start() {

        // Setup the Letters
        InitLetters();

        // Setup tiles for the word.
        InitTiles(); 


    }
	

    // Setup the letters
    void InitLetters() {

        misses = 0;
        numLetters = word.Length;
        numLettersLeft = numLetters;

        // Init vector3
        letterSpot = new Vector3(-6, 3.7f, 0);

        int lSpot = 0;
        for (int i = 0; i < letters.Length; i++) {
            lSpot++;
            // Create the letter tile
            GameObject thisLetter = (GameObject)Instantiate(letterPrefab, letterSpot, letterRotation);
            thisLetter.transform.SetParent(letterHolder.transform);

            // Setup next spot for next tile
            letterSpotX = thisLetter.transform.position.x + 1.2f;

            // Advance Y if we reset X if over a certain value
            if (lSpot > 5) {
                letterSpotY = thisLetter.transform.position.y - 1.4f;
                letterSpotX = -6f;
                lSpot = 0;
            } else {
                letterSpotY = thisLetter.transform.position.y;
            }


            letterSpot = new Vector3(letterSpotX, letterSpotY, 0);

            // Setup some random rotation which will be used for the next tile
            zRot = Random.Range(-20, 20);
            letterRotation = Quaternion.Euler(thisLetter.transform.rotation.x, thisLetter.transform.rotation.y, zRot);

            // Send over the object
            thisLetter.GetComponent<TileController>().letterData = letters[i];

        }
    }


    // Setup the Tiles
    void InitTiles() {
        //float spacing = numLetters / 2;
        //float xSpot = -(spacing) - 1;
        float xSpot = -6f;
        float ySpot = -4.2f;

        Vector3 firstSpot = new Vector3(xSpot, ySpot, 0);
        for (int i = 0; i < numLetters; i++) {
            GameObject thisBlank = (GameObject)Instantiate(blankLetterPrefab, firstSpot, Quaternion.identity);
            thisBlank.transform.SetParent(blankLetterHolder.transform);
            xSpot += 0.7f;
            firstSpot = new Vector3(xSpot, ySpot, 0);
        }
    }


    // Flip tile underscore
    public void FlipThisTile(int thisSpot, int letterID) {
        // Increment by 1 to avoid the parent element that I don't seem to be able to keep out of the array.
        thisSpot++;
        underscores = blankLetterHolder.GetComponentsInChildren<Transform>();
        Letter foundLetter = letters[letterID];
        underscores[thisSpot].GetComponent<SpriteRenderer>().sprite = foundLetter.letterImage;
        numLettersLeft--;

        // Check for win
        if (numLettersLeft <= 0) {
            StartCoroutine("Win");
        }

    }


    // Add to Hangy
    public void HangTime() {
        misses++;
        switch(misses) {
            case 1:
                hangParts[0].SetActive(true);
                break;
            case 2:
                hangParts[1].SetActive(true);
                break;
            case 3:
                hangParts[2].SetActive(true);
                break;
            case 4:
                hangParts[3].SetActive(true);
                break;
            case 5:
                hangParts[4].SetActive(true);
                break;
            case 6:
                hangParts[5].SetActive(true);
                break;

        }

        if (misses == 6) {
            StartCoroutine("GameOver");
        }

    }


    // Lose
    IEnumerator GameOver() {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Lose");
    }


    // Win
    IEnumerator Win() {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Win");
    }


}
