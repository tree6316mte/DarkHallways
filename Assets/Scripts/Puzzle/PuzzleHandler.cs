using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleHandler : MonoBehaviour
{
    public PuzzleData puzzle;
    public bool isOpen;
    public virtual void InteractPuzzle()
    {
        isOpen = true;
    }

    public virtual string GetDescription()
    {
        return puzzle.description;
    }
  
}
