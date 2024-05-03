using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UIElements;

public class BlockBehaviour : MonoBehaviour
{
    [SerializeField] private float raycastDistance;

    private void Update()
    {   
        CheckRaycast();
    }

    private void CheckRaycast() {
        RaycastHit hit;

        if (Physics.Raycast(transform.position + new Vector3(transform.localScale.x / 2, 0, 0), transform.right, out hit, raycastDistance)) { hit.collider.gameObject.transform.position = transform.position + new Vector3(transform.localScale.x, 0, 0); hit.collider.gameObject.transform.SetParent(gameObject.transform); }
        if (Physics.Raycast(transform.position + new Vector3(-transform.localScale.x / 2, 0, 0), -transform.right, out hit, raycastDistance)) { hit.collider.gameObject.transform.position = transform.position - new Vector3(transform.localScale.x, 0, 0); hit.collider.gameObject.transform.SetParent(gameObject.transform); }
        if (Physics.Raycast(transform.position + new Vector3(0, transform.localScale.y / 2, 0), transform.up, out hit, raycastDistance)) { hit.collider.gameObject.transform.position = transform.position + new Vector3(0, transform.localScale.y, 0); hit.collider.gameObject.transform.SetParent(gameObject.transform); }
        if (Physics.Raycast(transform.position + new Vector3(0, -transform.localScale.y / 2, 0), -transform.up, out hit, raycastDistance)) { hit.collider.gameObject.transform.position = transform.position - new Vector3(0, transform.localScale.y, 0); hit.collider.gameObject.transform.SetParent(gameObject.transform); }
        if (Physics.Raycast(transform.position + new Vector3(0, 0, transform.localScale.z / 2), transform.forward, out hit, raycastDistance)) { hit.collider.gameObject.transform.position = transform.position + new Vector3(0, 0, transform.localScale.z); hit.collider.gameObject.transform.SetParent(gameObject.transform); }
        if (Physics.Raycast(transform.position + new Vector3(0, 0, -transform.localScale.z / 2), -transform.forward, out hit, raycastDistance)) { hit.collider.gameObject.transform.position = transform.position - new Vector3(0, 0, transform.localScale.z); hit.collider.gameObject.transform.SetParent(gameObject.transform); }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position + new Vector3(transform.localScale.x / 2, 0, 0), transform.right * raycastDistance);
        Gizmos.DrawRay(transform.position + new Vector3(-transform.localScale.x / 2, 0, 0), -transform.right * raycastDistance);
        Gizmos.DrawRay(transform.position + new Vector3(0, transform.localScale.y / 2, 0), transform.up * raycastDistance);
        Gizmos.DrawRay(transform.position + new Vector3(0, -transform.localScale.y / 2, 0), -transform.up * raycastDistance);
        Gizmos.DrawRay(transform.position + new Vector3(0, 0, transform.localScale.z / 2), transform.forward * raycastDistance);
        Gizmos.DrawRay(transform.position + new Vector3(0, 0, -transform.localScale.z / 2), -transform.forward * raycastDistance);
    }
}