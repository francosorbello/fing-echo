using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageView : MonoBehaviour
{
    [SerializeField] ImageMatchComponent imageMatchComponent;

    private MessageController messageController;

    void Start()
    {
        messageController = new MessageController();
    }

    void OnEnable()
    {
        imageMatchComponent.onImageMatched += OnImageMatched;
    }

    void OnDisable()
    {
        imageMatchComponent.onImageMatched -= OnImageMatched;
    }

    private void OnImageMatched(POIData poiData, Vector3 position)
    {
        
    }   
}
