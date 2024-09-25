using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public struct ListItemData
{
    public string label;
    public UnityAction onClick;
}

public class ListItemUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI label;
    [SerializeField] private Button button;

    public void SetItem(ListItemData data)
    {
        label.text = data.label;
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => data.onClick());
        gameObject.SetActive(true);

    }
}
