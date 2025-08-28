using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoTypes : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject Ammotypepanel;
    public List<Button> ammoButtons;
    public Image selectedAmmoImage;

    [Header("Ammo Sprites")]
    public List<Sprite> ammoSprites;

    private int selectedAmmoIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        // Assign button listeners
        for (int i = 0; i < ammoButtons.Count; i++)
        {
            int index = i;
            ammoButtons[i].onClick.AddListener(() => SelectAmmo(index));
        }
    }

    // Update is called once per frame
    public void SelectAmmo(int index)
    {
        if (index >= 0 && index < ammoSprites.Count)
        {
            selectedAmmoIndex = index;
            UpdateSelectedAmmoUi();
            Debug.Log($"Selected ammo type; {index}");
            // TODO; Inform other systems about amm change if needed
        }
    }

    private void UpdateSelectedAmmoUi()
    {
        if (selectedAmmoImage != null && selectedAmmoIndex >= 0 && selectedAmmoIndex < ammoSprites.Count)
        {

        }
    }

    public int GetSelectedAmmoIndex()
    {
        return selectedAmmoIndex;
    }
}