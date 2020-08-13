using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XP.Pathfinding;

public class TowerPlaceholder : MonoBehaviour
{
    [SerializeField] ShopStatusValue shopStatus = default;
    [SerializeField] LayerMask gridLayerMask;

    private TowerData data;

    private Camera cachedCamera;
    private GameNode currentNode;

    private void Awake()
    {
        cachedCamera = Camera.main;
    }

    public void Init(TowerData data)
    {
        this.data = data;
    }

    private void Update()
    {
        RaycastHit hit;
        Ray ray = cachedCamera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red);

        if (Physics.Raycast(ray, out hit, 100f, gridLayerMask))
        {
            currentNode = hit.collider.GetComponent<GameNode>();
            if (currentNode != null && currentNode.IsEmpty)
            {
                //Node node = currentNode.GetComponent<Node>();
                //if(!node.IsVisitable)
                    transform.position = currentNode.transform.position;
            }
        }
        else
        {
            currentNode = null;
        }

        if(Input.GetMouseButtonDown(0) && currentNode != null)
        {
            GameObject towerObject = Instantiate(data.prefab, transform.position, transform.rotation);
            Tower tower = towerObject.GetComponent<Tower>();
            currentNode.SetTower(tower);
            shopStatus.SetStatus(ShopStatus.None);
            Destroy(this.gameObject);
        }

    }

}
