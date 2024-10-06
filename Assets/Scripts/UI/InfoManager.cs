using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI infoText;

    public void SetInfo(string info)
    {
        infoText.text = info;
    }
}
