using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationButton : MonoBehaviour
{
    [SerializeField] private POIData poiData;

    public void OnClick()
    {
        var ui = FindObjectOfType<PointOfInterestUI>(true);

        ui.SetTitle(poiData.arName);
        ui.SetInfo(poiData.description);
        ui.SetHyperLink(poiData.mapLink);
        ui.SetImage(poiData.imageTex);
        ui.Show();
    }
}
