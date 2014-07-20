using System;
using System.Text;
using System.Collections.Generic;
using LicencjatInformatyka_RMSE_.Additional;
using LicencjatInformatyka_RMSE_.NewFolder5;
using LicencjatInformatyka_RMSE_.OperationsOnBases;
using NUnit;
using NUnit.Framework;
using LicencjatInformatyka_RMSE_;

namespace Testy
{
    /// <summary>
    /// Summary description for ContradictionTests
    /// </summary>
    [TestFixture]
    public class ContradictionTests
    {
        GatheredBases bases = new GatheredBases();
        public ContradictionTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

       

        [Test]
        public void TestOutsideContradictionMethod()
        {
            Contradiction.CheckOutsideContradiction(bases);
        }
    }
}
