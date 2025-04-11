using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    public static HudManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    [Header("Gameplay Items")]
    [SerializeField] private Image aimShootIcon;

    public void ToggleAimIcon(bool enable)
    {
        if (aimShootIcon != null)
            aimShootIcon.enabled = enable;
    }
}
