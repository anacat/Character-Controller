using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Dialogue
{
    public string characterName;

    [Multiline]
    public List<string> dialogue;
}
