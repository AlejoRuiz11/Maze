using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable
{
    float Speed {get;}
    void Move(Vector3 direction);

    void ReproducirSonido();
    void PararSonido();

}
