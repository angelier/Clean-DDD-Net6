using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Enums
{
    /// <summary>
    /// Tipos de inyección de los servicios
    /// </summary>
    public enum EServices
    {
        None,
        Singleton,
        Scope,
        Transient
    }
}
