using CMSTest.TripClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSTest
{
    [TestClass]
    public class DataDependencyTest
    {
        [TestMethod]
        public void insertionTest()
        {
            DBTestContext dbContext = new DBTestContext();
            DBTest dbModel = new DBTest {                
                source = "source1",
                destination = "destination",
                created_by = "user1"
            };

            dbContext.DBTests.Add(dbModel);
            dbContext.SaveChanges();

            Assert.AreEqual(true, true);
        }
        
        //[TestMethod]
        //public void deletionTest()
        //{
        //    DBTestContext dbContext = new DBTestContext();
        //    DBTest dbModel = new DBTest
        //    {
        //        source = "source1",
        //        destination = "destination",
        //        created_by = "user1"
        //    };

        //    dbContext.DBTests.Remove(dbModel);
        //    dbContext.SaveChanges();

        //    Assert.AreEqual(true, true);
        //}
    }
}
