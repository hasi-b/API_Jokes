using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
public class AimController : MonoBehaviour
{
    [SerializeField]
    CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField]
    float normalSensitivity;
    [SerializeField]
    float aimSensitivity;
    [SerializeField]
    LayerMask aimLayerMask = new LayerMask();

    ThirdPersonController thirdPersonController;
    StarterAssetsInputs starterAssetsInputs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        thirdPersonController = GetComponent<ThirdPersonController>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width/2f, Screen.height/2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if(Physics.Raycast(ray,out RaycastHit raycastHit, 999f, aimLayerMask))
        {
            mouseWorldPosition = raycastHit.point;
        }


        if (starterAssetsInputs.aim)
        {
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.SetSensitivity(aimSensitivity);
            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;
            transform.forward = Vector3.Lerp(transform.forward,aimDirection,Time.deltaTime*20f);
        }
        else
        {
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.SetSensitivity(normalSensitivity);
        }
    }
}
