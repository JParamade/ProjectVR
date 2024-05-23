using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    [SerializeField] PuzzleFace puzzleFace;
    [SerializeField] Material goalMaterial;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<SphereCollider>())
        {
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            
            if (puzzleFace == PuzzleFace.FRONT) { GameManager.Instance.lightMR[0].material = goalMaterial; }
            else if (puzzleFace == PuzzleFace.BACK) { GameManager.Instance.lightMR[1].material = goalMaterial; }
            else if (puzzleFace == PuzzleFace.RIGHT) { GameManager.Instance.lightMR[2].material = goalMaterial; }
            else if (puzzleFace == PuzzleFace.LEFT) { GameManager.Instance.lightMR[3].material = goalMaterial; }
        }
    }
}