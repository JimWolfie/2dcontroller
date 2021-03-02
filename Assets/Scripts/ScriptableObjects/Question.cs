using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Choice
{

    //a refrence to who is speaking
    [TextArea(2, 5)]
    public string text;
    public Dialog dialog;
}
[CreateAssetMenu(fileName = "New Question", menuName = "Question")]
public class Question : ScriptableObject
{   
        [TextArea(2, 5)]
        public string text;
        public Choice[] choices;
    
}
