using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialMenu : MonoBehaviour
{
    public Transform center;
    public Transform selectObject;

    public GameObject RadialMenuRoot;
    
    bool isRadialMenuActive;

    public Text HighlightedItemName;
    public SonarScript sonar;
    public string[] InventoryItemNames;
    public bool[] isItemActive;
    public GameObject[] images;
    void Start()
    {
        isRadialMenuActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {


            for (int i = 0; i < isItemActive.Length; i++)
            {
                if (isItemActive[i])
                {
                    images[i].SetActive(true);
                }
            }

            isRadialMenuActive = !isRadialMenuActive;
            if (isRadialMenuActive)
            {
                RadialMenuRoot.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                RadialMenuRoot.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            
        }
        if (isRadialMenuActive)
        {
            //formula for
            Vector2 delta = center.position - Input.mousePosition;
            float angle = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;
            angle += 180;

            int currentItem = 0;
            for (int i = 0; i < 360; i += 90)
            {
                if (angle >= i && angle < i + 90)
                {
                    selectObject.eulerAngles = new Vector3(0, 0, i);
                    if (isItemActive[currentItem])
                    {
                        HighlightedItemName.text = InventoryItemNames[currentItem];

                        if (Input.GetMouseButtonDown(0))
                        {
                            sonar.ActivatedSonar(currentItem);
                            isRadialMenuActive = false;
                            RadialMenuRoot.SetActive(false);
                            Cursor.lockState = CursorLockMode.Locked;
                            Cursor.visible = false;
                        }
                    }
                    else
                    {
                        HighlightedItemName.text = "???";
                        if (Input.GetMouseButtonDown(0))
                        {
                            isRadialMenuActive = false;
                            RadialMenuRoot.SetActive(false);
                            Cursor.lockState = CursorLockMode.Locked;
                            Cursor.visible = false;
                        }
                    }


                }
                currentItem++;

            }
        }

    }
}
