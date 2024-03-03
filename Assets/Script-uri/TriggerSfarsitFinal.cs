using UnityEngine;

public class TriggerSfarsitFinal : MonoBehaviour
{
    public AudioSource sunetFinal;
    public Animator animator;

    private void OnTriggerEnter()
    {
        if (MainMenu.isHardcore == false)
        {
            if (FindObjectOfType<Ciocnire>().lovit == false && FindObjectOfType<GameManager>().jocTerminat == false)
            {
                FindObjectOfType<Timer>().TimerText.enabled = false;
                FindObjectOfType<Miscare>().vitezaFata = -2150f;
                FindObjectOfType<Miscare>().vitezaParti = 0f;
                FindObjectOfType<GameManager>().CompleteLevel();
                sunetFinal.Play();
                animator.enabled = false;
            }
        }
        else
        {
            if (FindObjectOfType<CiocnireHardcore>().lovit == false && FindObjectOfType<GameManager>().jocTerminat == false)
            {
                FindObjectOfType<Timer>().TimerText.enabled = false;
                FindObjectOfType<Miscare>().vitezaFata = -2150f;
                FindObjectOfType<Miscare>().vitezaParti = 0f;
                FindObjectOfType<GameManager>().CompleteGameHardcore();
                sunetFinal.Play();
                animator.enabled = false;
            }
        }
    }
}
