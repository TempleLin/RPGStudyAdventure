using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class MonsterSelectionWidget : MonoBehaviour
{
    [SerializeField]
    private Camera camera = null;
    private BoxCollider2D _boxCollider2D;

    private bool onScaled = false;

    private static GameObject lastOnHoverWidget = null;

    private static float onScaleRange = .15f;
    // Start is called before the first frame update
    void Start()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkOnHover()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        lastOnHoverWidget = hit ? hit.transform.gameObject : null;

        if (lastOnHoverWidget == gameObject)
        {
            if (!onScaled)
            {
                var tempScale = transform.localScale;
                transform.localScale = new Vector3(tempScale.x + onScaleRange, tempScale.y + onScaleRange, tempScale.z);
                onScaled = true;
                Debug.Log("OnHover " + gameObject.name);
            }
        }
        else
        {
            if (onScaled)
            {
                var tempScale = transform.localScale;
                transform.localScale = new Vector3(tempScale.x - onScaleRange, tempScale.y - onScaleRange, tempScale.z);
                onScaled = false;
            }
        }
    }

    public void checkOnClick()
    {
        if (onScaled)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("OnClick " + gameObject.name);
            }
        }
    }
}
