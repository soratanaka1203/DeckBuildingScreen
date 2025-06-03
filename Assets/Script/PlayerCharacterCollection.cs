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

        // ƒ‰ƒ“ƒ_ƒ€‚ÉƒLƒƒƒ‰‚ğ‘I‚ñ‚Å’¼Ú’Ç‰Á
        for (int i = 0; i < count; i++)
        {
            CharacterData randomChar = database.characterList[Random.Range(0, database.characterList.Count)];
            ownedCharacters.Add(randomChar);
        }
    }
}
