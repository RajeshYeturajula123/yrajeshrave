using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Inspec.BusinessDataAccess.GetNextTask;

namespace GetNextTest1
{
        public partial class _Default : Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                TaskDS ds = new TaskDS();
                string entityType = "";
                int entityId = 0;
                string functionType = "";
                int lockId = 0;
                DateTime lockAcquired = DateTime.Now;
                DateTime lockExpired = DateTime.Now;
                int itemId = 0;
                int entityIdForMin = 0;
                string refFunctionType = "";
                int userId = 0;
                int stealLockId = 0;
                DateTime stealLockAcquired = DateTime.Now;
                DateTime StealLockTimeout = DateTime.Now;

                ds.wkfproGetNextTask(null, 1, "CE626054-7344-4810-977A-1697E5E2153A", out entityType, out entityId, out functionType, out lockId, out lockAcquired, out lockExpired);
                ShowOutPutValueForwkfproGetNextTask(entityType, entityId, functionType, lockId, lockAcquired, lockExpired);

                ds.wkfconItemIDFromMIN(null, "A000", "FI64-B3001", out itemId);
                ShowOutPutValueForwkfconItemIDFromMIN(itemId);

                ds.wkfconPublicationIDFromMIN(null, "FI64-B3001", out entityIdForMin);
                ShowOutPutValueForwkfconPublicationIDFromMIN(entityIdForMin);

                ds.wkfconFunctionTypeNameFromID(null, 1, out refFunctionType);
                ShowOutPutValueForwkfconFunctionTypeNameFromID(refFunctionType);

                ds.fralokLockSteal(null, 0, "", "", "", userId, "CE626054-7344-4810-977A-1697E5E2153A", 0, out stealLockId, out stealLockAcquired, out StealLockTimeout);
                ShowOutPutValueForfralokLockSteal(stealLockId, stealLockAcquired, StealLockTimeout);

                ds.sysxmlBundleRead(null, 0, 0, 0, "", "");

                ds.fralokLockReleaseAllForUser(null, userId);

            }

            public void ShowOutPutValueForwkfproGetNextTask(string entityType, int entityId, string functionType, int lockId, DateTime lockAcquired, DateTime lockExpired)
            {
                lblentityType.Text = entityType;
                lblentityId.Text = Convert.ToString(entityId);
                lblfunctionType.Text = functionType;
                lbllockId.Text = Convert.ToString(lockId);
                lbllockAcquired.Text = lockAcquired.ToString();
                lbllockExpired.Text = lockExpired.ToString();
            }

            public void ShowOutPutValueForwkfconItemIDFromMIN(int itemId)
            {
                lblitemId.Text = Convert.ToString(itemId);
            }


            public void ShowOutPutValueForwkfconPublicationIDFromMIN(int entityIdForMin)
            {
                lblentityIdForMin.Text = Convert.ToString(entityIdForMin);
            }

            public void ShowOutPutValueForwkfconFunctionTypeNameFromID(string refFunctionType)
            {
                lblRefFunctionType.Text = refFunctionType;
            }

            public void ShowOutPutValueForfralokLockSteal(int stealLockId, DateTime stealLockAcquired, DateTime StealLockTimeout)
            {
                lblstealLockId.Text = Convert.ToString(stealLockId);
                lblstealLockAcquired.Text = stealLockAcquired.ToString();
                lblStealLockTimeout.Text = StealLockTimeout.ToString();
            }
        }
}