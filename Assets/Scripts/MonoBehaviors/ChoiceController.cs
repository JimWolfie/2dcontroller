using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class DialogChangeEvent : UnityEvent<Dialog>{ }

public class ChoiceController : MonoBehaviour
{
    public Choice choice;
    public DialogChangeEvent dialogChangeEvent;

    public static ChoiceController AddChoicebutton(Button choiceButtonTemplate, Choice choice, int index)
    {
        int buttonSpacing = -44;
        Button button = Instantiate(choiceButtonTemplate);
        button.transform.localScale = Vector3.one;
        button.transform.localPosition = new Vector3(0, index* buttonSpacing, 0);
        button.name = "Choice " + (index +1);
        button.gameObject.SetActive(true);

        ChoiceController choiceController = button.GetComponent<ChoiceController>();
        choiceController.choice = choice;
        return choiceController;
    }

    private void Start()
    {
        if (dialogChangeEvent == null)
        {
            dialogChangeEvent = new DialogChangeEvent();
        }
        GetComponent<Button>().GetComponentInChildren<Text>().text = choice.text;
    }
    public void MakeChoice()
    {
        dialogChangeEvent.Invoke(choice.dialog);
    }

}
