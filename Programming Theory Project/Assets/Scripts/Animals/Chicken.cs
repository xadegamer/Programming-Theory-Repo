using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : Animal
{
    private Cage currentCage = null;

    public override void IsSelected()
    {
        base.IsSelected();
    }

    protected override void CageInRange()
    {
        if (currentCage == null)
        {
            Cage cage = m_Target;

            if (cage != null)
            {
                currentCage = cage;
                animatorHandler.OnSelect();
            }
        }
    }
}
