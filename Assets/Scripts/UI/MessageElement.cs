using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageElement : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI messageText;

    public void SetMessage(string message)
    {
        messageText.text = message;
    }
}
