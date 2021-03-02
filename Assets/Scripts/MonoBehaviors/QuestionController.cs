using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionController : MonoBehaviour
{
    public Question question;
    public Text questionText;
    public Button choiceButton;

    private List<ChoiceController> choiceControllers = new List<ChoiceController>();

    public void Change(Question _question)
    {
        RemoveChoices();
        question = _question;
        gameObject.SetActive(true);
        Initialize();
    }
    
    public void Hide(Dialog chat)
    {
        RemoveChoices();
        gameObject.SetActive(false);
    }
    private void RemoveChoices()
    {
        foreach(ChoiceController c in choiceControllers)
        {
            Destroy(c.gameObject);
            choiceControllers.Clear();
        }
    }
    private void Initialize()
    {
        questionText.text = question.text;
        for(int jndex = 0; jndex < question.choices.Length; jndex++)
        {
            ChoiceController c = ChoiceController.AddChoicebutton(choiceButton, question.choices[jndex], jndex );
            choiceControllers.Add(c);

        }
        choiceButton.gameObject.SetActive(false);
    }

}
