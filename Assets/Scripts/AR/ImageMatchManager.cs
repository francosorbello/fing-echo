using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageMatchManager : MonoBehaviour
{
    [SerializeField] private MockupDatabase mockupDatabase;
    [SerializeField] private ImageMatchComponent imageMatchComponent;
    [SerializeField] private PointOfInterestUI pointOfInterestUI;
    [SerializeField] private AddMessagePopUp addMessagePopUp;
    [SerializeField] private POILabel poiLabel;

    private POIData currentPOI;

    private void Start()
    {
        imageMatchComponent.onImageMatched += OnImageMatch;
        addMessagePopUp.onMessageSend += OnMessageSend;
        pointOfInterestUI.onClose += OnClose;
    }

    private void OnClose()
    {
        currentPOI = null;
        pointOfInterestUI.ClearMessages();
        imageMatchComponent.ToggleScan(true);
    }

    private void OnMessageSend(string message)
    {
        if (currentPOI == null)
            return;
        mockupDatabase.AddMessage(currentPOI.poiID, new MockupMessage { message = message, poiID = currentPOI.poiID });
        pointOfInterestUI.ShowMessage(message);
    }

    private void OnImageMatch(POIData poiID, Vector3 position)
    {
        // pointOfInterestUI.gameObject.SetActive(true);
        
        var poilblInstance = Instantiate(poiLabel, position, Quaternion.identity);
        poilblInstance.SetText(poiID.arName);

        pointOfInterestUI.SetTitle(poiID.arName);
        pointOfInterestUI.SetInfo(poiID.description);
        List<MockupMessage> messages = mockupDatabase.GetFromPOI(poiID.poiID);
        foreach (var msg in messages)
        {
            pointOfInterestUI.ShowMessage(msg.message);
        }
        currentPOI = poiID;
        imageMatchComponent.ToggleScan(false);
    }


}
