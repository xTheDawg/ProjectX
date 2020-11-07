using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageResourceSequence : Sequence
{
    public ManageResourceSequence() {
            m_nodes.Add(new CheckResourceStockAction());
            m_nodes.Add(new RequestResourceAction());            
    }
}
