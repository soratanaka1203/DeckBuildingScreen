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

        // �����_���ɃL������I��Œ��ڒǉ�
        for (int i = 0; i < count; i++)
        {
            //�L�����N�^�[�̍ő及������255��
            if (ownedCharacters.Count == 255) { Debug.Log("�L�����N�^�[������ȏ㏊���ł��܂���I"); return; }
            CharacterIconUI randomChar = database.characterList[Random.Range(0, database.characterList.Count)];
            ownedCharacters.Add(randomChar);
        }
    }
}
