using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using Inspec.Common.Entity;
using Inspec.Common;
//using Inspec.Mercury.Workflow.Common.SchemaClasses.InspecIdeas;
//using Inspec.BusinessDataAccess;

namespace Inspec.Common.Entity
{
    public class GetTaskWork
    {
        /// <summary>
        /// Get a Task - if no specific entity is requested then the next available task for the user
        /// will be located and returned.
        /// </summary>
        /// <param name="nXlangBundle"></param>
        /// <returns></returns>

        public static GetTaskResponse GetTask(GetTaskRequest taskRequest)
        {
            DateTime startTime = DateTime.UtcNow;
            string entityType = "Volume";
            int entityId = -1;

            try
            {
                GetTaskResponse taskResponse = GetTask(taskRequest,
                    out entityType,
                    out entityId);

                return taskResponse;

            }
            catch (Exception ex)
            {
                entityType = "Volume";
                entityId = -1;
                XmlDocument doc = Inspec.Common.MessageProcessing.CreateResponseMessage(
                    "GetTaskResponse",
                    "http://www.inspec.org/ideas/xsd/wkf/control/gettaskresponse/v1",
                    ex.Message);

                GetTaskResponse taskResponse = SerializationUtils.DeserializeObject<GetTaskResponse>(doc);
                return taskResponse;
            }
            //catch (BusinessProcessException ex)
            //{
            //    entityType = "Volume";
            //    entityId = -1;
            //    XmlDocument doc = Inspec.Mercury.Workflow.Common.Components.MessageProcessing.CreateResponseMessage(
            //        "GetTaskResponse",
            //        "http://www.inspec.org/ideas/xsd/wkf/control/gettaskresponse/v1",
            //        Inspec.Mercury.Workflow.Common.Components.ExceptionProcessing.GetExceptionCode(ex));

            //    GetTaskResponse taskResponse = SerializationUtils.DeserializeObject<GetTaskResponse>(doc);
            //    return taskResponse;
            //}
            //finally
            //{
            //    Inspec.Ideas.Logging.IdeasLogger.Write(
            //        entityType,
            //        entityId,
            //        System.String.Format("GNT : {0}", System.DateTime.UtcNow.Subtract(startTime)),
            //        Inspec.Ideas.Logging.IdeasLogger.IdeasLogCategories.PersistenceController,
            //        Inspec.Ideas.Logging.IdeasLogger.IdeasLogPriorities.Low);
            //}

        }

        private static GetTaskResponse GetTask(GetTaskRequest taskRequest, out string entityType, out int entityId)
        {
            bool taskFound = false;

            entityType = string.Empty;
            entityId = -1;
            string functionType = string.Empty;
            int lockId = -1;
            DateTime lockAcquired = DateTime.MinValue;
            DateTime lockRelease = DateTime.MinValue;

            try
            {
                if (taskRequest.Body.SpecificEntity == null)
                {
                    //DataTier.wkfproGetNextTask(null, taskRequest.Header.UserId,
                    //    new Guid(taskRequest.Header.SessionId),
                    //    out entityType,
                    //    out entityId,
                    //    out functionType,
                    //    out lockId,
                    //    out lockAcquired,
                    //    out lockRelease);
                }
                else if (taskRequest.Body.SpecificEntity != null)
                {
                    int functionTypeId = taskRequest.Body.SpecificEntity.FunctionTypeID;
                    entityId = taskRequest.Body.SpecificEntity.EntityID;
                    string entityMIN = taskRequest.Body.SpecificEntity.EntityMIN;
                    switch (taskRequest.Body.SpecificEntity.EntityType)
                    {
                        case GetTaskRequestBodySpecificEntityEntityType.Item:
                            entityType = "Source";
                            if (!string.IsNullOrEmpty(entityMIN))
                            {
                                //DataTier.wkfconItemIDFromMIN(null,
                                //    entityMIN.Substring(0, 10),
                                //    entityMIN.Substring(11, 4),
                                //    out entityId);
                            }
                            break;
                        case GetTaskRequestBodySpecificEntityEntityType.Batch:
                            entityType = "Batch";
                            if (!string.IsNullOrEmpty(entityMIN))
                            {
                                //DataTier.wkfconBatchIDFromMIN(null,
                                //    entityMIN.Substring(0, 10),
                                //    int.Parse(entityMIN.Substring(11)),
                                //    out entityId);
                            }
                            break;
                        case GetTaskRequestBodySpecificEntityEntityType.Publication:
                            entityType = "Volume";
                            if (!string.IsNullOrEmpty(entityMIN))
                            {
                                //DataTier.wkfconPublicationIDFromMIN(null,
                                //   entityMIN,
                                //   out entityId);
                            }
                            break;
                        default:
                            break;
                    }

                    if ((entityId > 0) && (functionTypeId > 0))
                    {
                        //DataTier.wkfconFunctionTypeNameFromID(null, functionTypeId, out functionType);

                        //DataTier.fralokLockSteal(null, entityId,
                        //    entityType, "Get Specific Task", "Standard",
                        //    taskRequest.Header.UserId,
                        //    new Guid(taskRequest.Header.SessionId), functionTypeId,
                        //    out lockId, out lockAcquired, out lockRelease);
                    }
                }
            }
            catch (Exception)
            {
                lockId = 0;
                taskFound = false;
            }

            if (lockId > 0)
            {
                taskFound = true;
            }

            if (taskFound)
            {
                GetTaskResponse taskResponse = new GetTaskResponse();
                taskResponse.Header = new GetTaskResponseHeader();
                taskResponse.Header.Status = GetTaskResponseHeaderStatus.Success;
                taskResponse.Body = new GetTaskResponseBody();
                taskResponse.Body.Task = new GetTaskResponseBodyTask();
                taskResponse.Body.Task.Lock = new GetTaskResponseBodyTaskLock();
                taskResponse.Body.Task.Lock.LockId = lockId;
                taskResponse.Body.Task.Lock.LockAcquiredDateTime = lockAcquired;
                taskResponse.Body.Task.Lock.LockTimeoutDateTime = lockRelease;
                taskResponse.Body.Task.FunctionType = functionType;

                int publicationId = 0;
                int sourceId = 0;
                int batchId = 0;

                if (entityType == "Volume")
                {
                    publicationId = entityId;
                }
                else if (entityType == "Batch")
                {
                    batchId = entityId;
                    publicationId = -1;
                }
                else
                {
                    sourceId = entityId;
                }

                //string data = DataTier.sysxmlBundleRead(null, publicationId, batchId, sourceId, "GetNextTask", functionType);
                //taskResponse.Body.Bundle = SerializationUtils.DeserializeObject<Bundle>(data);
                return taskResponse;
            }
            else
            {
                //DataTier.fralokLockReleaseAllForUser(null, taskRequest.Header.UserId);
            }

            //throw Inspec.Mercury.Workflow.Common.Components.BusinessProcessExceptionFactory.CreateException(
            //    "Production_NoTaskInQueue",
            //    Inspec.Mercury.Workflow.Common.Components.WorkflowExceptionCategory.Warning);

            throw new System.ArgumentException();
        }
    }
}