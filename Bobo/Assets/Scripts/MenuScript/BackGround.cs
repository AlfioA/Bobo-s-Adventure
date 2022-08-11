using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer = default;
    [SerializeField] private float scrollSpeed = 0.5f;
    void Start()
    {

    }

    void Update()
    {
        float offset = Time.time * scrollSpeed;
        spriteRenderer.material.mainTextureOffset = new Vector2(offset, 0f);
    }
}
