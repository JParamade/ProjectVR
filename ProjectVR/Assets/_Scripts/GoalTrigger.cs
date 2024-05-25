using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    [SerializeField] PuzzleFace puzzleFace;
    [SerializeField] Material goalMaterial;
 
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<SphereCollider>() && !other.gameObject.GetComponent<Rigidbody>().isKinematic)
        {
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
 
            if (puzzleFace == PuzzleFace.FRONT) { CubePuzzleController.Instance.lightMR[0].material = goalMaterial; CubePuzzleController.Instance.puzzlesCompleted++; }
            else if (puzzleFace == PuzzleFace.BACK) { CubePuzzleController.Instance.lightMR[1].material = goalMaterial; CubePuzzleController.Instance.puzzlesCompleted++; }
            else if (puzzleFace == PuzzleFace.RIGHT) { CubePuzzleController.Instance.lightMR[2].material = goalMaterial; CubePuzzleController.Instance.puzzlesCompleted++; }
            else { CubePuzzleController.Instance.lightMR[3].material = goalMaterial; CubePuzzleController.Instance.puzzlesCompleted++; }
 
            if (CubePuzzleController.Instance.puzzlesCompleted >= 4) { CubePuzzleController.Instance.OnPuzzleCompleted(); }
        }
    }
}