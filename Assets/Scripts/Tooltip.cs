using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tooltip : MonoBehaviour
{
    private TMP_Text tooltipText;

    // Start is called before the first frame update
    void Start()
    {
        tooltipText = GetComponentInChildren<TMP_Text>();
        gameObject.SetActive(false);   
    }

    public void GenerateTooltip(Item item)
    {
        string statText = "";
        foreach (var stat in item.stats)
        {
            statText += "\n" + stat.Key.ToString() + ": " + stat.Value ;
        }

        string tooltip = string.Format("<b>{0}</b>\n{1}\n{2}", item.title, item.description, statText);
        tooltipText.text = tooltip;
        gameObject.SetActive(true);
    }
}
