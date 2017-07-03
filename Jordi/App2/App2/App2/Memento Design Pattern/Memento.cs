using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App2.Memento_Design_Pattern
{
    public class Memento
    {
        private Color state;

        public Memento(Color state)
        {
            this.state = state;
        }

        public Color getState()
        {
            return state;
        }
    }
}
