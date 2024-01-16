using UnityEngine;

public class ControladorJugador : MonoBehaviour
{
    public GameObject objetoLanzablePrefab;

    void Update()
    {
        // Control del movimiento con el teclado
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(movimientoHorizontal, movimientoVertical, 0f) * Time.deltaTime * 5f);

        // Lanzar objetos al pulsar una tecla
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LanzarObjeto();
        }
    }

    void LanzarObjeto()
    {
        // Instanciar el objeto lanzable y ajustar su posición
        GameObject objetoLanzable = Instantiate(objetoLanzablePrefab, transform.position, Quaternion.identity);

        // Aplicar velocidad al objeto lanzable (ajusta según sea necesario)
        objetoLanzable.GetComponent<Rigidbody2D>().velocity = new Vector2(5f, 0f);
    }
}
