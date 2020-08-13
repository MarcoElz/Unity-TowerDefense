using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMouseInput : MonoBehaviour
{
    [SerializeField] LayerMask gridLayerMask = default;
    [SerializeField] Shop shop = default;

    private Camera cachedCamera;

    private void Start()
    {
        cachedCamera = Camera.main;
    }

    private void Update()
    {     
        if (Input.GetMouseButtonDown(0))
        {
            bool isOverUi = EventSystem.current.IsPointerOverGameObject();
            RaycastHit hit;
            Ray ray = cachedCamera.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red);

            if(Physics.Raycast(ray, out hit, 100f, gridLayerMask))
            {
                GameNode node = hit.collider.GetComponent<GameNode>();
                if(node != null)
                {
                    if(!node.IsEmpty)
                    {
                        shop.OpenShop(node);
                    }
                    else if(!isOverUi)
                    {
                        shop.Clean();
                    }
                }
                else if (!isOverUi)
                {
                    shop.Clean();
                }
            }
            else if (!isOverUi)
            {
                shop.Clean();
            }
        }

        
    }

}
