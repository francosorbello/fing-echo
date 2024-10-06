using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MockupMessage : ScriptableObject
{
    public string message;
    public string poiID;

    public string GetMessage()
    {
        return message;
    }
    
    public string GetPOIID()
    {
        return poiID;
    } 
    
}
