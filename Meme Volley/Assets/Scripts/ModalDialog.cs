using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System;

public class ModalDialog : MonoBehaviour {
    public static ModalDialog Instance;

    public Text question;
    public Button button1;
    public Button button2;
    public GameObject panelGameObject;

    public void Choice(string question, string button1Text, string button2Text, UnityAction action1, UnityAction action2)
    {
        panelGameObject.SetActive(true);

        button1.GetComponentInChildren<Text>().text = button1Text;
        button2.GetComponentInChildren<Text>().text = button2Text;
        button1.onClick.RemoveAllListeners();
        button2.onClick.RemoveAllListeners();
        button1.onClick.AddListener(action1);
        button2.onClick.AddListener(action2);
        button1.onClick.AddListener(ClosePanel);
        button2.onClick.AddListener(ClosePanel);
        button1.gameObject.SetActive(true);
        button2.gameObject.SetActive(true);

        this.question.text = question;
    }

    private void ClosePanel()
    {
        panelGameObject.SetActive(false);
    }

    private void Start()
    {
        Instance = this;
        panelGameObject.SetActive(false);
    }
}
