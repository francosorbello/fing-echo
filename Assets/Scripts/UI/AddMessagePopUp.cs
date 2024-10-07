using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMessagePopUp : MonoBehaviour
{
    [SerializeField] TMPro.TMP_InputField messageInputField;
    [SerializeField] PointOfInterestUI pointOfInterestUI;

    private void Start()
    {
        pointOfInterestUI.onAddMessage += OnAddMessage;
        gameObject.SetActive(false);
    }

    public Action<String> onMessageSend;
    public Action onMessageCancel;

    private void OnAddMessage()
    {
        gameObject.SetActive(true);
    }

    public void OnSend()
    {
        onMessageSend?.Invoke(messageInputField.text);
        messageInputField.text = "";
        this.gameObject.SetActive(false);
    }

    public void OnCancel()
    {
        onMessageCancel?.Invoke();
        this.gameObject.SetActive(false);
    }
}
