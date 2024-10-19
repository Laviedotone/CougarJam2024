using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialog Node", menuName = "Dialog/Node")]
public class DialogNode : ScriptableObject
{
    [TextArea(3, 5)]
    public string dialogText;  // The dialog text to display

    public DialogNode nextNode;  // Reference to the next node (for linear dialog)
    public DialogNode[] options;  // For branching dialog options

    public bool HasOptions()
    {
        return options != null && options.Length > 0;
    }
}
