using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MVCDatabase<T>
{
    protected List<T> data = new List<T>();

    public List<T> Data
    {
        get
        {
            return data;
        }
    }

    public void AddData(T data)
    {
        this.data.Add(data);
    }

    public void RemoveData(T data)
    {
        this.data.Remove(data);
    }

    public void ClearData()
    {
        this.data.Clear();
    }

    public List<T> GetFromPOI(string poiID)
    {
        List<T> dataToReturn = new List<T>();
        foreach (T item in data)
        {
            if (item.GetType().GetProperty("poiID").GetValue(item).ToString() == poiID)
            {
                dataToReturn.Add(item);
            }
        }
        return dataToReturn;
    }
}
