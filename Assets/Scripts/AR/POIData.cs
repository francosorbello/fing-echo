using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "POIData", menuName = "POI/POIData", order = 1)]
public class POIData : ScriptableObject 
{
    [SerializeField] public string arName;
    [SerializeField] public string poiID = System.Guid.NewGuid().ToString();
}
