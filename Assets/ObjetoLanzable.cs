using UnityEngine;

public class ObjetoLanzable : MonoBehaviour
{
    public float tiempoVida = 3f;

    void Start()
    {
        // Destruir el objeto después de cierto tiempo
        Destroy(gameObject, tiempoVida);
    }

    void OnBecameInvisible()
    {
        // Destruir el objeto al salir de la pantalla
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Manejar colisión con enemigos (ajusta según sea necesario)
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            Destroy(collision.gameObject); // Destruir el enemigo
            GameManager.Instance.AumentarContador(); // Aumentar contador en el GameManager
        }

        // Destruir el objeto lanzable después de la colisión
        Destroy(gameObject);
    }
}
