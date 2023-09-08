using System.Collections;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public delegate void Action();
    public static GameEvents Instance;
    public event Action OnVishkasMovement;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }

    public void InvokeVishkasMovementEvent()
    {
        OnVishkasMovement?.Invoke();
    }
}
