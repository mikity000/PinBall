using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //�{�[����������\���̂���z���̍ŏ��l
    private float visiblePosZ = -6.5f;

    //�Q�[���I�[�o��\������e�L�X�g
    private Text gameoverText;
    private int score = 0;
    [SerializeField] private Text scoreText;

    void Start()
    {
        //�V�[������GameOverText�I�u�W�F�N�g���擾
        gameoverText = GameObject.Find("GameOverText").GetComponent<Text>();
    }

    void Update()
    {
        //�{�[������ʊO�ɏo���ꍇ
        if (transform.position.z < visiblePosZ)
        {
            //GameoverText�ɃQ�[���I�[�o��\��
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
