using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubePuzzleController : MonoBehaviour
{
    [SerializeField] ParticleSystem fireworkParticles;

    public int puzzlesCompleted = 0;

    public static CubePuzzleController Instance { get; private set; }
    private void Awake() { Instance = this; }

    public List<MeshRenderer> lights = new List<MeshRenderer>();

    public void OnPuzzleCompleted() { fireworkParticles.gameObject.SetActive(true); }
}
