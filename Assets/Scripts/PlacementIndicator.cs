using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementIndicator : MonoBehaviour
{
    [SerializeField] private ARSessionOrigin arOrigin;
    [SerializeField] private GameObject placementIndicator;
    [SerializeField] private GameObject objectToPlace;
    private Pose placementPose;
    private bool placementValid = false;
    
    void Update()
    {
        UpdatePlacementPose();
        UpdatePlacementIndicator();
    //     if (placementValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
    //     {
    //         PlaceObject();
    //     }
    }

    private void UpdatePlacementIndicator()
    {
        if(placementValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        } else 
        {
            placementIndicator.SetActive(false);
        }
    }

    private void UpdatePlacementPose()
    {

        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>(); 
        arOrigin.GetComponent<ARRaycastManager>().Raycast(screenCenter, hits, TrackableType.AllTypes);
        placementValid = hits.Count > 0;
        if(placementValid)
        {
            placementPose = hits[0].pose;
        }
    }

    public void PlaceObject()
    {
        if (placementValid)
        {
            Instantiate(objectToPlace, placementPose.position, placementPose.rotation);
        }
    }
}
