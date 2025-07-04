using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.TextCore.Text;

public class CharacterGridUI : MonoBehaviour
{
    public Transform gridParent; // Grid Layout Groupがついたオブジェクト
    public GameObject characterIconPrefab;
    public List<CharacterData> ownedCharacters; // 所持しているキャラ

    private List<Transform> children = new List<Transform>();// 子オブジェクトのリスト

    void Start()
    {
        PopulateGrid();
        // 子オブジェクトのリストを取得
        foreach (Transform child in gridParent)
        {
            children.Add(child);
        }
    }

    private void PopulateGrid()
    {
        foreach (var character in ownedCharacters)
        {
            GameObject iconObj = Instantiate(characterIconPrefab, gridParent);
            iconObj.GetComponent<CharacterIconUI>().Setup(character);
        }
    }

    [SerializeField] TextMeshProUGUI sortButtonText;
    int pressCount = 0;
    public void OnSortButton()
    {
        switch (pressCount)
        {
            case 0:
                sortButtonText.text = "ソート：コスト順";
                SortByCost();
                pressCount++;
                break;
            case 1: 
                sortButtonText.text = "ソート：HP順";
                SortByHP();
                pressCount++;
                break;
            case 2:
                sortButtonText.text = "ソート：入手順";
                SortByEntry();
                pressCount = 0;
                break;
        }       
    }

    private void SortByEntry()
    {
        List<Transform> characters = children;
       
        for (int i = 0; i < characters.Count; i++)
        {
            characters[i].transform.SetSiblingIndex(i);
        }
    }

    private void SortByCost()
    {
        SortCharacter((a, b) => a.characterData.cost.CompareTo(b.characterData.cost));
    }

    private void SortByHP()
    {
        SortCharacter((a, b) => a.characterData.hp.CompareTo(b.characterData.hp));
    }

    private void SortCharacter(System.Comparison<CharacterIconUI> comparison)
    {
        List<CharacterIconUI> characters = new List<CharacterIconUI>();

        foreach (Transform child in gridParent)
        {
            CharacterIconUI view = child.GetComponent<CharacterIconUI>();
            if (view != null)
            {
                characters.Add(view);
            }
        }

        characters.Sort(comparison);

        for (int i = 0; i < characters.Count; i++)
        {
            characters[i].transform.SetSiblingIndex(i);
        }
    }
}
