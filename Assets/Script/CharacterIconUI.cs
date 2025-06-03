using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterIconUI : MonoBehaviour
{
    public Image iconImage;
    public TextMeshProUGUI costText;

    public void Setup(CharacterData data)
    {
        iconImage.sprite = data.icon;
        costText.text = "コスト：" + data.cost;
    }
}

