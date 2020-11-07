using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherFoodSequence : Sequence
{
    public GatherFoodSequence() {
            m_nodes.Add(new RequestFoodAction());
            m_nodes.Add(new DoJobInverter());            
    }
}
