using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilitiesSharedData : MonoBehaviour
{
    [SerializeField]
    private GameObject mainCharObject;

    public GameObject MainCharObject => mainCharObject;
    [SerializeField] private SpriteRenderer backgroundSpriteRenderer;
    public SpriteRenderer BackgroundSpriteRenderer => backgroundSpriteRenderer;
}
