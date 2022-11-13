using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //ボールが見える可能性のあるz軸の最小値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private Text gameoverText;
    private int score = 0;
    [SerializeField] private Text scoreText;

    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        gameoverText = GameObject.Find("GameOverText").GetComponent<Text>();
    }

    void Update()
    {
        //ボールが画面外に出た場合
        if (transform.position.z < visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            gameoverText.text = "Game Over";
            StartCoroutine(ReLoad());
        }
    }

    private IEnumerator ReLoad()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.CompareTag("SmallStar"))
        {
            score += 10;
            scoreText.text = score.ToString();
        }
        else if (c.gameObject.CompareTag("LargeStar"))
        {
            score += 20;
            scoreText.text = score.ToString();
        }
        else if (c.gameObject.CompareTag("SmallCloud"))
        {
            score += 30;
            scoreText.text = score.ToString();

        }
        else if (c.gameObject.CompareTag("LargeCloud"))
        {
            score += 40;
            scoreText.text = score.ToString();
        }
    }
}
