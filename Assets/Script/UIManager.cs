using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [field: SerializeField] public bool IsMenuOpened { get; set; } = false;

    public GameObject menuPanel;
    public TMP_Text scoreText;
    public TMP_Text bestScoreText;
    public TMP_Text gameScoreText;
    public Animator animator;
    private int skinIndex;

    public void PlayStartAnim()
    {
        animator.SetBool(SaveManager.Instance.GetData().skin, true);
    }

    public void SetScoreText()
    {
        this.scoreText.text = SaveManager.Instance.GetData().lastScore.ToString();
        bestScoreText.text = SaveManager.Instance.GetData().score.ToString();
        gameScoreText.text = "0";
    }

    public void SetNextSkin()
    {
        if (skinIndex < 4)
        {
            skinIndex++;
            
        }
        if(skinIndex > 3)
        {
            skinIndex = 1;
        }
        SetSkin();
    }
    
    public void SetPreviousSkin()
    {
        if (skinIndex > 0)
        {
            skinIndex--;
            
        }
        if(skinIndex < 1)
        {
            skinIndex = 3;
        }
        SetSkin();
    }

    private void SetSkin()
    {
        switch (skinIndex)
        {
            case 1:
                animator.SetBool(SaveManager.Instance.GetData().skin, false);
                SaveManager.Instance.SetSkin("blue_bird_skin");
                break;
            case 2:
                animator.SetBool(SaveManager.Instance.GetData().skin, false);
                SaveManager.Instance.SetSkin("yellow_bird_skin");
                break;
            case 3:
                animator.SetBool(SaveManager.Instance.GetData().skin, false);
                SaveManager.Instance.SetSkin("red_bird_skin");
                break;
        }
        animator.SetBool(SaveManager.Instance.GetData().skin, true);
    }
}