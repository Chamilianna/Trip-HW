using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject[] inventoryIcons;

    void OnTriggerEnter(Collider collision)
    {
        foreach(Transform child in inventoryPanel.transform)
        {
            if(child.gameObject.tag == collision.gameObject.tag)
            {
                string c = child.Find("Text").GetComponent<TMPro.TextMeshProUGUI>().text;
                int tcount = System.Int32.Parse(c) + 1;
                child.Find("Text").GetComponent<TMPro.TextMeshProUGUI>().text = "" + tcount;
                return;
            }
        }

        GameObject i;
        if(collision.gameObject.tag == "PinkShroom")
        {
            i = Instantiate(inventoryIcons[0]);
            i.transform.SetParent(inventoryPanel.transform);
        }
        else if(collision.gameObject.tag == "BlueShroom")
        {
            i = Instantiate(inventoryIcons[1]);
            i.transform.SetParent(inventoryPanel.transform);
        }
        else if(collision.gameObject.tag == "YellowShroom")
        {
            i = Instantiate(inventoryIcons[2]);
            i.transform.SetParent(inventoryPanel.transform);
        }
        // else if(collision.gameObject.tag == "YellowItem")
        // {
        //     i = Instantiate(inventoryIcons[3]);
        //     i.transform.SetParent(inventoryPanel.transform);
        // }
    }

    
}
