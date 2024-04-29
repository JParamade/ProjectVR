using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehaviour : MonoBehaviour
{
    [SerializeField] private float raycastDistance;

    private void Update()
    {
       RaycastHit hit;
       //if (Physics.Raycast(new Vector3(0, transform.position.y + (transform.localScale.y / 2), 0), transform.up, out hit, raycastDistance, layerMask))       
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(new Vector3(0, transform.position.y + (transform.localScale.y / 2), 0), transform.up * raycastDistance);
        Gizmos.DrawRay(new Vector3(0, -(transform.position.y + (transform.localScale.y / 2)), 0), -transform.up * raycastDistance);
        Gizmos.DrawRay(new Vector3(0, transform.position.x + (transform.localScale.y / 2), 0), transform.right * raycastDistance);
        Gizmos.DrawRay(new Vector3(0, -(transform.position.x + (transform.localScale.y / 2)), 0), -transform.right * raycastDistance);
        Gizmos.DrawRay(new Vector3(0, transform.position.z + (transform.localScale.y / 2), 0), transform.forward * raycastDistance);
        Gizmos.DrawRay(new Vector3(0, -(transform.position.z + (transform.localScale.y / 2)), 0), -transform.forward * raycastDistance);
    }
}
