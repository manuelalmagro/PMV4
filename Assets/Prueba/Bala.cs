using UnityEngine;

public class Bala : MonoBehaviour
{
    public float tiempoDestruccion = 5f;

    void Start()
    {
        Destroy(gameObject, tiempoDestruccion);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            GameManager.Instance.AumentarContador();
        }
    }
}
