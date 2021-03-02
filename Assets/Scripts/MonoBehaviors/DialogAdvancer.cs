using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogAdvancer : MonoBehaviour
{
    public Image portrait;
    public Text fullName;
    public Text dialog;
    private Character speaker;

    public Character Speaker
    {
        get{return speaker;}
        set 
        {
            speaker = value;
            portrait.sprite = speaker.portriat;
            fullName.text = speaker.fullName;
        }
    }
    public string _Dialog
    {
        set {dialog.text = value;}
    }
    public bool HasSpeaker()
    {
        return speaker !=null;
    }
    public bool SpeakerIs(Character character)
    {
        return speaker == character;
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
 
}
