using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySelector : Selector
{
    public EnergySelector()
    {
        m_nodes.Add(new CheckEnergyAction());
        m_nodes.Add(new RestAction());
    }
}
