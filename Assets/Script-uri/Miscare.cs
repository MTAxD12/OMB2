using UnityEngine;

public class Miscare : MonoBehaviour
{

    public Rigidbody rb;

    public float vitezaFata = 2000f;
    public float vitezaParti = 1000f;

    Vector3 miscare;

    public AudioSource sunetCazut;
    private bool sunetCaz = true;
    public AudioSource sunetFundalStop;

    public Animator animator;


    void Update()
    {
            rb.AddForce(0, 0, vitezaFata * Time.deltaTime);
            miscare.x = Input.GetAxisRaw("Horizontal");

            animator.SetFloat("Horizontal", miscare.x);
            animator.SetFloat("Speed", miscare.sqrMagnitude);
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + miscare * vitezaParti * Time.fixedDeltaTime);
        if (rb.position.y<-0.25)
        {
            sunetFundalStop.enabled = false;
            if (sunetCaz == true)
            {
                if (FindObjectOfType<Ciocnire>().lovit == false)
				{
                    DeathScript.deathValue += 1;
                }
                sunetCazut.Play();
                sunetCaz = false;
            }
        }
        if (rb.position.y < -30)
        {
            FindObjectOfType<GameManager>().Restart();
        }
    }
}

