using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    private ICollect nearbyItem;


    private void OnEnable()
    {
        PlayerEvents.OnPlayerInteract += InteractStart;
        PlayerEvents.OnPlayerInteract += InteractEnd;
    }

    private void OnDisable()
    {
        PlayerEvents.OnPlayerInteract -= InteractStart;
        PlayerEvents.OnPlayerInteract -= InteractEnd;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ICollect>(out var collectable))
        {
            nearbyItem = collectable;
            PlayerStateMachine.SetCondition(PlayerCondition.CanCollect);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<ICollect>(out var collectable) && collectable == nearbyItem)
        {
            nearbyItem = null;
            PlayerStateMachine.SetCondition(PlayerCondition.None);
        }
    }

    private void InteractStart()
    {
        if (nearbyItem != null)
        {
            nearbyItem.Collect();
            nearbyItem = null;
            Invoke(nameof(DisableInteract), 3.0f);
        }
    }

    private void DisableInteract()
    {
        PlayerActions.StopInteract();
        InteractEnd();
    }

    private void InteractEnd()
    {
        if (nearbyItem != null)
        {
            nearbyItem.Collect();
            nearbyItem = null;
            Invoke(nameof(DisableInteract), 3.0f);
        }
    }
}
