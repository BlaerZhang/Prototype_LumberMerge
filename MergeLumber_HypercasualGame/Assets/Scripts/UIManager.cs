using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI woodUI;
    public TextMeshProUGUI stoneUI;
    public TextMeshProUGUI ironUI;
    public TextMeshProUGUI carbonFiberUI;
    public TextMeshProUGUI grapheneUI;
    public TextMeshProUGUI voidthiumUI;
    
    public static UIManager instance;

    private bool isPlayingNotEnoughAnimation = false;
        
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        woodUI.text = $"Wood: {ResourceManager.instance.wood}";
        stoneUI.text = $"Stone: {ResourceManager.instance.stone}";
        ironUI.text = $"Iron: {ResourceManager.instance.iron}";
        carbonFiberUI.text = $"Carbon Fiber: {ResourceManager.instance.carbonFiber}";
        grapheneUI.text = $"Graphene: {ResourceManager.instance.graphene}";
        voidthiumUI.text = $"Voidthium: {ResourceManager.instance.voidthium}";
    }

    public void PlayNotEnoughAnimation(ResourceManager.Resources resourceType)
    {
        if (isPlayingNotEnoughAnimation) return;
        isPlayingNotEnoughAnimation = true;
        switch (resourceType)
        {
            case ResourceManager.Resources.Wood:
                NotEnoughAnimation(woodUI);
                print("Need Wood");
                break;
            case ResourceManager.Resources.Stone:
                NotEnoughAnimation(stoneUI);
                print("Need Stone");
                break;
            case ResourceManager.Resources.Iron:
                NotEnoughAnimation(ironUI);
                print("Need Iron");
                break;
            case ResourceManager.Resources.CarbonFiber:
                NotEnoughAnimation(carbonFiberUI);
                print("Need Carbon Fiber");
                break;
            case ResourceManager.Resources.Graphene:
                NotEnoughAnimation(grapheneUI);
                print("Need Graphene");
                break;
            case ResourceManager.Resources.Voidthium:
                NotEnoughAnimation(voidthiumUI);
                print("Need Voidthium");
                break;
        }
    }

    private void NotEnoughAnimation(TextMeshProUGUI text)
    {
        text.DOColor(Color.red, 0.5f).SetEase(Ease.Flash, 4, 0);
        text.rectTransform.DOShakeAnchorPos(0.5f, Vector3.right * 10f, 10).OnComplete((() =>
        {
            isPlayingNotEnoughAnimation = false;
        }));
    }
}
