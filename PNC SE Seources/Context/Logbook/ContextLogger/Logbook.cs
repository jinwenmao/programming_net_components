// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Reflection;

namespace ContextLogger 
{
   public class Logbook : Component
   {
      private SqlConnection m_Connection;
      private SqlCommand m_SelectCommand;
      private SqlCommand m_InsertCommand;
      private SqlCommand m_UpdateCommand;
      private SqlCommand m_DeleteCommand;
      private SqlDataAdapter m_EntriesAdapter;
      private ContextLogger.EntriesDataSet m_EntriesDataSet;
      int m_EntryNumber = 0;

      //Logbook should be used as a singleton 
      public override object InitializeLifetimeService()
      {
         return null;
      }
	   public Logbook()
	   {
   	   InitializeComponent();
         m_EntriesAdapter.Fill(m_EntriesDataSet);
         m_EntryNumber = GetMaxEntry(m_EntriesDataSet);
	   }
      static int GetMaxEntry(EntriesDataSet entriesDataSet)
      {
         int max = 0;
         foreach(EntriesDataSet.EntriesRow row in entriesDataSet.Entries.Rows)
         {
            if(row.Entry > max)
            {
               max = row.Entry;
            }
         }
         return max;
      }
      public EntriesDataSet GetEntries()
      {
         EntriesDataSet tempDataSet;
         lock(this)
         {
            m_EntriesDataSet.Entries.Clear();
            m_EntriesAdapter.Fill(m_EntriesDataSet);
            tempDataSet = (EntriesDataSet)m_EntriesDataSet.Copy();
         }
         return tempDataSet;
      }
      public static void AddEvent(string description)
      {
         StackFrame frame = new StackFrame(1);
         
         string assemblyName = Assembly.GetCallingAssembly().GetName().Name;
         string typeName     = frame.GetMethod().DeclaringType.ToString();
         string methodName   = frame.GetMethod().Name;

         LogbookEntry logbookEntry = new LogbookEntry(assemblyName,typeName,methodName,description);
         Logbook logbook = new Logbook();
         logbook.AddEntry(logbookEntry);
      }
      public void AddEntry(LogbookEntry logbookEntry)
      {
         lock(this)
         {
            m_EntryNumber++;
            m_EntriesDataSet.Entries.AddEntriesRow(m_EntryNumber,
                                                   logbookEntry.MemberAccessed,
                                                   logbookEntry.TypeName,
                                                   logbookEntry.AssemblyName,
                                                   logbookEntry.Date,
                                                   logbookEntry.Time,
                                                   logbookEntry.MachineName,
                                                   logbookEntry.AppDomainName,
                                                   logbookEntry.ThreadID,
                                                   logbookEntry.ThreadName,
                                                   logbookEntry.ContextID,
                                                   logbookEntry.UserName,
                                                   logbookEntry.ExceptionName,
                                                   logbookEntry.ExceptionMessage,
                                                   logbookEntry.Event);
            m_EntriesAdapter.Update(m_EntriesDataSet.Entries);
         }
      }
      public void Clear()
      {
         lock(this)
         {
            m_Connection.Open();
            m_EntriesAdapter.DeleteCommand.ExecuteNonQuery();
            m_Connection.Close();
            m_EntriesDataSet.Entries.Clear();
            m_EntriesAdapter.Fill(m_EntriesDataSet.Entries);
            m_EntryNumber = 0;
         }
      }
 	   #region Component Designer generated code
	   /// <summary>
	   /// Required method for Designer support - do not modify
	   /// the contents of this method with the code editor.
	   /// </summary>
	   void InitializeComponent()
	   {
         this.m_SelectCommand = new System.Data.SqlClient.SqlCommand();
         this.m_Connection = new System.Data.SqlClient.SqlConnection();
         this.m_InsertCommand = new System.Data.SqlClient.SqlCommand();
         this.m_UpdateCommand = new System.Data.SqlClient.SqlCommand();
         this.m_DeleteCommand = new System.Data.SqlClient.SqlCommand();
         this.m_EntriesAdapter = new System.Data.SqlClient.SqlDataAdapter();
         this.m_EntriesDataSet = new ContextLogger.EntriesDataSet();
         ((System.ComponentModel.ISupportInitialize)(this.m_EntriesDataSet)).BeginInit();
         // 
         // m_SelectCommand
         // 
         this.m_SelectCommand.CommandText = "SELECT Entry, Machine, AppDomain, ThreadID, ThreadName, ContextID, [User], Assemb" +
            "ly, Type, MemberAccessed, Date, Time, ExceptionName, ExceptionMessage, Event FRO" +
            "M Entries";
         this.m_SelectCommand.Connection = this.m_Connection;
         // 
         // m_Connection
         // 
         this.m_Connection.ConnectionString = "data source=localhost;initial catalog=Logbook;integrated security=SSPI;persist se" +
            "curity info=True;workstation id=localhost;packet size=4096";
         // 
         // m_InsertCommand
         // 
         this.m_InsertCommand.CommandText = @"INSERT INTO Entries(Entry, Machine, AppDomain, ThreadID, ThreadName, ContextID, [User], Assembly, Type, MemberAccessed, Date, Time, ExceptionName, ExceptionMessage, Event) VALUES (@Entry, @Machine, @AppDomain, @ThreadID, @ThreadName, @ContextID, @Param1, @Assembly, @Type, @MemberAccessed, @Date, @Time, @ExceptionName, @ExceptionMessage, @Event); SELECT Entry, Machine, AppDomain, ThreadID, ThreadName, ContextID, [User], Assembly, Type, MemberAccessed, Date, Time, ExceptionName, ExceptionMessage, Event FROM Entries WHERE (Entry = @Entry)";
         this.m_InsertCommand.Connection = this.m_Connection;
         this.m_InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Entry", System.Data.SqlDbType.Int, 4, "Entry"));
         this.m_InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Machine", System.Data.SqlDbType.VarChar, 200, "Machine"));
         this.m_InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AppDomain", System.Data.SqlDbType.VarChar, 200, "AppDomain"));
         this.m_InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ThreadID", System.Data.SqlDbType.Int, 4, "ThreadID"));
         this.m_InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ThreadName", System.Data.SqlDbType.VarChar, 200, "ThreadName"));
         this.m_InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ContextID", System.Data.SqlDbType.Int, 4, "ContextID"));
         this.m_InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Param1", System.Data.SqlDbType.VarChar, 200, "User"));
         this.m_InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Assembly", System.Data.SqlDbType.VarChar, 200, "Assembly"));
         this.m_InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Type", System.Data.SqlDbType.VarChar, 200, "Type"));
         this.m_InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MemberAccessed", System.Data.SqlDbType.VarChar, 200, "MemberAccessed"));
         this.m_InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Date", System.Data.SqlDbType.VarChar, 10, "Date"));
         this.m_InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Time", System.Data.SqlDbType.VarChar, 10, "Time"));
         this.m_InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ExceptionName", System.Data.SqlDbType.VarChar, 200, "ExceptionName"));
         this.m_InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ExceptionMessage", System.Data.SqlDbType.VarChar, 200, "ExceptionMessage"));
         this.m_InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Event", System.Data.SqlDbType.VarChar, 1000, "Event"));
         // 
         // m_UpdateCommand
         // 
         this.m_UpdateCommand.CommandText = @"UPDATE Entries SET Entry = @Entry, Machine = @Machine, AppDomain = @AppDomain, ThreadID = @ThreadID, ThreadName = @ThreadName, ContextID = @ContextID, [User] = @Param2, Assembly = @Assembly, Type = @Type, MemberAccessed = @MemberAccessed, Date = @Date, Time = @Time, ExceptionName = @ExceptionName, ExceptionMessage = @ExceptionMessage, Event = @Event WHERE (Entry = @Original_Entry) AND (Assembly = @Original_Assembly) AND (ContextID = @Original_ContextID) AND (Date = @Original_Date) AND (Event = @Original_Event OR @Original_Event IS NULL AND Event IS NULL) AND (ExceptionMessage = @Original_ExceptionMessage OR @Original_ExceptionMessage IS NULL AND ExceptionMessage IS NULL) AND (ExceptionName = @Original_ExceptionName OR @Original_ExceptionName IS NULL AND ExceptionName IS NULL) AND (MemberAccessed = @Original_MemberAccessed) AND (ThreadID = @Original_ThreadID) AND (ThreadName = @Original_ThreadName OR @Original_ThreadName IS NULL AND ThreadName IS NULL) AND (Time = @Original_Time) AND (Type = @Original_Type) AND ([User] = @Original_User OR @Original_User IS NULL AND [User] IS NULL); SELECT Entry, Machine, AppDomain, ThreadID, ThreadName, ContextID, [User], Assembly, Type, MemberAccessed, Date, Time, ExceptionName, ExceptionMessage, Event FROM Entries WHERE (Entry = @Entry)";
         this.m_UpdateCommand.Connection = this.m_Connection;
         this.m_UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Entry", System.Data.SqlDbType.Int, 4, "Entry"));
         this.m_UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Machine", System.Data.SqlDbType.VarChar, 2147483647, "Machine"));
         this.m_UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AppDomain", System.Data.SqlDbType.VarChar, 2147483647, "AppDomain"));
         this.m_UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ThreadID", System.Data.SqlDbType.Int, 4, "ThreadID"));
         this.m_UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ThreadName", System.Data.SqlDbType.VarChar, 20, "ThreadName"));
         this.m_UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ContextID", System.Data.SqlDbType.Int, 4, "ContextID"));
         this.m_UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Param2", System.Data.SqlDbType.VarChar, 15, "User"));
         this.m_UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Assembly", System.Data.SqlDbType.VarChar, 25, "Assembly"));
         this.m_UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Type", System.Data.SqlDbType.VarChar, 35, "Type"));
         this.m_UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MemberAccessed", System.Data.SqlDbType.VarChar, 20, "MemberAccessed"));
         this.m_UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Date", System.Data.SqlDbType.VarChar, 10, "Date"));
         this.m_UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Time", System.Data.SqlDbType.VarChar, 10, "Time"));
         this.m_UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ExceptionName", System.Data.SqlDbType.VarChar, 20, "ExceptionName"));
         this.m_UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ExceptionMessage", System.Data.SqlDbType.VarChar, 200, "ExceptionMessage"));
         this.m_UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Event", System.Data.SqlDbType.VarChar, 100, "Event"));
         this.m_UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Entry", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Entry", System.Data.DataRowVersion.Original, null));
         this.m_UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Assembly", System.Data.SqlDbType.VarChar, 25, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Assembly", System.Data.DataRowVersion.Original, null));
         this.m_UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ContextID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContextID", System.Data.DataRowVersion.Original, null));
         this.m_UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Date", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Date", System.Data.DataRowVersion.Original, null));
         this.m_UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Event", System.Data.SqlDbType.VarChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Event", System.Data.DataRowVersion.Original, null));
         this.m_UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ExceptionMessage", System.Data.SqlDbType.VarChar, 200, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ExceptionMessage", System.Data.DataRowVersion.Original, null));
         this.m_UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ExceptionName", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ExceptionName", System.Data.DataRowVersion.Original, null));
         this.m_UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_MemberAccessed", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MemberAccessed", System.Data.DataRowVersion.Original, null));
         this.m_UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ThreadID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ThreadID", System.Data.DataRowVersion.Original, null));
         this.m_UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ThreadName", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ThreadName", System.Data.DataRowVersion.Original, null));
         this.m_UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Time", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Time", System.Data.DataRowVersion.Original, null));
         this.m_UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Type", System.Data.SqlDbType.VarChar, 35, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Type", System.Data.DataRowVersion.Original, null));
         this.m_UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_User", System.Data.SqlDbType.VarChar, 15, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "User", System.Data.DataRowVersion.Original, null));
         // 
         // m_DeleteCommand
         // 
         this.m_DeleteCommand.CommandText = "DELETE FROM Entries";
         this.m_DeleteCommand.Connection = this.m_Connection;
         // 
         // m_EntriesAdapter
         // 
         this.m_EntriesAdapter.DeleteCommand = this.m_DeleteCommand;
         this.m_EntriesAdapter.InsertCommand = this.m_InsertCommand;
         this.m_EntriesAdapter.SelectCommand = this.m_SelectCommand;
         this.m_EntriesAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
                                                                                                   new System.Data.Common.DataTableMapping("Table", "Entries", new System.Data.Common.DataColumnMapping[] {
                                                                                                                                                                                                             new System.Data.Common.DataColumnMapping("Entry", "Entry"),
                                                                                                                                                                                                             new System.Data.Common.DataColumnMapping("Machine", "Machine"),
                                                                                                                                                                                                             new System.Data.Common.DataColumnMapping("AppDomain", "AppDomain"),
                                                                                                                                                                                                             new System.Data.Common.DataColumnMapping("ThreadID", "ThreadID"),
                                                                                                                                                                                                             new System.Data.Common.DataColumnMapping("ThreadName", "ThreadName"),
                                                                                                                                                                                                             new System.Data.Common.DataColumnMapping("ContextID", "ContextID"),
                                                                                                                                                                                                             new System.Data.Common.DataColumnMapping("User", "User"),
                                                                                                                                                                                                             new System.Data.Common.DataColumnMapping("Assembly", "Assembly"),
                                                                                                                                                                                                             new System.Data.Common.DataColumnMapping("Type", "Type"),
                                                                                                                                                                                                             new System.Data.Common.DataColumnMapping("MemberAccessed", "MemberAccessed"),
                                                                                                                                                                                                             new System.Data.Common.DataColumnMapping("Date", "Date"),
                                                                                                                                                                                                             new System.Data.Common.DataColumnMapping("Time", "Time"),
                                                                                                                                                                                                             new System.Data.Common.DataColumnMapping("ExceptionName", "ExceptionName"),
                                                                                                                                                                                                             new System.Data.Common.DataColumnMapping("ExceptionMessage", "ExceptionMessage"),
                                                                                                                                                                                                             new System.Data.Common.DataColumnMapping("Event", "Event")})});
         this.m_EntriesAdapter.UpdateCommand = this.m_UpdateCommand;
         // 
         // m_EntriesDataSet
         // 
         this.m_EntriesDataSet.DataSetName = "EntriesDataSet";
         this.m_EntriesDataSet.Locale = new System.Globalization.CultureInfo("en-US");
         this.m_EntriesDataSet.Namespace = "http://www.tempuri.org/EntriesDataSet.xsd";
         ((System.ComponentModel.ISupportInitialize)(this.m_EntriesDataSet)).EndInit();

      }
	   #endregion
   }
}
