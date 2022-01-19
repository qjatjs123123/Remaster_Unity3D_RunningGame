using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnterFinalRound : MonoBehaviour
{
    public Image Panel;
    public GameObject Player;
    public GameObject Camera;
    public GameObject fadeOutCanvas;
    public Animator animator;
    float time = 0f;
    float F_time = 2f;

    public void Fade()
    {
        StartCoroutine(FadeFlow());
    }

    IEnumerator FadeFlow()
    {
        Panel.gameObject.SetActive(true);
        Color alpha = Panel.color;
        while(alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }
        Player.SetActive(false);
        SceneManager.LoadScene("Round3");
        yield return null;
    }
    private void OnTriggerEnter(Collider other)
    {
        fadeOutCanvas.SetActive(true);
        Player.GetComponent<BasicBehaviour>().enabled = false;
        Camera.GetComponent<ThirdPersonOrbitCamBasic>().enabled = false;
        Player.GetComponent<MoveBehaviour>().enabled = false;
        
        //animator.Play("Idle", -1, 0);

        Fade();
        
        
        
    }
}
