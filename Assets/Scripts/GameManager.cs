using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    Vector2 bottomLeft, topRight;
    [SerializeField] GameObject applePrefab;
    [SerializeField] TMP_Text scoreText, livesText ;
    int progression = 0, lives = 3, score = 0;

    public Vector2 TopRight { get { return topRight; }  }
    public Vector2 BottomLeft { get { return bottomLeft; } }

    public int Progression { get { return progression; } set { progression = value;  } }
    public int Lives 
    { 
        get { return lives; } 
        set 
        { 
            lives = value; 
            livesText.text = $"∆изни: {lives}"; 
            if (lives < 1) Time.timeScale = 0; 
        }
    }

    public int Score
    {
        get { return score; }
        set 
        {
            score = value;
            scoreText.text = $"—чет: {score}";
            if(score % 10 == 0 && progression < 5)
            {
                progression++;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        bottomLeft = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        topRight = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        InvokeRepeating(nameof(CreateApple), 2f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void CreateApple()
    {
        GameObject apple = Instantiate(applePrefab);
        Vector2 position = new Vector2(Random.Range(bottomLeft.x, topRight.x), topRight.y);
        apple.transform.position = position;
    }
}
