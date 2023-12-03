/*using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Infect : MonoBehaviour
{
    public LayerMask boxMask;
    public float _distance = 1f;

    void Start()
    {
        
    }

    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, _distance, boxMask);
        if (hit.collider != null && hit.collider.gameObject.tag == "Human" && Input.GetButtonDown("Infect"))
        {
            //box = hit.collider.gameObject;
            Debug.Log("detected hooman");
        }
        else if (Input.GetButtonUp("Infect"))
        {
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * _distance);
    }
}
*/