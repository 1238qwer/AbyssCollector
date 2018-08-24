using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ParallaxImage : ScriptableObject {

    public Material material;
    public Vector2 parallaxVector;
    public float parallaxSpeed;
}
