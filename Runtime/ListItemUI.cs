using GURU;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GURU
{
    /// <summary>
    /// Represents data for a list item, including a label and a click action.
    /// </summary>
    public class ListItemData
    {
        /// <summary>
        /// The label displayed for the list item.
        /// </summary>
        public string label;

        /// <summary>
        /// The action to be executed when the list item is clicked.
        /// </summary>
        public UnityAction onClick;
    }

    /// <summary>
    /// Manages the UI representation of a list item, allowing the display of a label and a click action.
    /// </summary>
    public class ListItemUI : MonoBehaviour
    {
        /// <summary>
        /// The UI element displaying the item's label.
        /// </summary>
        [SerializeField, Tooltip("The TextMeshPro component that displays the item label.")]
        private TextMeshProUGUI label;

        /// <summary>
        /// The button that triggers the item's action.
        /// </summary>
        [SerializeField, Tooltip("The Button component that executes the item's click action.")]
        private Button button;

        /// <summary>
        /// Sets the data for the list item UI.
        /// </summary>
        /// <param name="data">The data to display in the list item, including the label and click action.</param>
        public virtual void SetData(ListItemData data)
        {
            label.text = data.label;
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => data.onClick());
            gameObject.SetActive(true);
        }
    }
}

public abstract class ListItemUI<T> : MonoBehaviour where T : ListItemData
{
    public override sealed void SetData(ListItemData data)
    {
        ApplyData(data as T);
    }

    protected abstract void ApplyData();
}