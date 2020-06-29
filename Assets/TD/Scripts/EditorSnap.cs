using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditorSnap : MonoBehaviour
{
#if UNITY_EDITOR
    private void Update()
    {
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(Mathf.Round(position.x), 0, int.MaxValue) ;       
        position.z = Mathf.Clamp(Mathf.Round(position.z), 0, int.MaxValue);
        transform.position = position;

        gameObject.name = "Node["+position.x+"]["+position.z+"]";
    }
#endif

}
