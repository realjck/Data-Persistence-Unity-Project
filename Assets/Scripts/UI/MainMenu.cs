using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] TMP_InputField nameInput;
    [SerializeField] Button buttonLeft;
    [SerializeField] Button buttonRight;
    [SerializeField] GameObject  backgroundThumbnail;
    [SerializeField] Material[] backgroundMaterials;
    [SerializeField] Button startButton;
    private int selectedBackgroundIndex;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance != null){
            nameInput.text = GameManager.Instance.playerName;
            selectedBackgroundIndex = GameManager.Instance.selectedBackgroundIndex;
        }
        ShowBackgroundThumbnail();
        CheckIfName();
    }

    public void CheckIfName(){
        if (nameInput.text != ""){
            startButton.interactable = true;
        } else {
            startButton.interactable = false;
            nameInput.Select();
        }
    }
    public void ClickButtonLeft(){
        selectedBackgroundIndex--;
        if (selectedBackgroundIndex < 0){
            selectedBackgroundIndex = backgroundMaterials.Length -1;
        }
        ShowBackgroundThumbnail();
    }
    public void ClickButtonRight(){
        selectedBackgroundIndex++;
        if (selectedBackgroundIndex > backgroundMaterials.Length -1){
            selectedBackgroundIndex = 0;
        }
        ShowBackgroundThumbnail();
    }
    private void ShowBackgroundThumbnail(){
        
        backgroundThumbnail.GetComponent<Image>().material = backgroundMaterials[selectedBackgroundIndex];
        //backgroundThumbnail.GetComponent<MeshRenderer>().material = backgroundMaterials[selectedBackgroundIndex];

        // store in game manager:
        GameManager.Instance.backgroundMaterial = backgroundMaterials[selectedBackgroundIndex];
        GameManager.Instance.selectedBackgroundIndex = selectedBackgroundIndex;
    }

    public void ClickButtonStart(){

        // store in game manager:
        GameManager.Instance.playerName = nameInput.text;

        // load scene:
        SceneManager.LoadScene(1);
    }
}
