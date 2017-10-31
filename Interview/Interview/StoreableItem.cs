using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interview
{
  public  class StoreableItem : IStoreable
    {
        public IComparable Id { get; set; }
        public string Name { get; set; }
    }
}
