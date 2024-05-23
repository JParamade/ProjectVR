using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Material completedMaterial;

    public static GameManager Instance { get; private set; }
    private void Awake() { Instance = this; }

    public List<MeshRenderer> lightMR = new List<MeshRenderer>();

    private void CheckCompleted() {
        foreach (MeshRenderer cmpMR in lightMR) {
            cmpMR.material = completedMaterial;
        }  
    }
}
