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

    private void Awake()
    {
        instance = this;
    }

    public void CambioDeMundo()
    {
        Vector3 nuevaPosicion = jugador.position;

        if (enMundoDeLuz)
        {
            nuevaPosicion.y = yOscuridad;
        }
        else
        {
            nuevaPosicion.y = yLuz;
        }

        jugador.position = nuevaPosicion;

        enMundoDeLuz = !enMundoDeLuz;
    }
}
