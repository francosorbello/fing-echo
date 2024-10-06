using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POIView : MonoBehaviour
{
    [SerializeField] ImageMatchComponent imageMatchComponent;

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
        // Show POI on screen
    }
}
