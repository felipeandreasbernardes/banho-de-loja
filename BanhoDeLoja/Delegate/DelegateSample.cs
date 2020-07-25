using System;
using System.Collections.Generic;
using System.Text;

//https://docs.microsoft.com/pt-br/dotnet/api/system.delegate?view=netcore-3.1

namespace BanhoDeLoja.Delegate
{
    public class DelegateSample
    {
        public delegate String myMethodDelegate(int myInt);

        // Defines some methods to which the delegate can point.
        public class mySampleClass
        {

            // Defines an instance method.
            public String myStringMethod(int myInt)
            {
                if (myInt > 0)
                    return ("positive");
                if (myInt < 0)
                    return ("negative");
                return ("zero");
            }

            // Defines a static method.
            public static String mySignMethod(int myInt)
            {
                if (myInt > 0)
                    return ("+");
                if (myInt < 0)
                    return ("-");
                return ("");
            }
        }
    }
}
