using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspec.BusinessDataAccess.Base
{    
    public class BaseDS
    {
        #region "Properties"

        // Declare private variables to hold the database object.
        private static Database db;
        private static object lockThis = new object();
        //public Database DB { get; private set; }
        public DbConnection Connection { get; private set; }
        public DbTransaction Transaction { get; private set; }

        #endregion


        #region "Public Constructor"

        /// <CommentsBlock>
        /// <MethodName>BaseDS</MethodName>      
        /// <Description>
        /// Default Constructor
        /// </Description>
        /// </CommentsBlock>
        public BaseDS()
        {
        }

        /// <CommentsBlock>
        /// <MethodName>BaseDS</MethodName>      
        /// <Description>
        /// Default Constructor
        /// </Description>
        /// </CommentsBlock>
        public BaseDS(DbTransaction transaction)
        {
            Transaction = transaction;
            Connection = transaction.Connection;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseDS"/> class.
        /// </summary>
        /// <param name="connectionStringSettings">The connection string settings.</param>
        public BaseDS(string connectionString)
        {
            db = new SqlDatabase(connectionString);            
        }

        /// <CommentsBlock>
        /// <MethodName>BaseDS</MethodName>      
        /// <Description>
        /// Static Constructor, Used to initialised the object once
        /// </Description>
        /// </CommentsBlock>
        static BaseDS()
        {
            try
            {
                lock (lockThis)
                {
                    if(db == null)
                        db = new DatabaseProviderFactory().Create("DataAccessQuickStart");
                }
            }
            catch (Exception ex) { throw ex; }
        }


        #endregion 

        
        #region Public Methods

        /// <CommentsBlock>
        /// <MethodName>GetConnection</MethodName>
        /// <Parameters>
        /// <Parameter type="" name=""></Parameter>        
        /// </Parameters>
        /// <returns>IDbConnection Type</returns> 
        /// <Description>
        /// It will create a connection object with the help of the DB object 
        /// which is part of Microsoft DataAccess Application Block.
        /// </Description>
        /// </CommentsBlock>
        public DbConnection GetConnection()
        {
            Connection = DB.CreateConnection();
            Connection.Open();
            return Connection;
        }


        /// <CommentsBlock>
        /// <MethodName>GetTransaction</MethodName>
        /// <Parameters>
        /// <Parameter type="" name=""></Parameter>        
        /// </Parameters>
        /// <returns>IDbTransaction Type</returns> 
        /// <Description>
        /// It will start a Transaction object on the connection object.
        /// </Description>
        /// </CommentsBlock>
        public DbTransaction GetTransaction()
        {
            Connection = GetConnection();
            Transaction = Connection.BeginTransaction();
            return Transaction;
        }

        #endregion Public Methods


        /// <CommentsBlock>
        /// <PropertyName>DB</PropertyName>
        /// <Description>
        /// Expose Database object of Microsoft DataAccess Application Block throgh DB propert.
        /// </Description>
        /// </CommentsBlock>
        public Database DB
        {
            set
            {
                db = value;
            }

            get
            {
                return db;
            }

        }

        /// <summary>
        /// <para><b>Function</b><c>ReleaseConnection</c></para>
        /// <para><br></br></para>
        /// <b>Purpose</b>
        /// <para>
        /// It will close the connection object.
        /// </para>
        /// </summary>
        /// <returns>Void</returns>		        
        protected void ReleaseConnection()
        {
            if (Connection != null)
            {
                Connection.Close();
            }
        }
    }
}
