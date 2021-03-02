using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class QuestionEvent: UnityEvent<Question>{ };

public class DDisplay : MonoBehaviour
{
    public Dialog dialog;
    public QuestionEvent questionEvent;
    public GameObject speakerLeft;
    public GameObject speakerRight;

    private DialogAdvancer leftUI;
    private DialogAdvancer rightUI;

    private int index = 0;
    private bool dialogStarted = false;

    public void ChangeDialog(Dialog nextDialog)
    {
        dialogStarted = false;
        dialog = nextDialog;
        AdvanceChat();
    }

    // Start is called before the first frame update
    void Start()
    {
        leftUI = speakerLeft.GetComponent<DialogAdvancer>();
        rightUI = speakerRight.GetComponent<DialogAdvancer>();

        leftUI.Speaker = dialog.speakerLeft;
        rightUI.Speaker = dialog.spreakerRight;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            AdvanceChat();

        }else if(Input.GetKeyDown("x"))
        {
            EndDialog();
        }
    }
    private void EndDialog()
    {
        dialog = null;
        dialogStarted = false;
        leftUI.Hide();
        rightUI.Hide();
        
    }
    private void Initialize()
    {
        dialogStarted = true;
        index = 0;
        leftUI.Speaker = dialog.speakerLeft;
        rightUI.Speaker = dialog.spreakerRight;
    }
    void AdvanceChat()
    {
        if(dialog == null ) return;
        if(!dialogStarted) Initialize();
        if(index < dialog.lines.Length)
        {
            DisplayLine();
            index +=1;
        } else
        {
         NextChat();

        }
    }
    void DisplayLine()
    {
        Line line = dialog.lines[index];
        Character character = line.character;

        if(leftUI.SpeakerIs(character))
        {
            SetLine(leftUI, rightUI, line.text);
        }else
        {
            SetLine(rightUI, leftUI, line.text);
        }
        index+=1;
    }
    void NextChat()
    {
        if(dialog.question != null)
        {
            questionEvent.Invoke(dialog.question);
            
        }else if(dialog.nextDialog!=null){
            ChangeDialog(dialog.nextDialog);

        } else
        {
            EndDialog();
        }
    }
    void SetLine(DialogAdvancer activeUI, DialogAdvancer inactiveUI, string text)
    {
        activeUI._Dialog = text;
        activeUI.Show();
        inactiveUI.Hide();
    }
    
}
