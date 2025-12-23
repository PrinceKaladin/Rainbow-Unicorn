using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CupController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float xLimit = 2.5f;
    public Text scoretext;
    float targetX;

    void Start()
    {
        PlayerPrefs.SetInt("score", 0);
        targetX = transform.position.x;
    }
    void Update()
    {

    if (Input.touchCount > 0)
    {
        Touch t = Input.GetTouch(0);
        if (t.position.x > Screen.width / 2)
            targetX += moveSpeed * Time.deltaTime;
        else
            targetX -= moveSpeed * Time.deltaTime;
    }


        targetX = Mathf.Clamp(targetX, -xLimit, xLimit);

        transform.position = Vector3.Lerp(
            transform.position,
            new Vector3(targetX, transform.position.y, 0),
            Time.deltaTime * 10f
        );
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "nam")
        {
            Destroy(other.gameObject);
            int score = PlayerPrefs.GetInt("score", 0) + 1;
            PlayerPrefs.SetInt("score", score);
            int level = PlayerPrefs.GetInt("level");
            scoretext.text = score.ToString();
            if (level == 1) {
                if (score == 30) {
                    PlayerPrefs.SetInt("level", 2);
                    PlayerPrefs.SetString("winlose", "win");
                    SceneManager.LoadScene(2);
                }
            }
            if (level == 2)
            {
                if (score == 70)
                {
                    PlayerPrefs.SetInt("level", 3);
                    PlayerPrefs.SetString("winlose", "win");
                    SceneManager.LoadScene(2);
                }
            }
        }
        else if(other.gameObject.tag == "bomba") {
            PlayerPrefs.SetString("winlose", "lose");
            SceneManager.LoadScene(2);
         }


    }
}
