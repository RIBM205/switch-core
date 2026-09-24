using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class cambioMundo : MonoBehaviour
{
    [Header("Componentes")]
    [SerializeField] private PlayerInput playerInput;

    [Header("Transicion de mundo")]
    [Tooltip("Activalo durante Play para iniciar la misma transicion que con E.")]
    public bool activarTransicion;
    [Min(0f)]
    [Tooltip("Distancia de levitacion en pixeles del sprite del jugador.")]
    public float pixelesLevitacion = 8f;

    private bool enTransicion;
    private Rigidbody2D jugadorRB;
    private movimientoJugador movimiento;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        jugadorRB = GetComponent<Rigidbody2D>();
        movimiento = GetComponent<movimientoJugador>();
    }

    void Update()
    {
        if (enTransicion) return;

        if (playerInput.actions["Cambiar"].WasPressedThisFrame()) //Es a la tecla E
        {
            activarTransicion = true;
        }

        if (activarTransicion)
            StartCoroutine(TransicionDeMundo());
    }

    private IEnumerator TransicionDeMundo()
    {
        enTransicion = true;
        bool movimientoHabilitado = movimiento.enabled;
        bool fisicaHabilitada = jugadorRB.simulated;
        movimiento.enabled = false;
        jugadorRB.linearVelocity = Vector2.zero;
        jugadorRB.angularVelocity = 0f;
        jugadorRB.simulated = false;

        Vector3 inicio = transform.position;
        SpriteRenderer sprite = GetComponentInChildren<SpriteRenderer>();
        float unidadesPorPixel = sprite != null && sprite.sprite != null
            ? Mathf.Abs(sprite.transform.lossyScale.y) / sprite.sprite.pixelsPerUnit
            : 0.01f;
        Vector3 destino = inicio + Vector3.up * (pixelesLevitacion * unidadesPorPixel);

        const float duracion = 2f;
        float tiempo = 0f;
        while (tiempo < duracion)
        {
            tiempo += Time.deltaTime;
            transform.position = Vector3.Lerp(inicio, destino,
                Mathf.SmoothStep(0f, 1f, tiempo / duracion));
            yield return null;
        }

        managerMundo.instance.CambioDeMundo();
        jugadorRB.position = transform.position;
        jugadorRB.simulated = fisicaHabilitada;
        movimiento.enabled = movimientoHabilitado;
        activarTransicion = false;
        enTransicion = false;
    }
}
