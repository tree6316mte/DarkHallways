using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadLock : PuzzleHandler
{
    public override void InteractPuzzle()
    {
        base.InteractPuzzle();
        if (isOpen)
        {
            SoundManager.Instance.PlaySFX("Padlock");
            gameObject.AddComponent<Rigidbody>();
            Destroy(this, 2f);
        }
    }
}
