using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MockupDatabase : MVCDatabase<MessageModel>
{
    public MockupDatabase()
    {
        for (int i = 0; i < 10; i++)
        {
            this.AddData(new MessageModel("Hello World", System.Guid.NewGuid().ToString()));
        }
    }
}
