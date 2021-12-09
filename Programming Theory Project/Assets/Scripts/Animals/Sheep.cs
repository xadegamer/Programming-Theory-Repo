using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : Animal
{
    [SerializeField] ParticleSystem selectParticle;
    public override void IsSelected()
    {
        base.IsSelected();
        selectParticle.Play();
    }

    protected override void CageInRange()
    {

    }
}
