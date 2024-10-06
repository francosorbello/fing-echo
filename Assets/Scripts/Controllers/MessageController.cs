using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageController : MVCController 
{
    private MVCDatabase<MessageModel> database;
    public MessageController()
    {
        database = new MockupDatabase();
    }

    public List<MessageModel> GetMessagesForPOI(string poiID)
    {
        return database.GetFromPOI(poiID);
    }
}
