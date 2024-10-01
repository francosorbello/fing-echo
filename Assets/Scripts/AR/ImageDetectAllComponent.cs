using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;

public class ImageDetectAllComponent : MonoBehaviour
{
    [SerializeField] private ARTrackedImageManager aRTrackedImageManager;

    public UnityEvent<List<ARTrackedImage>> onImageDetected;
    public UnityEvent<List<ARTrackedImage>> onImageLost;

    void OnEnable()
    {
        aRTrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        aRTrackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    /// <summary>
    /// Indica si una imagen esta dentro de la vista de la camara
    /// </summary>
    private bool IsInCameraView(ARTrackedImage image)
    {
        var cam = Camera.main;
        Vector3 viewPos = cam.WorldToViewportPoint(image.transform.position);
        return viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0;
    }

    /// <summary>
    /// Retorna una lista de imagenes para un estado del tracker.
    /// </summary>
    private List<ARTrackedImage> GetImagesInArg(List<ARTrackedImage> arg)
    {
        List<ARTrackedImage> collectedImages = new List<ARTrackedImage>();
        foreach (var item in arg)
        {
            if(IsInCameraView(item))
                collectedImages.Add(item);
        }
        return collectedImages;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        LogTrackedImages(eventArgs);

        List<ARTrackedImage> collectedImages = new List<ARTrackedImage>();
        collectedImages.AddRange(GetImagesInArg(eventArgs.added));
        collectedImages.AddRange(GetImagesInArg(eventArgs.updated));
        
        List<ARTrackedImage> lostImages = new List<ARTrackedImage>();
        lostImages.AddRange(GetImagesInArg(eventArgs.removed));

        if(collectedImages.Count > 0)
        {
            onImageDetected?.Invoke(collectedImages);
        }

        if (lostImages.Count > 0)
        {
            onImageLost?.Invoke(lostImages);
        }
    }

    private void LogTrackedImages(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var item in eventArgs.added)
        {
            Debug.Log("Added: " + item.referenceImage.name);   
        }
        foreach (var item in eventArgs.updated)
        {
            Debug.Log("Updated: " + item.referenceImage.name + " "+item.trackingState);
        }
        foreach (var item in eventArgs.removed)
        {
            Debug.Log("Removed: " + item.referenceImage.name);  
        }
    }
}
