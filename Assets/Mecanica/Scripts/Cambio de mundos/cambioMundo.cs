using UnityEngine;
using UnityEngine.InputSystem;

public class cambioMundo : MonoBehaviour
{
    [Header("Componentes")]
    [SerializeField] private PlayerInput playerInput;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        if (playerInput.actions["Cambiar"].WasPressedThisFrame()) //Es a la tecla E
        {
            managerMundo.instance.CambioDeMundo();
        }
    }
}
