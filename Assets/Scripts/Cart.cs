using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] Sprite[] sprites;
    GameManager gm;
    SpriteRenderer spriteRenderer;
    float halfOfWidth; 
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        halfOfWidth = GetComponent<BoxCollider2D>().size.x / 2; 
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        horizontal = Mathf.Clamp(transform.position.x + horizontal, gm.BottomLeft.x + halfOfWidth, gm.TopRight.x - halfOfWidth);
        transform.position = new Vector2(horizontal, transform.position.y);
        spriteRenderer.sprite = sprites[gm.Progression];
    }
}
