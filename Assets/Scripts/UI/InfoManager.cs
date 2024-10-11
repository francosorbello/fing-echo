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

    public void ClearInfo()
    {
        infoText.text = "";
    }

    public void SetHyperLink(string link)
    {
        GetComponentInChildren<HyperLinkButton>().SetHyperLink(link);
    }

    public void SetImage(Texture2D imageTex)
    {
        GetComponentInChildren<RawImageToSpriteComponent>().SetImage(imageTex);
    }
}
