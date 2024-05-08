using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCast : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Shield shield;
    [SerializeField] private List<Magic> _magics;
    private SphinxManager _sphinx;
    private int _shieldAngle = 35;
    private IEnumerator Start()
    {
        _sphinx = FindObjectOfType<SphinxManager>();
        if (_sphinx != null)
        {
            _sphinx.OnSpeechRecognized += Spell;
            while (_sphinx.mic == null)
            {
                yield return null;
            }
        }
    }

    private void FixedUpdate()
    {
        print(GetMagicAngle());
        if (shield.IsOn && GetMagicAngle() > _shieldAngle)
        {
            shield.ShieldOff();
        }
    }

    private void Spell(string str)
    {
        print(str);
        if (str.Contains("огонь")) Cast(0);
        else if (str.Contains("вода")) Cast(1);
        else if (str.Contains("молния")) Cast(2);
    }
    public void Cast(int id)
    {
        print(GetMagicAngle());
        if (GetMagicAngle() <= _shieldAngle)
        {
            shield.ShieldOn(id);
        }
        else
        {
            Magic magic = _magics[id];
            Instantiate(magic.GameObject, spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
    }

    private float GetMagicAngle()
    {
        var angle = (transform.rotation.eulerAngles.x % 180 + 180) % 180;
        return angle > 90 ? Math.Abs(angle-180) : Math.Abs(angle);
    }
}
