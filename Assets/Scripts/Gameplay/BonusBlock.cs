using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBlock : StandardBlock
{
    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start();
        healthe = 2;
        point = ConfigurationUtils.BonusBlock;
    }
}
