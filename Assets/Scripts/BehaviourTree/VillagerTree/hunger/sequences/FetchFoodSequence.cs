using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FetchFoodSequence : Sequence
{
    public FetchFoodSequence() {
            m_nodes.Add(new CheckFoodStockAction());
            m_nodes.Add(new EatAction());            
    }
}
