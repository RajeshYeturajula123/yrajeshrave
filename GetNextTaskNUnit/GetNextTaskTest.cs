using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inspec.BusinessDataAccess.GetNextTask;
using NUnit.Framework;

namespace GetNextTaskNUnit
{
    [TestFixture]
    public class GetNextTaskTest
    {
        TaskDS taskDS = new TaskDS();
        [Test]
        public void wkfproGetNextTask()
        {
            string entityType = "";
            int entityId = 0;
            string functionType = "";
            int lockId = 0;
            DateTime lockAcquired = DateTime.Now;
            DateTime lockExpired = DateTime.Now;
            try
            {
                taskDS.wkfproGetNextTask(null, 1, "CE626054-7344-4810-977A-1697E5E2153A", out entityType, out entityId, out functionType, out lockId, out lockAcquired, out lockExpired);

                Assert.AreNotEqual("", entityType);
                Assert.IsNotNull(entityId);
                Assert.AreNotEqual("", functionType);
                Assert.IsNotNull(lockId);
                Assert.IsNotNull(lockAcquired);
                Assert.IsNotNull(lockExpired);
            }
            catch (ArgumentNullException an)
            {
                Assert.AreEqual("Parameter cannot be null or empty.", an.Message);
            }
            catch (AssertionException ae)
            {
                Assert.Fail(string.Format("Unexpected exception of type {0} caught: {1}",
                            ae.GetType(), ae.Message));
            }
            catch (Exception e)
            {
                Assert.Fail(string.Format("Unexpected exception of type {0} caught: {1}",
                            e.GetType(), e.Message));
            }
            
        }		
		
		[Test]
        public void wkfconItemIDFromMIN()
        {
            int itemId = 0; 
            try
            {
				taskDS.wkfconItemIDFromMIN(null, "A000", "FI64-B3001", out itemId);
                
                Assert.IsNotNull(itemId);
            }
            catch (ArgumentNullException an)
            {
                Assert.AreEqual("Parameter cannot be null or empty.", an.Message);
            }
            catch (AssertionException ae)
            {
                Assert.Fail(string.Format("Unexpected exception of type {0} caught: {1}",
                            ae.GetType(), ae.Message));
            }
            catch(Exception e)
            {
                Assert.Fail(string.Format("Unexpected exception of type {0} caught: {1}",
                            e.GetType(), e.Message));
            }
        }
		
		[Test]
        public void wkfconPublicationIDFromMIN()
        {
            int entityIdForMin = 0;
            try
            {
				taskDS.wkfconPublicationIDFromMIN(null, "FI64-B3001", out entityIdForMin);				
                
                Assert.IsNotNull(entityIdForMin);
            }
            catch (ArgumentNullException an)
            {
                Assert.AreEqual("Parameter cannot be null or empty.", an.Message);
            }
            catch (AssertionException ae)
            {
                Assert.Fail(string.Format("Unexpected exception of type {0} caught: {1}",
                            ae.GetType(), ae.Message));
            }
            catch(Exception e)
            {
                Assert.Fail(string.Format("Unexpected exception of type {0} caught: {1}",
                            e.GetType(), e.Message));
            }
        }
		
		[Test]
        public void wkfconFunctionTypeNameFromID()
        {
            string refFunctionType="";
            try
            {
				taskDS.wkfconFunctionTypeNameFromID(null, 1, out refFunctionType);

                Assert.AreNotEqual("", refFunctionType);
            }
            catch (ArgumentNullException an)
            {
                Assert.AreEqual("Parameter cannot be null or empty.", an.Message);
            }
            catch (AssertionException ae)
            {
                Assert.Fail(string.Format("Unexpected exception of type {0} caught: {1}",
                            ae.GetType(), ae.Message));
            }
            catch(Exception e)
            {
                Assert.Fail(string.Format("Unexpected exception of type {0} caught: {1}",
                            e.GetType(), e.Message));
            }
        }
		
		[Test]
        public void fralokLockSteal()
        {
			int userId=0;
            int stealLockId = 0;
            DateTime stealLockAcquired = DateTime.Now;
            DateTime StealLockTimeout = DateTime.Now; 
            try
            {
				taskDS.fralokLockSteal(null, 0, "", "", "", userId, "CE626054-7344-4810-977A-1697E5E2153A", 0, out stealLockId, out stealLockAcquired, out StealLockTimeout);
			                
				Assert.IsNotNull(userId);
				Assert.IsNotNull(stealLockId);
                Assert.IsNotNull(stealLockAcquired);
                Assert.IsNotNull(StealLockTimeout);
            }
            catch (ArgumentNullException an)
            {
                Assert.AreEqual("Parameter cannot be null or empty.", an.Message);
            }
            catch (AssertionException ae)
            {
                Assert.Fail(string.Format("Unexpected exception of type {0} caught: {1}",
                            ae.GetType(), ae.Message));
            }
            catch(Exception e)
            {
                Assert.Fail(string.Format("Unexpected exception of type {0} caught: {1}",
                            e.GetType(), e.Message));
            }
        }

        [Test]
		public void sysxmlBundleRead()
        {
            try
            {
				taskDS.sysxmlBundleRead(null, 0, 0, 0, "", "");			                
				
            }
            catch (ArgumentNullException an)
            {
                Assert.AreEqual("Parameter cannot be null or empty.", an.Message);
            }
            catch (AssertionException ae)
            {
                Assert.Fail(string.Format("Unexpected exception of type {0} caught: {1}",
                            ae.GetType(), ae.Message));
            }
            catch(Exception e)
            {
                Assert.Fail(string.Format("Unexpected exception of type {0} caught: {1}",
                            e.GetType(), e.Message));
            }
        }

        [Test]
		public void fralokLockReleaseAllForUser()
        {
			int userId=0;    
            try
            {
				taskDS.fralokLockReleaseAllForUser(null, userId);				
				
				Assert.IsNotNull(userId);
				
            }
            catch (ArgumentNullException an)
            {
                Assert.AreEqual("Parameter cannot be null or empty.", an.Message);
            }
            catch (AssertionException ae)
            {
                Assert.Fail(string.Format("Unexpected exception of type {0} caught: {1}",
                            ae.GetType(), ae.Message));
            }
            catch(Exception e)
            {
                Assert.Fail(string.Format("Unexpected exception of type {0} caught: {1}",
                            e.GetType(), e.Message));
            }
        }
    }
}
