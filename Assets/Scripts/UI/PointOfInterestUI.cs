using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class PointOfInterestUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI titleText;
    [SerializeField] MessageManager messageManager;
    [SerializeField] InfoManager infoManager;

    public Action onAddMessage;
    public Action onClose;

    public void SetTitle(string title)
    {
        titleText.text = title;
    }

    public void ShowMessage(string message)
    {
        messageManager.ShowMessage(message);
    }

    public void ClearMessages()
    {
        messageManager.ClearMessages();
    }

    public void ClearInfo()
    {
        infoManager.ClearInfo();
    }	

    public void SetInfo(string info)
    {
        infoManager.SetInfo(info);
    }

    public void OnAddMessage()
    {
        onAddMessage?.Invoke();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        ClearMessages();
        // gameObject.SetActive(false);
        onClose?.Invoke();
    }
}
