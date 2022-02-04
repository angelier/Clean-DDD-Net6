using Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Attributes
{
    /// <summary>
    /// Inyectable servicio para la anotación de los tipos de servicio (Singleton, Scope, Trasient)
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class InjectableServiceAttribute : Attribute
    {
        private readonly EServices TypeInjectable;

        public InjectableServiceAttribute(EServices type) => TypeInjectable = type;

        public EServices GetTypeInjectable() => TypeInjectable;
    }
}
