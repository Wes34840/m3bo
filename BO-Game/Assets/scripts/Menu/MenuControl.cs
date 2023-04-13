using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControl : MonoBehaviour
{
    public GameObject InitialMenu;
    public GameObject ModeSelect;

    public void ProgressMenu()
    {
        InitialMenu.SetActive(false);
        ModeSelect.SetActive(true);
    }
    public void GoBack()
    {
        InitialMenu.SetActive(true);
        ModeSelect.SetActive(false);
    }


}
