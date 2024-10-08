using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class POILabel : MonoBehaviour
{
    [SerializeField] private TMP_Text label;

    public void SetText(string text)
    {
        label.text = text;
    }

    public void SetPosition(Vector3 pos)
    {
        transform.position = pos;
    }

    public void LateUpdate()
    {
        transform.LookAt(transform.position + Camera.main.transform.forward);
    }
}
