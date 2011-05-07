using System;

namespace Conventional
{
    class Registration
    {
        public Registration(Type conventionType, Type scannedType)
        {
            ConventionType = conventionType;
            ScannedType = scannedType;
        }

        public Type ConventionType { get; private set; }

        public Type ScannedType { get; private set; }
    }
}