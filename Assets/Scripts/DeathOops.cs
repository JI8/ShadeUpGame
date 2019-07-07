using UnityEngine;

public class DeathOops : MonoBehaviour
{

    public GameManager gameManager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            

            Application.LoadLevel(0);
        }
    }
}

