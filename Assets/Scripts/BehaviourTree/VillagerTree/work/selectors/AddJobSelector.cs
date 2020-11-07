using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddJobSelector : Selector
{
    public AddJobSelector() {
            m_nodes.Add(new ManageResourceSequence());
            m_nodes.Add(new RequestBuildingAction());            
    }
}
