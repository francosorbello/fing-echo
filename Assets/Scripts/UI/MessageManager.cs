using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageManager : MonoBehaviour
{
    [SerializeField] MessageElement messageElementPrefab;
    [SerializeField] Transform messageParent;

    private List<MessageElement> messageElements = new List<MessageElement>();

    public void ShowMessage(string message)
    {
        MessageElement messageElement = Instantiate(messageElementPrefab, messageParent);
        messageElement.SetMessage(message);
        messageElements.Add(messageElement);
    }

    public void ClearMessages()
    {
        foreach (MessageElement messageElement in messageElements)
        {
            Destroy(messageElement.gameObject);
        }
        messageElements.Clear();
    }
}
