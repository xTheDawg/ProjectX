using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickJobSequence : Sequence
{
    public PickJobSequence() {
            m_nodes.Add(new CheckJobListAction());
            m_nodes.Add(new DoJobAction());            
    }
}
