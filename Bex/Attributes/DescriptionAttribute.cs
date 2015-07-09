using System;

namespace Bex.Attributes
{
    internal class Description : Attribute
    {
        public string Text;

        public Description(string text)
        {
            Text = text;
        }
    }
}
