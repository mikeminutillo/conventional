using System;

namespace Conventional
{
    static class Guard
    {
        public static void IsNotNull(object paramValue, string paramName)
        {
            if (paramValue == null)
                throw new ArgumentNullException(paramName);
        }
    }
}
