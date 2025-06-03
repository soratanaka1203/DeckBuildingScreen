using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterGridUI : MonoBehaviour
{
    public Transform gridParent; // Grid Layout Group�������I�u�W�F�N�g
    public GameObject characterIconPrefab;
    public List<CharacterData> ownedCharacters; // �������Ă���L����

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
