using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    [SerializeField] PuzzleFace puzzleFace;
    [SerializeField] GameManager gameManager;
    [SerializeField] Material goalMaterial;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<SphereCollider>())
        {
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            
            if (puzzleFace == PuzzleFace.FRONT) { gameManager.lightMR[0].GetComponent<MeshRenderer>().material = goalMaterial; }
            else if (puzzleFace == PuzzleFace.BACK) { gameManager.lightMR[1].GetComponent<MeshRenderer>().material = goalMaterial; }
            else if (puzzleFace == PuzzleFace.RIGHT) { gameManager.lightMR[2].GetComponent<MeshRenderer>().material = goalMaterial; }
            else if (puzzleFace == PuzzleFace.LEFT  ) { gameManager.lightMR[3].GetComponent<MeshRenderer>().material = goalMaterial; }
        }
    }
}
