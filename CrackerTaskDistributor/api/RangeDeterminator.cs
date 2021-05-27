using CrackerTaskDistributor.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackerTaskDistributor.api
{
    public interface RangeDeterminator
    {
        public CrackPasswordRange GetAndIncrement(int chunkSize);
    }
}
