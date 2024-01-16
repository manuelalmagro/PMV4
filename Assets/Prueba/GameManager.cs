using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Text contadorObjetosText;
    public Text tiempoTranscurridoText;
    public Text infoText;
    public GameObject panelPausa;

    private int contadorObjetos;
    private float tiempoInicio;
    private bool programaIniciado;
    private bool juegoPausado;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        MostrarInfo("Menú");
    }

    void Update()
    {
        if (programaIniciado)
        {
            float tiempoTranscurrido = Time.time - tiempoInicio;
            ActualizarUI(tiempoTranscurrido);
        }

        if (Input.anyKeyDown && !programaIniciado)
        {
            IniciarPrograma();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && programaIniciado)
        {
            if (juegoPausado)
            {
                ReanudarJuego();
            }
            else
            {
                PausarJuego();
            }
        }
    }

    void IniciarPrograma()
    {
        programaIniciado = true;
        contadorObjetos = 0;
        tiempoInicio = Time.time;
        ActualizarUI(0f);
        MostrarInfo("");
    }

    void PararPrograma()
    {
        programaIniciado = false;
        MostrarInfo("Menú");
        PausarJuego();
    }

    public void AumentarContador()
    {
        contadorObjetos +=  1;
        ActualizarUI(tiempoTranscurrido: Time.time - tiempoInicio);
    }

    void ActualizarUI(float tiempoTranscurrido)
    {
        contadorObjetosText.text = "Eliminados: " + contadorObjetos;
        tiempoTranscurridoText.text = "Tiempo: " + FormatearTiempo(tiempoTranscurrido);
    }

    void MostrarInfo(string mensaje)
    {
        infoText.text = mensaje;
    }

    string FormatearTiempo(float segundos)
    {
        int minutos = Mathf.FloorToInt(segundos / 60f);
        int segundosRestantes = Mathf.FloorToInt(segundos % 60f);
        int centesimas = Mathf.FloorToInt((segundos - Mathf.Floor(segundos)) * 100f);

        return string.Format("{0:00}:{1:00}:{2:00}", minutos, segundosRestantes, centesimas);
    }
    void PausarJuego()
    {
        juegoPausado = true;
        Time.timeScale = 0f;
        panelPausa.SetActive(true);
    }

    public void ReanudarJuego()
    {
        juegoPausado = false;
        Time.timeScale = 1f;
        panelPausa.SetActive(false);
    }

    public void ReiniciarJuego()
    {
        ReanudarJuego();
        PararPrograma();
    }

    public void SalirDelJuego()
    {
        Application.Quit();
    }
}
