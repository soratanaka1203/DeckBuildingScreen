using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/Owned Characters")]
public class PlayerCharacterCollection : ScriptableObject
{
    public List<CharacterData> ownedCharacters;

    public void InitializeRandomCharacters(CharacterDatabase database, int count)
    {
        ownedCharacters.Clear();

        List<CharacterData> randomCharacter = new List<CharacterData>();

        // ランダムにキャラを選んで直接追加
        for (int i = 0; i < count; i++)
        {
            //キャラクターの最大所持数は255体
            if (ownedCharacters.Count == 255) { Debug.Log("キャラクターをこれ以上所持できません！"); return; }
            CharacterData randomChar = database.characterList[Random.Range(0, database.characterList.Count)];
            ownedCharacters.Add(randomChar);
        }
    }
}
