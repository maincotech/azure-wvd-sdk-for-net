using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.WindowsWirtualDesktop.Models
{
    public class DiagnosticActivity : SerializableResource<DiagnosticActivity>
    {
        protected override string Serialize()
        {
            return Serialize(this);
        }
    }
}
