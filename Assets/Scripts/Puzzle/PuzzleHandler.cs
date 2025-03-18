using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleHandler : MonoBehaviour
{
    public PuzzleData puzzle;
    public bool isOpen;
    private Rigidbody _rigidbody;

    public virtual void InteractPuzzle()
    {
        isOpen = true;
        _rigidbody = GetComponent<Rigidbody>();
        if( _rigidbody != null )
            _rigidbody.useGravity = true;
    }

    public virtual string GetDescription()
    {
        return puzzle.description;
    }
  
}
