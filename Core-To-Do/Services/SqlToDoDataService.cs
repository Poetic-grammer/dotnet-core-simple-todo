using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core_To_Do.Models;
using System.Data;
using Microsoft.Extensions.Options;
using Core_To_Do.Settings;

namespace Core_To_Do.Services
{
    public class SqlToDoDataService : IToDoDataService
    {
        private SqlSettings sqlOptions;

        public SqlToDoDataService(IOptions<SqlSettings> options)
        {
            sqlOptions = options.Value;
        }
        public ToDoItemModel AddToDo(string label)
        {
            ToDoItemModel toDoItem = new ToDoItemModel();
            using (SqlConnection sqlConn = new SqlConnection(sqlOptions.SqlConnectionString))
            using (SqlCommand comm = new SqlCommand("AddToDo", sqlConn))
            {
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("label", label));
                sqlConn.Open();
                SqlDataReader dr = comm.ExecuteReader();

                dr.Read();
                toDoItem.id = dr.GetInt32(0);
                toDoItem.label = dr.GetString(1);
                toDoItem.completed = dr.GetBoolean(2);
                dr.Close();
            }

            
            return toDoItem;
        }

        public bool DeleteToDo(int id)
        {
            int rowsChanged = -1;
            using (SqlConnection sqlConn = new SqlConnection(sqlOptions.SqlConnectionString))
            using (SqlCommand comm = new SqlCommand("DeleteToDo", sqlConn))
            {
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("targetId", id));
                comm.Parameters.Add(new SqlParameter("numDeleted",SqlDbType.Int));
                comm.Parameters["numDeleted"].Direction = ParameterDirection.Output;
                sqlConn.Open();
                rowsChanged = comm.ExecuteNonQuery();
                
            }

            if (rowsChanged < 0)
            {
                throw new Exception("Error in processing Delete request.");
            }

            if (rowsChanged > 0)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public IEnumerable<ToDoItemModel> ListToDos()
        {
            List<ToDoItemModel> itemModels = new List<ToDoItemModel>();
            using (SqlConnection sqlConn = new SqlConnection(sqlOptions.SqlConnectionString))
            using (SqlCommand comm = new SqlCommand("ListToDos", sqlConn))
            {
                comm.CommandType = CommandType.StoredProcedure;
                sqlConn.Open();
                var dr = comm.ExecuteReader();
                while (dr.Read())
                {

                    ToDoItemModel current = new ToDoItemModel();

                    current.id = dr.GetInt32(0);
                    current.label = dr.GetString(1);
                    current.completed = dr.GetBoolean(2);
                    itemModels.Add(current);
                }
            }

            return itemModels;
        }

        public bool MarkCompleteToDo(int id)
        {
            int rowsChanged = -1;
            using (SqlConnection sqlConn = new SqlConnection(sqlOptions.SqlConnectionString))
            using (SqlCommand comm = new SqlCommand("MarkCompleteToDo", sqlConn))
            {
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("targetId", id));
                comm.Parameters.Add("numRows", SqlDbType.Int);
                comm.Parameters["numRows"].Direction = ParameterDirection.Output;
                sqlConn.Open();
                rowsChanged = comm.ExecuteNonQuery();

            }

            if (rowsChanged < 0)
            {
                throw new Exception("Error in processing update request.");
            }

            if (rowsChanged > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
