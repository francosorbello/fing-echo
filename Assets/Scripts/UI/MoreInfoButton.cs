using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoreInfoButton : MonoBehaviour
{
    [SerializeField] private ImageMatchComponent imageMatchComponent;

    void Start()
    {
        imageMatchComponent.onImageMatched += HandleImageMatched;
        imageMatchComponent.onImageLost += HandleImageLost;
    }

    private void HandleImageMatched(POIData data, Vector3 pos)
    {
        EnableButton();
    }

    private void HandleImageLost()
    {
        DisableButton();
    }

    private void EnableButton()
    {
        GetComponent<Button>().interactable = true;
    }

    private void DisableButton()
    {
        GetComponent<Button>().interactable = false;
    }
}
