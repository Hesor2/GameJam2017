using UnityEngine;
using System.Collections;

abstract public class Collidable : MonoBehaviour
{

    abstract public void EnterCollision(string tag, GameObject gameobject);
    abstract public void StayCollision(string tag, GameObject gameobject);
    abstract public void ExitCollision(string tag, GameObject gameobject);
    
}
