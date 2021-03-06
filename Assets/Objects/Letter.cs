﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Letter", menuName = "New Letter")]
public class Letter : ScriptableObject {

    public int letterID;
    public char letter;
    public Sprite letterImage;
}
