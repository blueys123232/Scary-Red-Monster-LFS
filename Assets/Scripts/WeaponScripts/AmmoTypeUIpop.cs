using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoTypeUIpop : MonoBehaviour
{
    public GameObject ammoTypeUI;

    private bool isUIVisible;
    // Start is called before the first frame update
    void Start()
    {
        if (ammoTypeUI != null)
            ammoTypeUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            ToggleUI();
        }
    }
    public void ShowUI()
    {
        if (ammoTypeUI != null)
        {
            ammoTypeUI.SetActive(true);
            isUIVisible = true;
        }
    }

    public void HideUI()
    {
        if (ammoTypeUI != null)
        {
            isUIVisible = !isUIVisible;
            ammoTypeUI.SetActive(isUIVisible);
        }
    }
    public void ToggleUI()
    {
        if (ammoTypeUI != null)
        {
            isUIVisible = !isUIVisible;
            ammoTypeUI.SetActive(isUIVisible);
        }
    }
    public bool IsVisible()
    {
        return isUIVisible;
    }
}