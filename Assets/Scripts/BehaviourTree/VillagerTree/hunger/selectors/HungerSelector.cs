using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerSelector : Selector
{
    public HungerSelector()
    {
        m_nodes.Add(new ReplenishHungerSelector());
    }
}
