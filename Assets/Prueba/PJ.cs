using UnityEngine;

public class ControladorPersonaje : MonoBehaviour
{
    public float velocidadMovimiento = 5f;
    public GameObject balaPrefab;
    public Transform puntoDisparo;
    public float velocidadDisparo = 10f;

    void Update()
    {
        Movimiento();
        DisparoBala();
    }

    void Movimiento()
    {
        float movimientoVertical = Input.GetAxis("Vertical");
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(new Vector2(movimientoHorizontal, movimientoVertical) * Time.deltaTime * velocidadMovimiento);
    }

    void DisparoBala()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InstanciarBala();
        }
    }
    void InstanciarBala()
    {
        GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, Quaternion.identity);

        bala.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadDisparo, 0f);
    }
}
