using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkSelector : Selector
{
    public WorkSelector()
    {
        m_nodes.Add(new PickJobSequence());
        m_nodes.Add(new AddJobSelector());
    }
}
