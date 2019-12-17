using System;
using System.Collections.Generic;
using System.Text;

namespace Emmers
{
    interface IContainer
    {
        void Fill(int amount);
        void Empty();
        void Empty(int amount);
    }
}
