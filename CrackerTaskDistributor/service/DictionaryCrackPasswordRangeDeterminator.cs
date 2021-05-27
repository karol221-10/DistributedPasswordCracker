using CrackerTaskDistributor.api;
using CrackerTaskDistributor.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CrackerTaskDistributor.service
{
    class DictionaryCrackPasswordRangeDeterminator : RangeDeterminator
    {
        private Mutex mutex = new Mutex();
        private BigInteger counter = new BigInteger(0);

        public CrackPasswordRange GetAndIncrement(int chunkSize)
        {
            mutex.WaitOne();
            CrackPasswordRange crackPasswordRange = new CrackPasswordRange();
            crackPasswordRange.startPointer = counter.ToString();
            counter += chunkSize;
            crackPasswordRange.endPointer = counter.ToString();
            mutex.Close();
            return crackPasswordRange;
        }
    }
}
