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
    public Action onImageLost;
    private bool doScan = true;
    private ARTrackedImage previousImage;

    void OnEnable()
    {
        aRTrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        aRTrackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    public void ToggleScan(bool value)
    {
        doScan = value;
    }

    private bool IsInCameraView(ARTrackedImage image)
    {
        var cam = Camera.main;
        if (cam != null)
        {
            Debug.Log(image.transform.position);
            if (image == null)
            {
                Debug.Log("Image is null");
                return false;
            }
            Vector3 viewPos = cam.WorldToViewportPoint(image.transform.position);
            return viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0;
        }
        Debug.Log("No main camera available");
        return false;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        if (!doScan)
            return;
            
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
            if (updated.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Tracking && IsInCameraView(updated))
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
                        if (previousImage != null && previousImage == trackedImage)
                            continue;
                        previousImage = trackedImage;
                        onImageMatched?.Invoke(poiData,trackedImage.transform.position);
                    }
                }
            }
        }
        if (previousImage != null)
        { 
            var prevInCameraView = IsInCameraView(previousImage);
            if (!prevInCameraView)
            {
                onImageLost?.Invoke();
                previousImage = null;
            }
        }
    }
}
