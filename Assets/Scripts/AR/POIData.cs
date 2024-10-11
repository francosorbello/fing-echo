using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "POIData", menuName = "POI/POIData", order = 1)]
public class POIData : ScriptableObject 
{
    [SerializeField] public string arName;
    [SerializeField] public string poiID = System.Guid.NewGuid().ToString();
    [SerializeField,Multiline] public string description;
    [SerializeField,Multiline] public string notableFacts;
    [SerializeField] public string mapLink;

    [SerializeField] public Texture2D imageTex;
    
}
