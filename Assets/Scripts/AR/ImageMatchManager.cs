using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageMatchManager : MonoBehaviour
{
    [SerializeField] private MockupDatabase mockupDatabase;
    [SerializeField] private ImageMatchComponent imageMatchComponent;
    [SerializeField] private PointOfInterestUI pointOfInterestUI;
    private void Start()
    {
        imageMatchComponent.onImageMatched += OnImageMatch;
    }

    private void OnImageMatch(POIData poiID)
    {
        pointOfInterestUI.SetTitle(poiID.arName);
        pointOfInterestUI.SetInfo(poiID.description);
        List<MockupMessage> messages = mockupDatabase.GetFromPOI(poiID.poiID);
        foreach (var msg in messages)
        {
            pointOfInterestUI.ShowMessage(msg.message);
        }
    }
}
