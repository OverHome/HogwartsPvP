using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCast : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private List<Magic> _magics;
    private SphinxManager sphinx;
    private IEnumerator Start()
    {
        sphinx = FindObjectOfType<SphinxManager>();
        sphinx.OnSpeechRecognized += Spell;
        while (sphinx.mic == null)
        {
            yield return null;
        }
    }
    
    private void Spell(string str)
    {
        print(str);
        if (str.Contains("огонь")) Cast(_magics[0]);
        else if (str.Contains("вода")) Cast(_magics[1]);
        else if (str.Contains("молния")) Cast(_magics[2]);
    }
    private void Cast(Magic magic)
    {
        Instantiate(magic.GameObject, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }
}
