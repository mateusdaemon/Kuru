using System;
using UnityEngine;

public class PlayerArcher : MonoBehaviour
{
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Transform arrowSpawnPos;
    [SerializeField] private float maxChargeTime = 2f;
    [SerializeField] private float minForce = 10f;
    [SerializeField] private float maxForce = 40f;
    [SerializeField] private CameraDirectionProvider cameraProvider;
    [SerializeField] private PlayerOrient playerOrient;
    [SerializeField] private PlayerAnimations playerAnimations;

    private float currentCharge = 0f;
    private bool isCharging = false;
    private bool isAiming = false;

    private void OnEnable()
    {
        RegisterEvents();
    }

    private void OnDisable()
    {
        UnregisterEvents();
    }

    private void RegisterEvents()
    {
        PlayerEvents.OnAimStarted += OnAimStart;
        PlayerEvents.OnAimCanceled += OnAimEnd;
        PlayerEvents.OnAttackStarted += OnAttackStart;
        PlayerEvents.OnAttackCanceled += OnAttackEnd;
    }

    private void UnregisterEvents()
    {
        PlayerEvents.OnAimStarted -= OnAimStart;
        PlayerEvents.OnAimCanceled -= OnAimEnd;
        PlayerEvents.OnAttackStarted -= OnAttackStart;
        PlayerEvents.OnAttackCanceled -= OnAttackEnd;
    }

    private void Update()
    {
        if (isCharging)
        {
            currentCharge += Time.deltaTime;
            currentCharge = Mathf.Clamp(currentCharge, 0, maxChargeTime);
        }
    }

    private void FixedUpdate()
    {
        if (isAiming)
        {
            playerOrient.OrientShoot(cameraProvider.GetCameraForward(), cameraProvider.GetCameraRight());
        }
    }

    private void OnAimStart()
    {
        HudManager.Instance.ToggleAimIcon(true);
        isAiming = true;
    }

    private void OnAimEnd()
    {
        HudManager.Instance.ToggleAimIcon(false);
        Debug.Log("Remove icon!");
        isAiming = false;
        isCharging = false;
        currentCharge = 0f;
    }

    private void OnAttackStart()
    {
        if (!isAiming) return;
        isCharging = true;
        currentCharge = 0f;
    }

    private void OnAttackEnd()
    {
        if (!isAiming) return;
        isCharging = false;
        ShootArrow();
    }

    private void ShootArrow()
    {
        float normalizedCharge = currentCharge / maxChargeTime;
        float finalForce = Mathf.Lerp(minForce, maxForce, normalizedCharge);

        Vector3 targetDirection = GetAimDirection();

        GameObject arrow = Instantiate(arrowPrefab, arrowSpawnPos.position, Quaternion.LookRotation(targetDirection));
        Rigidbody rb = arrow.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(targetDirection * finalForce, ForceMode.Impulse);
        }

        currentCharge = 0f;
    }

    private Vector3 GetAimDirection()
    {
        Camera cam = Camera.main;
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)); // Centro da tela
        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            // Aponta para o ponto que a mira acertou
            return (hit.point - arrowSpawnPos.position).normalized;
        }
        else
        {
            // Se não colidir com nada, vai na direção da câmera mesmo
            return ray.direction;
        }
    }
}
