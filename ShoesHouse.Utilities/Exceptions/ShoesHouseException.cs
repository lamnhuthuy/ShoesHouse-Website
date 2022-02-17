using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesHouse.Utilities.Exceptions
{
    public class ShoesHouseException : Exception
    {
        public ShoesHouseException()
        {
        }

        public ShoesHouseException(string message)
            : base(message)
        {
        }

        public ShoesHouseException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
