using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class MonsterSelectionWidget : MonoBehaviour {
    [SerializeField]
    private Camera camera = null;
    private BoxCollider2D _boxCollider2D;
    [SerializeField] private GameObject monsterObject;
    public GameObject MonsterObject => monsterObject;

    private bool onScaled = false;

    private static GameObject lastOnHoverWidget = null;

    private static float onScaleRange = .15f;
    // Start is called before the first frame update
    void Start() {
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    public bool checkOnHover(RaycastHit2D hit) {
        lastOnHoverWidget = hit ? hit.transform.gameObject : null;

        if (lastOnHoverWidget == gameObject) {
            if (!onScaled) {
                var tempScale = transform.localScale;
                transform.localScale = new Vector3(tempScale.x + onScaleRange, tempScale.y + onScaleRange, tempScale.z);
                onScaled = true;
                Debug.Log("OnHover " + gameObject.name);
            }

            return true;
        } else {
            if (onScaled) {
                var tempScale = transform.localScale;
                transform.localScale = new Vector3(tempScale.x - onScaleRange, tempScale.y - onScaleRange, tempScale.z);
                onScaled = false;
            }

            return false;
        }
    }

    public bool checkOnClick() {
        if (onScaled) {
            if (Input.GetMouseButtonDown(0)) {
                Debug.Log("OnClick " + gameObject.name);
                return true;
            }
        }

        return false;
    }
}
