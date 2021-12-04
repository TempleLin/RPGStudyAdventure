using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public class InventorySlot
{
    public Sprite itemImage;
}
public class InventorySystem : MonoBehaviour
{
    [SerializeField]
    private GameObject slotPrefab;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Instantiate(slotPrefab, transform);
        }
    }
}
