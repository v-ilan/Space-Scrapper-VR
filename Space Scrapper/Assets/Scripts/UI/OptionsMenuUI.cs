using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Unity.VisualScripting;
using TMPro;
using System;

public class OptionsMenuUI : MonoBehaviour
{
    private enum SubMenu { Options, Locomotion, None }

    [Header("UI Pages")]
    [SerializeField] private GameObject mainMenuPage;
    [SerializeField] private GameObject locomotionPage;

    [Header("Buttons")]
    [SerializeField] private Button locomotionButton;
    [SerializeField] private List<Button> returnButtons;

    [Header("Sound")]
    private TextMeshPro musicText;
    private Slider musicSlider;
    private TextMeshPro sfxText;
    private Slider sfxSlider;

    private void Awake()
    {
        InitButtons();
        Initsounds();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        ShowPage(SubMenu.Options);
    }

    private void InitButtons()
    {
        locomotionButton.onClick.AddListener(() => ShowPage(SubMenu.Locomotion));
        
        foreach (var btn in returnButtons)
        {
            btn.onClick.AddListener(() => ShowPage(SubMenu.Options));
        }
    }

    private void Initsounds()
    {
        musicSlider.onValueChanged.AddListener((value) => {
            MusicManager.Instance.ChangeVolume(value);
            UpdateVisuals();
            });
    }

    private void ShowPage(SubMenu targetPage)
    {
        mainMenuPage.SetActive(targetPage == SubMenu.Options);
        locomotionPage.SetActive(targetPage == SubMenu.Locomotion);
    }

    private void UpdateVisuals()
    {
        musicText.text = "Music: " + Mathf.RoundToInt(MusicManager.Instance.GetVolume() * 10f);
        sfxText.text = "SFX: " + Mathf.RoundToInt(SoundManager.Instance.GetVolume() * 10f);
    }
}
