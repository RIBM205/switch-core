using UnityEngine;

public class managerMundo : MonoBehaviour
{
    public static managerMundo instance;

    [Header("Variables de Mundo")]
    public bool enMundoDeLuz;

    [Header("Posiciones Y de mundos")]
    public float yLuz;
    public float yOscuridad;

    [Header("Jugador")]
    [SerializeField] private Transform jugador;

    [Header("Puntos de Cambio")]
    [SerializeField] private Transform puntoLuzIzquierda;
    [SerializeField] private Transform puntoLuzDerecha;
    [SerializeField] private Transform puntoOscuridadIzquierda;
    [SerializeField] private Transform puntoOscuridadDerecha;
    [SerializeField] private Transform puntoElegido;



    private void Awake()
    {
        instance = this;
    }

    public void CambioDeMundo()
    {
        if (enMundoDeLuz)
        {
            float distanciaIzquierda = Mathf.Abs(
                jugador.position.x - puntoLuzIzquierda.position.x
            );

            float distanciaDerecha = Mathf.Abs(
                jugador.position.x - puntoLuzDerecha.position.x
            );

            if (distanciaIzquierda < distanciaDerecha)
            {
                jugador.position = puntoOscuridadIzquierda.position;
            }
            else
            {
                jugador.position = puntoOscuridadDerecha.position;
            }
        }
        else
        {
            float distanciaIzquierda = Mathf.Abs(
                jugador.position.x - puntoOscuridadIzquierda.position.x
            );

            float distanciaDerecha = Mathf.Abs(
                jugador.position.x - puntoOscuridadDerecha.position.x
            );

            if (distanciaIzquierda < distanciaDerecha)
            {
                jugador.position = puntoLuzIzquierda.position;
            }
            else
            {
                jugador.position = puntoLuzDerecha.position;
            }
        }

        enMundoDeLuz = !enMundoDeLuz;
    }
}

