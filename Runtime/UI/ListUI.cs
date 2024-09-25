using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ListUI : MonoBehaviour
{
    [SerializeField] private Transform itemAnchor;
    [SerializeField] private ListItemUI itemPrefab;

    private List<ListItemUI> items = new List<ListItemUI>();

    private void Awake()
    {
        itemAnchor.GetComponentsInChildren(includeInactive: true, items);

        foreach (var item in items)
        {
            item.gameObject.SetActive(false);
        }
    }

    public void SetItems(List<ListItemData> lobbies)
    {
        int existingCount = items.Count;
        int requiredCount = lobbies.Count;

        // Instantiate only if needed
        if (existingCount < requiredCount)
        {
            for (int i = existingCount; i < requiredCount; i++)
            {
                var item = Instantiate(itemPrefab, itemAnchor);
                items.Add(item);
            }
        }

        // Update active items and hide the rest
        for (int i = 0; i < items.Count; i++)
        {
            if (i < requiredCount)
            {
                items[i].SetItem(lobbies[i]); // Update lobby data
            }
            else
            {
                items[i].gameObject.SetActive(false);
            }
        }
    }
}
