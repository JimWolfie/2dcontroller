using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Line
{
    public Character character;
    //a refrence to who is speaking
    [TextArea(2,5)]
    public string text;
}

[CreateAssetMenu(fileName = "New Dialog", menuName = "Dialog")]
public class Dialog : ScriptableObject
{
    public Character speakerLeft;
    public Character spreakerRight;
    public Question question;
    public Dialog nextDialog;
    public Line[] lines;
}
