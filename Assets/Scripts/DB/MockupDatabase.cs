using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MockupDatabase", menuName = "ScriptableObjects/MockupDatabase", order = 1)]
public class MockupDatabase : ScriptableObject
{
    public List<MockupImageEntry> imageEntries;

    public List<MockupMessage> GetFromPOI(string poiID)
    {
        List<MockupMessage> messages = new List<MockupMessage>();
        foreach (MockupImageEntry entry in imageEntries)
        {
            if (entry.poiID == poiID && entry.messages != null)
            {
                messages.AddRange(entry.messages);
            }
        }
        return messages;
    }

    public void AddMessage(string poiID, MockupMessage message)
    {
        foreach (MockupImageEntry entry in imageEntries)
        {
            if (entry.poiID == poiID)
            {
                if (entry.messages == null)
                {
                    entry.messages = new List<MockupMessage>();
                }
                entry.messages.Add(message);
            }
        }
    }
}
