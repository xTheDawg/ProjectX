﻿public class HungerSelector : Selector
{
    public HungerSelector()
    {
        m_nodes.Add(new CheckHungerBarAction());
        m_nodes.Add(new ReplenishHungerSelector());
    }
}
