using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperLinkButton : MonoBehaviour
{
    private string hyperLink;
    public void SetHyperLink(string link)
    {
        this.hyperLink = link;
    }

    public void Click()
    {
        if (hyperLink != String.Empty)
        {
            Application.OpenURL(hyperLink);
        }
    }


}
