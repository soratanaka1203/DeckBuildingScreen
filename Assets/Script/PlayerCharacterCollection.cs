using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/Owned Characters")]
public class PlayerCharacterCollection : ScriptableObject
{
    public List<CharacterIconUI> ownedCharacters;

    public void InitializeRandomCharacters(CharacterDatabase database, int count)
    {
        ownedCharacters.Clear();

        List<CharacterIconUI> randomCharacter = new List<CharacterIconUI>();

        // ランダムにキャラを選んで直接追加
        for (int i = 0; i < count; i++)
        {
            //キャラクターの最大所持数は255体
            if (ownedCharacters.Count == 255) { Debug.Log("キャラクターをこれ以上所持できません！"); return; }
            CharacterIconUI randomChar = database.characterList[Random.Range(0, database.characterList.Count)];
            ownedCharacters.Add(randomChar);
        }
    }
}
