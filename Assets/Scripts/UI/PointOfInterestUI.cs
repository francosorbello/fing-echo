using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointOfInterestUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI titleText;
    [SerializeField] MessageManager messageManager;
    [SerializeField] InfoManager infoManager;

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

    public void SetInfo(string info)
    {
        infoManager.SetInfo(info);
    }
}
