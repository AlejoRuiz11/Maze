using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    bool Utilizado { get; }
    void Interactuar();
}
