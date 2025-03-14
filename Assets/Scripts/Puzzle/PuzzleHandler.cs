using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleHandler : MonoBehaviour
{
    public PuzzleData puzzle;

    public virtual void InteractPuzzle()
    {

    }

    public string GetDescription()
    {
        return puzzle.description;
    }
  
}
