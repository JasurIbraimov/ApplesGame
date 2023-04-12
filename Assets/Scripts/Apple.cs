using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    GameManager gm; 
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();   

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < gm.BottomLeft.y)
        {
            gm.Lives--;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.name.Equals("Cart"))
        {
            gm.Score++;
            Destroy(gameObject);
        }

    }
}
