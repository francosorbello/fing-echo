using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;
    public List<GameObject> objectsToSwap;

    [SerializeField] private Color idleColor;
    [SerializeField] private Color hoverColor;
    [SerializeField] private Color activeColor;
    
    private TabButton selectedTab;
    private int index;
    public void Suscribe(TabButton button)
    {
        if (tabButtons == null)
        {
            tabButtons = new List<TabButton>();
        }
        
        tabButtons.Add(button);
    }

    public void OnTabEnter(TabButton button)
    {
        ResetTabs();
        if (selectedTab == null || button != selectedTab)
        {
            button.tabImage.color = hoverColor;
        }
    }

    public void OnTabExit(TabButton button)
    {
        ResetTabs();
        if (button != selectedTab)
            button.tabImage.color = idleColor;
    }

    public void OnTabSelected(TabButton button)
    {
        selectedTab = button;
        ResetTabs();
        button.tabImage.color = activeColor;
        index = button.transform.GetSiblingIndex();
        for (int i = 0; i < objectsToSwap.Count; i++)
        {
            objectsToSwap[i].SetActive(i == index);
        }   
    }

    public void ResetTabs()
    {
        foreach (TabButton button in tabButtons)
        {
            if (selectedTab != null && button == selectedTab) continue;
            button.tabImage.color = idleColor;
        }
    }
}
