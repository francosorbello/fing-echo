using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ImageMatchComponent : MonoBehaviour
{
    [SerializeField] private ARTrackedImageManager aRTrackedImageManager; 
    [SerializeField] private List<POIData> poiDataList;

    public Action<POIData, Vector3> onImageMatched;

    void OnEnable()
    {
        aRTrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        aRTrackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private bool IsInCameraView(ARTrackedImage image)
    {
        var cam = Camera.main;
        Vector3 viewPos = cam.WorldToViewportPoint(image.transform.position);
        return viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        List<ARTrackedImage> collectedImages = new List<ARTrackedImage>();
        foreach (var added in eventArgs.added)
        {
            if (IsInCameraView(added))
            {
                collectedImages.Add(added);
            }   
        }
        foreach (var updated in eventArgs.updated)
        {
            if (IsInCameraView(updated) && updated.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Tracking)
            {
                collectedImages.Add(updated);
            }
        }

        if (collectedImages.Count > 0)
        {
            foreach (var poiData in poiDataList)
            {
                foreach (var trackedImage in collectedImages)
                {
                    if (trackedImage.referenceImage.name == poiData.arName)
                    {
                        onImageMatched?.Invoke(poiData, trackedImage.transform.position);
                    }
                }
            }
        }
    }
}
