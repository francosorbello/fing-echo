using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ImageLogger : MonoBehaviour
{
    [SerializeField] TextMeshPro text;
    public void LogImages(List<string> images)
    {
        foreach (var item in images)
        {
            Debug.Log(item);
            text.text = item;
        }
    }
}
