using System;
using System.Collections.Generic;
using System.Text;

namespace Emmers
{
    interface IContainerTransferable
    {
        void TransferContents(Container container, int amount);
    }
}
