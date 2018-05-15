using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wordpicker : MonoBehaviour {

    public int maxLetters = 15;
    public Letter[] letters;
    public GameObject letterPrefab;

    Quaternion letterRotation;
    public static int lettersLeft;
    float letterSpotX;
    float letterSpotY;
    Vector3 letterSpot;

    public Text lettersCounter;

    void Start() {
        WordController.theWord = null;
        lettersLeft = maxLetters;
        InitLetters();
    }

    // Setup the letters
    void InitLetters() {

        lettersCounter.text = maxLetters.ToString();
        lettersLeft = maxLetters;

        // Init vector3
        letterSpot = new Vector3(-5.5f, 3.9f, 0);

        int lSpot = 0;
        for (int i = 0; i < letters.Length; i++) {
            lSpot++;
            // Create the letter tile
            GameObject thisLetter = (GameObject)Instantiate(letterPrefab, letterSpot, letterRotation);

            // Setup next spot for next tile
            letterSpotX = thisLetter.transform.position.x + 1.2f;

            // Advance Y if we reset X if over a certain value
            if (lSpot > 5) {
                letterSpotY = thisLetter.transform.position.y - 1.4f;
                letterSpotX = -5.5f;
                lSpot = 0;
            } else {
                letterSpotY = thisLetter.transform.position.y;
            }


            letterSpot = new Vector3(letterSpotX, letterSpotY, 0);

            // Send over the object
            thisLetter.GetComponent<WordTileController>().letterData = letters[i];

        }
    }


    void Update() {
        lettersCounter.text = lettersLeft.ToString();
    }
}
