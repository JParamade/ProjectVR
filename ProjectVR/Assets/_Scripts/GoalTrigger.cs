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

            if (puzzleFace == PuzzleFace.FRONT) { CubePuzzleController.Instance.lights[0].material = goalMaterial; CubePuzzleController.Instance.puzzlesCompleted++; }
            else if (puzzleFace == PuzzleFace.BACK) { CubePuzzleController.Instance.lights[1].material = goalMaterial; CubePuzzleController.Instance.puzzlesCompleted++; }
            else if (puzzleFace == PuzzleFace.RIGHT) { CubePuzzleController.Instance.lights[2].material = goalMaterial; CubePuzzleController.Instance.puzzlesCompleted++; }
            else { CubePuzzleController.Instance.lights[3].material = goalMaterial; CubePuzzleController.Instance.puzzlesCompleted++; }

            if (CubePuzzleController.Instance.puzzlesCompleted >= 4) { CubePuzzleController.Instance.OnPuzzleCompleted(); }
        }
    }
}