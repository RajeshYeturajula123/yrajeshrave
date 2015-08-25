using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Diagnostics;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using Inspec.BusinessDataAccess.Base;
using Inspec.Common;
using Inspec.BusinessDataAccess.DataTier;


namespace Inspec.BusinessDataAccess.GetNextTask
{
    public class TaskDS : BaseDS
    {
        public void wkfproGetNextTask(DbTransaction tran,int userId, string sessionID, out string entityType, out int entityId, out string functionType, out int lockId, out DateTime lockAcquired, out DateTime lockExpired)
        {
            string spName = "";
            try
            {
                spName = "wkfproGetNextTask";
                DbCommand dbCommand = base.DB.GetStoredProcCommand(spName);

                dbCommand.Parameters.Clear();
                base.DB.AddInParameter(dbCommand, "@UserId", DbType.Int64, userId);
                base.DB.AddInParameter(dbCommand, "@SessionId", DbType.String, sessionID);
                base.DB.AddOutParameter(dbCommand, "@EntityType", DbType.String, 1);
                base.DB.AddOutParameter(dbCommand, "@EntityId", DbType.Int64, 0);
                base.DB.AddOutParameter(dbCommand, "@FunctionType", DbType.String, 1);
                base.DB.AddOutParameter(dbCommand, "@LockId", DbType.Int64, 0);
                base.DB.AddOutParameter(dbCommand, "@LockAcquiredDateTime", DbType.DateTime, 0);
                base.DB.AddOutParameter(dbCommand, "@LockTimeoutDateTime", DbType.DateTime, 0);

                if (tran != null)
                {
                    base.DB.ExecuteNonQuery(dbCommand, tran);
                }
                else
                {
                    base.DB.ExecuteNonQuery(dbCommand);
                }

                entityType = DataReaderHelper.GetString(base.DB.GetParameterValue(dbCommand, "@EntityType"));
                entityId = DataReaderHelper.GetInt(base.DB.GetParameterValue(dbCommand, "@EntityId"));
                functionType = DataReaderHelper.GetString(base.DB.GetParameterValue(dbCommand, "@FunctionType"));
                lockId = DataReaderHelper.GetInt(base.DB.GetParameterValue(dbCommand, "@LockId"));
                lockAcquired = DataReaderHelper.GetDateTime(base.DB.GetParameterValue(dbCommand, "@LockAcquiredDateTime"));
                lockExpired = DataReaderHelper.GetDateTime(base.DB.GetParameterValue(dbCommand, "@LockTimeoutDateTime"));
            }
            catch (SqlException ex)
            {
                throw new DacSqlException(ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                base.ReleaseConnection();
            }
        }

        public void wkfconItemIDFromMIN(DbTransaction tran, string min, string minItem, out int itemId)
        {
            string spName = "";
            try
            {
                spName = "wkfconItemIDFromMIN";
                DbCommand dbCommand = base.DB.GetStoredProcCommand(spName);

                dbCommand.Parameters.Clear();
                base.DB.AddInParameter(dbCommand, "@Min", DbType.String, min);
                base.DB.AddInParameter(dbCommand, "@MinItem", DbType.String, minItem);
                base.DB.AddOutParameter(dbCommand, "@ItemId", DbType.Int32, 0);

                if (tran != null)
                {
                    base.DB.ExecuteNonQuery(dbCommand, tran);
                }
                else
                {
                    base.DB.ExecuteNonQuery(dbCommand);
                }

                itemId = DataReaderHelper.GetInt(base.DB.GetParameterValue(dbCommand, "@ItemId"));                
            }
            catch (SqlException ex)
            {
                throw new DacSqlException(ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                base.ReleaseConnection();
            }
        }


        public void wkfconPublicationIDFromMIN(DbTransaction tran, string entityMIN, out int entityId)
        {
            string spName = "";
            try
            {
                spName = "wkfconPublicationIDFromMIN";
                DbCommand dbCommand = base.DB.GetStoredProcCommand(spName);

                dbCommand.Parameters.Clear();
                base.DB.AddInParameter(dbCommand, "@Min", DbType.String, entityMIN);
                base.DB.AddOutParameter(dbCommand, "@PublicationId", DbType.Int32, 0);

                if (tran != null)
                {
                    base.DB.ExecuteNonQuery(dbCommand, tran);
                }
                else
                {
                    base.DB.ExecuteNonQuery(dbCommand);
                }

                entityId = DataReaderHelper.GetInt(base.DB.GetParameterValue(dbCommand, "@PublicationId"));
            }
            catch (SqlException ex)
            {
                throw new DacSqlException(ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                base.ReleaseConnection();
            }
        }

        public void wkfconFunctionTypeNameFromID(DbTransaction tran, int functionTypeId, out string functionType)
        {
            string spName = "";
            try
            {
                spName = "wkfconFunctionTypeNameFromID";
                DbCommand dbCommand = base.DB.GetStoredProcCommand(spName);

                dbCommand.Parameters.Clear();
                base.DB.AddInParameter(dbCommand, "@ID", DbType.Int32, functionTypeId);
                base.DB.AddOutParameter(dbCommand, "@Name", DbType.String, 1);

                if (tran != null)
                {
                    base.DB.ExecuteNonQuery(dbCommand, tran);
                }
                else
                {
                    base.DB.ExecuteNonQuery(dbCommand);
                }

                functionType = DataReaderHelper.GetString(base.DB.GetParameterValue(dbCommand, "@Name"));
            }
            catch(SqlException ex)
            {
                throw new DacSqlException(ex);
            }
            catch (System.Exception ex)
            {
                throw;
            }            
            finally
            {
                base.ReleaseConnection();
            }
        }

        public void fralokLockSteal(DbTransaction tran, int entityId, string entityType, string lockContext, string lockTimeoutType, int userId, string sessionId, int functionTypeId, out int lockId, out DateTime lockAcquired, out DateTime lockTimeout)
        {
            string spName = "";
            try
            {
                spName = "fralokLockSteal";
                DbCommand dbCommand = base.DB.GetStoredProcCommand(spName);

                dbCommand.Parameters.Clear();
                base.DB.AddInParameter(dbCommand, "@ObjectId", DbType.Int32, entityId);
                base.DB.AddInParameter(dbCommand, "@ObjectType", DbType.String, entityType);
                base.DB.AddInParameter(dbCommand, "@LockContext", DbType.String, lockContext);
                base.DB.AddInParameter(dbCommand, "@LockTimeOutType", DbType.String, lockTimeoutType);
                base.DB.AddInParameter(dbCommand, "@UserId", DbType.Int32, userId);
                base.DB.AddInParameter(dbCommand, "@SessionId", DbType.String, sessionId);
                base.DB.AddInParameter(dbCommand, "@FunctionTypeId", DbType.Int32, functionTypeId);
                base.DB.AddOutParameter(dbCommand, "@LockId", DbType.Int32, 0);
                base.DB.AddOutParameter(dbCommand, "@LockAcquiredDateTime", DbType.DateTime, 0);
                base.DB.AddOutParameter(dbCommand, "@LockTimeoutDateTime", DbType.DateTime, 0);

                if (tran != null)
                {
                    base.DB.ExecuteNonQuery(dbCommand, tran);
                }
                else
                {
                    base.DB.ExecuteNonQuery(dbCommand);
                }

                lockId = DataReaderHelper.GetInt(base.DB.GetParameterValue(dbCommand, "@LockId"));
                lockAcquired = DataReaderHelper.GetDateTime(base.DB.GetParameterValue(dbCommand, "@LockAcquiredDateTime"));
                lockTimeout = DataReaderHelper.GetDateTime(base.DB.GetParameterValue(dbCommand, "@LockTimeoutDateTime"));
            }
            catch (SqlException ex)
            {
                throw new DacSqlException(ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                base.ReleaseConnection();
            }
        }


        public void sysxmlBundleRead(DbTransaction tran, int publicationId, int batchId, int sourceId, string filterRequestType, string filterRequestOperation)
        {
            string spName = "";
            try
            {
                spName = "sysxmlBundleRead";
                DbCommand dbCommand = base.DB.GetStoredProcCommand(spName);

                dbCommand.Parameters.Clear();
                base.DB.AddInParameter(dbCommand, "@PublicationId", DbType.Int32, publicationId);
                base.DB.AddInParameter(dbCommand, "@BatchId", DbType.Int32, batchId);
                base.DB.AddInParameter(dbCommand, "@SourceId", DbType.Int32, sourceId);
                base.DB.AddInParameter(dbCommand, "@FilterRequestType", DbType.String, filterRequestType);
                base.DB.AddInParameter(dbCommand, "@FilterRequestOperation", DbType.String, filterRequestOperation);

                if (tran != null)
                {
                    base.DB.ExecuteNonQuery(dbCommand, tran);
                }
                else
                {
                    base.DB.ExecuteNonQuery(dbCommand);
                }
            }
            catch (SqlException ex)
            {
                throw new DacSqlException(ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                base.ReleaseConnection();
            }
        }

        public void fralokLockReleaseAllForUser(DbTransaction tran, int userId)
        {
            string spName = "";
            try
            {
                spName = "fralokLockReleaseAllForUser";
                DbCommand dbCommand = base.DB.GetStoredProcCommand(spName);

                dbCommand.Parameters.Clear();
                base.DB.AddInParameter(dbCommand, "@UserId", DbType.Int32, userId);

                if (tran != null)
                {
                    base.DB.ExecuteNonQuery(dbCommand, tran);
                }
                else
                {
                    base.DB.ExecuteNonQuery(dbCommand);
                }
            }
            catch (SqlException ex)
            {
                throw new DacSqlException(ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                base.ReleaseConnection();
            }
        }
    }
}
