using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageModel
{
    public string message;
    public string poiID;
    public string ID;   

    public MessageModel(string msg, string poiID)
    {
        this.message = msg;
        this.poiID = poiID;
        this.ID = System.Guid.NewGuid().ToString();
    }
    
}
