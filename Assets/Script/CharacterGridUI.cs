using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterGridUI : MonoBehaviour
{
    public Transform gridParent; // Grid Layout Groupがついたオブジェクト
    public GameObject characterIconPrefab;
    public List<CharacterData> ownedCharacters; // 所持しているキャラ

    void Start()
    {
        PopulateGrid();
    }

    void PopulateGrid()
    {
        foreach (var character in ownedCharacters)
        {
            GameObject iconObj = Instantiate(characterIconPrefab, gridParent);
            iconObj.GetComponent<CharacterIconUI>().Setup(character);
        }
    }
}
