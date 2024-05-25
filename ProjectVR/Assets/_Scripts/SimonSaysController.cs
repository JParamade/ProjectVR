using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SimonSaysController : MonoBehaviour
{
    public static SimonSaysController Instance { get; private set; }
    private void Awake() { Instance = this; }

    [Header("Light References")]
    [SerializeField] List<Material> lightMaterials = new List<Material>();
    [SerializeField] List<MeshRenderer> lightMR = new List<MeshRenderer>();
    [SerializeField] MeshRenderer centerLightMR;

    private List<int> correctCombination = new List<int>();
    private SimonSaysPhase gamePhase;
    [HideInInspector] public int actualPosition = 0;

    [Header("Time Values")]
    [SerializeField] float centerLightDelay = 0.2f;
    [SerializeField] float lightDelay = 0.5f;

    private void Start() { 
        NextPhase();
    }

    public void NextPhase() { 
        correctCombination.Add(Random.Range(0, 4));
        StartCoroutine(ShowAnswer());
    }

    public void ResetGame() {
        gamePhase = SimonSaysPhase.WATCH;
        correctCombination = new List<int>();
        actualPosition = 0;
    }

    public void CorrectAnswer() { 
        StartCoroutine(CenterLight(Color.green));
        actualPosition = 0;
    }

    public void WrongAnswer() { 
        StartCoroutine(CenterLight(Color.red));
        ResetGame();
        NextPhase();
    }

    public void OnButtonPressed(int buttonNumber) {
        if (gamePhase == SimonSaysPhase.PLAY) {
            lightMR[buttonNumber].material = lightMaterials[buttonNumber + 4];

            if (buttonNumber == correctCombination[actualPosition] && actualPosition < (correctCombination.Count - 1)) { actualPosition++; }
            else if (buttonNumber == correctCombination[actualPosition]) { 
                CorrectAnswer();
                NextPhase(); 
            }
            else { WrongAnswer(); }
        }
    }

    public void OnButtonUnpressed(int buttonNumber) { if (gamePhase == SimonSaysPhase.PLAY) { lightMR[buttonNumber].material = lightMaterials[buttonNumber]; } }

    public void OnCenterPressed() { StartCoroutine(ShowAnswer()); }

    IEnumerator CenterLight(Color color) {
        centerLightMR.material.color = color;

        yield return new WaitForSeconds(centerLightDelay);

        centerLightMR.material.color = Color.white;
        
        yield return new WaitForSeconds(centerLightDelay);

        centerLightMR.material.color = color;

        yield return new WaitForSeconds(centerLightDelay);

        centerLightMR.material.color = Color.white;
    }

    IEnumerator ShowAnswer() {
        gamePhase = SimonSaysPhase.WATCH;

        yield return new WaitForSeconds(0.2f);

        for (int i = 0; i < 4; i++) { lightMR[i].material = lightMaterials[i]; }

        yield return new WaitForSeconds(1);

        foreach (int color in correctCombination) {
            lightMR[color].material = lightMaterials[color + 4];

            yield return new WaitForSeconds(lightDelay);

            lightMR[color].material = lightMaterials[color];

            yield return new WaitForSeconds(0.2f);
        }

        gamePhase = SimonSaysPhase.PLAY;
    }
}