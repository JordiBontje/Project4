using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Memento_Design_Pattern
{
    public class Caretaker
    {
        public List<Memento> mementoList = new List<Memento>();
        

        public void add(Memento state)
        {
            mementoList[0] = state;

        }

        public Memento get()
        {
            return mementoList[0];
        }
    }
}
