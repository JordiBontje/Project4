using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App2.Memento_Design_Pattern
{
    public class Originator
    {
        private Color state;

        public void setState(Color state)
        {
            this.state = state;
        }

        public Color getState()
        {
            return state;
        }

        public Memento saveStateToMemento()
        {
            return new Memento(state);
        }

        public void getStateFromMemento(Memento memento)
        {
            state = memento.getState();
        }
    }
}
