using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUI : MonoBehaviour
{

    public GameObject ShopUI;
    public GameObject UpgradeUI;
    
    private Collider2D coll;
    public string Type;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EnableUI(Type);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DisableUI(Type);
        }
    }

    void EnableUI(string type)
    {
        
        if (type == "Shop")
        {
            ShopUI.SetActive(true);
        }
        else if (type == "Upgrade")
        {
            UpgradeUI.SetActive(true);
        }
    }
    void DisableUI(string type)
    {
        if (type == "Shop")
        {
            ShopUI.SetActive(false);
        }
        else if (type == "Upgrade")
        {
            UpgradeUI.SetActive(false);
        }
    }
}
