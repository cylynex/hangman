using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wordpicker : MonoBehaviour {

    public int maxLetters = 15;
    public Letter[] letters;
    public GameObject letterPrefab;

    Quaternion letterRotation;
    int lettersLeft;
    float letterSpotX;
    float letterSpotY;
    Vector3 letterSpot;
    int zRot;

    // Setup the letters
    void InitLetters() {

        lettersLeft = maxLetters;

        // Init vector3
        letterSpot = new Vector3(-6, 3.7f, 0);

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
}
