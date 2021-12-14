using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabInList : MonoBehaviour
{
    private Button button;
    [SerializeField]
    private List<GameObject> otherLists;
    [SerializeField]
    private GameObject holdingList;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(delegate {
            otherLists.ForEach(x => x.SetActive(false));
            holdingList.SetActive(true);
        });
    }
}
