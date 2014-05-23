using DevExpress.XtraEditors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using WarOfWordsLibrary.Classes.Constants;
using WarOfWordsLoader.Classes.Managers;

namespace WarOfWordsLibrary.Classes.Managers
{
    /// <summary>
    /// 数据库操作类。
    /// </summary>
    public class DataBaseManager
    {
        private string dataBaseUrl = "Dictionary.sqlite";
        public static SQLiteConnection connectionOfDataBase = null;

        /// <summary>
        /// 数据库操作类构造函数。
        /// </summary>
        public DataBaseManager()
        {
            try
            {
                string startPath = System.Windows.Forms.Application.StartupPath;
                dataBaseUrl = startPath + "\\" + dataBaseUrl;
                string connectionString = "Data Source =" + dataBaseUrl;
                if (connectionOfDataBase == null)
                {
                    connectionOfDataBase = new SQLiteConnection(connectionString);
                    connectionOfDataBase.Open();
                }
            }
            catch (Exception e)
            {
                LogManager.GlobalLogManager.CreateLog(e);
                XtraMessageBox.Show("建立数据库连接出错。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 创建命令。
        /// </summary>
        /// <param name="connection">连接。</param>
        /// <param name="commandText">命令符。</param>
        /// <param name="commandParameters">参数集。</param>
        /// <returns>命令。</returns>
        public static SQLiteCommand CreateCommand(SQLiteConnection connection, string commandText, params SQLiteParameter[] commandParameters)
        {
            SQLiteCommand command = new SQLiteCommand(commandText, connection);
            if (commandParameters.Length > 0)
            {
                foreach (SQLiteParameter parameter in commandParameters)
                {
                    command.Parameters.Add(parameter);
                }
            }
            return command;
        }

        /// <summary>
        /// 创建命令。
        /// </summary>
        /// <param name="connectionString">连接串。</param>
        /// <param name="commandText">命令符。</param>
        /// <param name="commandParameters">参数集。</param>
        /// <returns>命令。</returns>
        public static SQLiteCommand CreateCommand(string connectionString, string commandText, params SQLiteParameter[] commandParameters)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            SQLiteCommand command = new SQLiteCommand(commandText, connection);
            if (commandParameters.Length > 0)
            {
                foreach (SQLiteParameter parameter in commandParameters)
                {
                    command.Parameters.Add(parameter);
                }
            }
            return command;
        }

        /// <summary>
        /// 创建参数。
        /// </summary>
        /// <param name="parameterName">参数名称。</param>
        /// <param name="parameterType">参数类型。</param>
        /// <param name="parameterValue">参数值。</param>
        /// <returns>参数。</returns>
        public static SQLiteParameter CreateParameter(string parameterName, DbType parameterType, object parameterValue)
        {
            SQLiteParameter parameter = new SQLiteParameter();
            parameter.DbType = parameterType;
            parameter.ParameterName = parameterName;
            parameter.Value = parameterValue;
            return parameter;
        }

        /// <summary>
        /// 执行查询数据集。
        /// </summary>
        /// <param name="connectionString">连接串。</param>
        /// <param name="commandText">命令符。</param>
        /// <param name="paramList">参数列表。</param>
        /// <returns>数据集。</returns>
        public static DataSet ExecuteDataSet(string connectionString, string commandText, object[] paramList)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = commandText;
            if (paramList != null)
            {
                AttachParameters(command, commandText, paramList);
            }
            DataSet dataSet = new DataSet();
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);
            dataAdapter.Fill(dataSet);
            dataAdapter.Dispose();
            command.Dispose();
            connection.Close();
            return dataSet;
        }

        /// <summary>
        /// 执行查询数据集。
        /// </summary>
        /// <param name="connection">连接。</param>
        /// <param name="commandText">命令符。</param>
        /// <param name="paramList">参数列表。</param>
        /// <returns>数据集。</returns>
        public static DataSet ExecuteDataSet(SQLiteConnection connection, string commandText, object[] paramList)
        {
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = commandText;
            if (paramList != null)
            {
                AttachParameters(command, commandText, paramList);
            }
            DataSet dataSet = new DataSet();
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);
            dataAdapter.Fill(dataSet);
            dataAdapter.Dispose();
            command.Dispose();
            connection.Close();
            return dataSet;
        }

        /// <summary>
        /// 执行查询数据集。
        /// </summary>
        /// <param name="command">命令。</param>
        /// <returns>数据集。</returns>
        public static DataSet ExecuteDataset(SQLiteCommand command)
        {
            if (command.Connection.State == ConnectionState.Closed)
            {
                command.Connection.Open();
            }
            DataSet dataSet = new DataSet();
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);
            dataAdapter.Fill(dataSet);
            dataAdapter.Dispose();
            command.Connection.Close();
            command.Dispose();
            return dataSet;
        }

        /// <summary>
        /// 执行查询数据集。
        /// </summary>
        /// <param name="transaction">事务。</param>
        /// <param name="commandText">命令符。</param>
        /// <param name="commandParameters">参数集。</param>
        /// <returns>数据集。</returns>
        public static DataSet ExecuteDataset(SQLiteTransaction transaction, string commandText, params SQLiteParameter[] commandParameters)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException("transaction");
            }
            if (transaction != null && transaction.Connection == null)
            {
                throw new ArgumentException("事务已被回滚或提交，请提供一个打开的事务。", "transaction");
            }
            IDbCommand command = transaction.Connection.CreateCommand();
            command.CommandText = commandText;
            foreach (SQLiteParameter parameter in commandParameters)
            {
                command.Parameters.Add(parameter);
            }
            if (transaction.Connection.State == ConnectionState.Closed)
            {
                transaction.Connection.Open();
            }
            DataSet dataSet = ExecuteDataset(command as SQLiteCommand);
            return dataSet;
        }

        /// <summary>
        /// 执行查询数据集。
        /// </summary>
        /// <param name="transaction">事务。</param>
        /// <param name="commandText">命令符。</param>
        /// <param name="commandParameters">参数值集。</param>
        /// <returns>数据集。</returns>
        public static DataSet ExecuteDataset(SQLiteTransaction transaction, string commandText, object[] commandParameters)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException("transaction");
            }
            if (transaction != null && transaction.Connection == null)
            {
                throw new ArgumentException("事务已被回滚或提交，请提供一个打开的事务。", "transaction");
            }
            IDbCommand command = transaction.Connection.CreateCommand();
            command.CommandText = commandText;
            AttachParameters(command as SQLiteCommand, command.CommandText, commandParameters);
            foreach (SQLiteParameter parameter in commandParameters)
            {
                command.Parameters.Add(parameter);
            }
            if (transaction.Connection.State == ConnectionState.Closed)
            {
                transaction.Connection.Open();
            }
            DataSet dataSet = ExecuteDataset(command as SQLiteCommand);
            return dataSet;
        }

        /// <summary>
        /// 更新数据集。
        /// </summary>
        /// <param name="insertCommand">插入命令。</param>
        /// <param name="deleteCommand">删除命令。</param>
        /// <param name="updateCommand">更新命令。</param>
        /// <param name="dataSet">数据集。</param>
        /// <param name="tableName">表名。</param>
        public static void UpdateDataset(SQLiteCommand insertCommand, SQLiteCommand deleteCommand, SQLiteCommand updateCommand, DataSet dataSet, string tableName)
        {
            if (insertCommand == null)
            {
                throw new ArgumentNullException("insertCommand");
            }
            if (deleteCommand == null)
            {
                throw new ArgumentNullException("deleteCommand");
            }
            if (updateCommand == null)
            {
                throw new ArgumentNullException("updateCommand");
            }
            if (tableName == null || tableName.Length == 0)
            {
                throw new ArgumentNullException("tableName");
            }
            using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter())
            {
                dataAdapter.UpdateCommand = updateCommand;
                dataAdapter.InsertCommand = insertCommand;
                dataAdapter.DeleteCommand = deleteCommand;
                dataAdapter.Update(dataSet, tableName);
                dataSet.AcceptChanges();
            }
        }

        /// <summary>
        /// 执行获取数据阅读器。
        /// </summary>
        /// <param name="command">命令。</param>
        /// <param name="commandText">命令符。</param>
        /// <param name="paramList">参数值列表。</param>
        /// <returns>数据阅读器。</returns>
        public static IDataReader ExecuteReader(SQLiteCommand command, string commandText, object[] paramList)
        {
            if (command.Connection == null)
            {
                throw new ArgumentException("命令必须有一个活动的连接。", "command");
            }
            command.CommandText = commandText;
            AttachParameters(command, commandText, paramList);
            if (command.Connection.State == ConnectionState.Closed)
            {
                command.Connection.Open();
            }
            IDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            return dataReader;
        }

        /// <summary>
        /// 执行非查询。
        /// </summary>
        /// <param name="connectionString">连接串。</param>
        /// <param name="commandText">命令符。</param>
        /// <param name="paramList">参数值列表。</param>
        /// <returns>结果。</returns>
        public static int ExecuteNonQuery(string connectionString, string commandText, params object[] paramList)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = commandText;
            AttachParameters(command, commandText, paramList);
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            int result = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return result;
        }

        /// <summary>
        /// 执行非查询。
        /// </summary>
        /// <param name="connection">连接。</param>
        /// <param name="commandText">命令符。</param>
        /// <param name="paramList">参数值列表。</param>
        /// <returns>结果。</returns>
        public static int ExecuteNonQuery(SQLiteConnection connection, string commandText, params object[] paramList)
        {
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = commandText;
            AttachParameters(command, commandText, paramList);
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            int result = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return result;
        }

        /// <summary>
        /// 执行非查询。
        /// </summary>
        /// <param name="transaction">事务。</param>
        /// <param name="commandText">命令符。</param>
        /// <param name="paramList">参数值列表。</param>
        /// <returns>结果。</returns>
        public static int ExecuteNonQuery(SQLiteTransaction transaction, string commandText, params  object[] paramList)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException("transaction");
            }
            if (transaction != null && transaction.Connection == null)
            {
                throw new ArgumentException("事务已被回滚或提交，请提供一个打开的事务。", "transaction");
            }
            IDbCommand command = transaction.Connection.CreateCommand();
            command.CommandText = commandText;
            AttachParameters((SQLiteCommand)command, command.CommandText, paramList);
            if (transaction.Connection.State == ConnectionState.Closed)
            {
                transaction.Connection.Open();
            }
            int result = command.ExecuteNonQuery();
            command.Dispose();
            return result;
        }

        /// <summary>
        /// 执行非查询。
        /// </summary>
        /// <param name="command">命令。</param>
        /// <returns>结果。</returns>
        public static int ExecuteNonQuery(IDbCommand command)
        {
            if (command.Connection.State == ConnectionState.Closed)
            {
                command.Connection.Open();
            }
            int result = command.ExecuteNonQuery();
            command.Connection.Close();
            command.Dispose();
            return result;
        }

        /// <summary>
        /// 执行单值查询。
        /// </summary>
        /// <param name="connectionString">连接串。</param>
        /// <param name="commandText">命令符。</param>
        /// <param name="paramList">参数值列表。</param>
        /// <returns>值。</returns>
        public static object ExecuteScalar(string connectionString, string commandText, params  object[] paramList)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = commandText;
            AttachParameters(command, commandText, paramList);
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            object result = command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return result;
        }

        /// <summary>
        /// 执行获得Xml阅读器。
        /// </summary>
        /// <param name="command">命令。</param>
        /// <returns>Xml阅读器。</returns>
        public static XmlReader ExecuteXmlReader(IDbCommand command)
        {
            if (command.Connection.State != ConnectionState.Open)
            {
                command.Connection.Open();
            }
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command as SQLiteCommand);
            DataSet dataSet = new DataSet();
            dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            dataAdapter.Fill(dataSet);
            StringReader stream = new StringReader(dataSet.GetXml());
            command.Connection.Close();
            return new XmlTextReader(stream);
        }

        /// <summary>
        /// 填充参数集。
        /// </summary>
        /// <param name="command">命令。</param>
        /// <param name="commandText">命令符。</param>
        /// <param name="paramList">参数列表。</param>
        /// <returns>参数集。</returns>
        private static SQLiteParameterCollection AttachParameters(SQLiteCommand command, string commandText, params  object[] paramList)
        {
            if (paramList == null || paramList.Length == 0)
            {
                return null;
            }
            SQLiteParameterCollection parameterCollection = command.Parameters;
            string parmString = commandText.Substring(commandText.IndexOf("@"));
            parmString = parmString.Replace(",", " ,");
            string pattern = @"(@)\S*(.*?)\b";
            Regex ex = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection mc = ex.Matches(parmString);
            string[] paramNames = new string[mc.Count];
            int i = 0;
            foreach (Match m in mc)
            {
                paramNames[i] = m.Value;
                i++;
            }
            int j = 0;
            Type t = null;
            foreach (object o in paramList)
            {
                SQLiteParameter parmeter = new SQLiteParameter();
                if (o == null)
                {
                    parmeter.DbType = DbType.Object;
                    parmeter.ParameterName = paramNames[j];
                    parmeter.Value = paramList[j];
                    parameterCollection.Add(parmeter);
                    j++;
                    continue;
                }
                t = o.GetType();
                switch (t.ToString())
                {
                    case ("DBNull"):
                    case ("Char"):
                    case ("SByte"):
                    case ("UInt16"):
                    case ("UInt32"):
                    case ("UInt64"):
                        {
                            throw new SystemException("错误的数据类型。");
                        }
                    case ("System.String"):
                        {
                            parmeter.DbType = DbType.String;
                            parmeter.ParameterName = paramNames[j];
                            parmeter.Value = (string)paramList[j];
                            parameterCollection.Add(parmeter);
                            break;
                        }
                    case ("System.Byte[]"):
                        {
                            parmeter.DbType = DbType.Binary;
                            parmeter.ParameterName = paramNames[j];
                            parmeter.Value = (byte[])paramList[j];
                            parameterCollection.Add(parmeter);
                            break;
                        }
                    case ("System.Int32"):
                        {
                            parmeter.DbType = DbType.Int32;
                            parmeter.ParameterName = paramNames[j];
                            parmeter.Value = (int)paramList[j];
                            parameterCollection.Add(parmeter);
                            break;
                        }
                    case ("System.Boolean"):
                        {
                            parmeter.DbType = DbType.Boolean;
                            parmeter.ParameterName = paramNames[j];
                            parmeter.Value = (bool)paramList[j];
                            parameterCollection.Add(parmeter);
                            break;
                        }
                    case ("System.DateTime"):
                        {
                            parmeter.DbType = DbType.DateTime;
                            parmeter.ParameterName = paramNames[j];
                            parmeter.Value = Convert.ToDateTime(paramList[j]);
                            parameterCollection.Add(parmeter);
                            break;
                        }
                    case ("System.Double"):
                        {
                            parmeter.DbType = DbType.Double;
                            parmeter.ParameterName = paramNames[j];
                            parmeter.Value = Convert.ToDouble(paramList[j]);
                            parameterCollection.Add(parmeter);
                            break;
                        }
                    case ("System.Decimal"):
                        {
                            parmeter.DbType = DbType.Decimal;
                            parmeter.ParameterName = paramNames[j];
                            parmeter.Value = Convert.ToDecimal(paramList[j]);
                            break;
                        }
                    case ("System.Guid"):
                        {
                            parmeter.DbType = DbType.Guid;
                            parmeter.ParameterName = paramNames[j];
                            parmeter.Value = (System.Guid)(paramList[j]);
                            break;
                        }
                    case ("System.Object"):
                        {
                            parmeter.DbType = DbType.Object;
                            parmeter.ParameterName = paramNames[j];
                            parmeter.Value = paramList[j];
                            parameterCollection.Add(parmeter);
                            break;
                        }
                    default:
                        {
                            throw new SystemException("值是未知的数据类型。");
                        }
                }
                j++;
            }
            return parameterCollection;
        }

        /// <summary>
        /// 执行非查询（以数据行）。
        /// </summary>
        /// <param name="command">命令。</param>
        /// <param name="dataRow">数据行。</param>
        /// <returns>结果。</returns>
        public static int ExecuteNonQueryTypedParams(IDbCommand command, DataRow dataRow)
        {
            int result = 0;
            if (dataRow != null && dataRow.ItemArray.Length > 0)
            {
                AssignParameterValues(command.Parameters, dataRow);
                result = ExecuteNonQuery(command);
            }
            else
            {
                result = ExecuteNonQuery(command);
            }
            return result;
        }

        /// <summary>
        /// 填充参数值。
        /// </summary>
        /// <param name="commandParameters">命令参数集。</param>
        /// <param name="dataRow">数据行。</param>
        protected internal static void AssignParameterValues(IDataParameterCollection commandParameters, DataRow dataRow)
        {
            if (commandParameters == null || dataRow == null)
            {
                return;
            }
            DataColumnCollection columns = dataRow.Table.Columns;
            int i = 0;
            foreach (IDataParameter commandParameter in commandParameters)
            {
                if (commandParameter.ParameterName == null || commandParameter.ParameterName.Length <= 1)
                {
                    throw new InvalidOperationException(string.Format("请为第{0}位的参数提供一个有效的参数名，当前参数名为“'{1}'。", i, commandParameter.ParameterName));
                }
                if (columns.Contains(commandParameter.ParameterName))
                {
                    commandParameter.Value = dataRow[commandParameter.ParameterName];
                }
                else if (columns.Contains(commandParameter.ParameterName.Substring(1)))
                {
                    commandParameter.Value = dataRow[commandParameter.ParameterName.Substring(1)];
                }
                i++;
            }
        }

        /// <summary>
        /// 填充参数值。
        /// </summary>
        /// <param name="commandParameters">命令参数集。</param>
        /// <param name="dataRow">数据行。</param>
        protected void AssignParameterValues(IDataParameter[] commandParameters, DataRow dataRow)
        {
            if ((commandParameters == null) || (dataRow == null))
            {
                return;
            }
            DataColumnCollection columns = dataRow.Table.Columns;
            int i = 0;
            foreach (IDataParameter commandParameter in commandParameters)
            {
                if (commandParameter.ParameterName == null || commandParameter.ParameterName.Length <= 1)
                {
                    throw new InvalidOperationException(string.Format("请为第{0}位的参数提供一个有效的参数名，当前参数名为“'{1}'。", i, commandParameter.ParameterName));
                }
                if (columns.Contains(commandParameter.ParameterName))
                {
                    commandParameter.Value = dataRow[commandParameter.ParameterName];
                }
                else if (columns.Contains(commandParameter.ParameterName.Substring(1)))
                {
                    commandParameter.Value = dataRow[commandParameter.ParameterName.Substring(1)];
                }
                i++;
            }
        }

        /// <summary>
        /// 填充参数值。
        /// </summary>
        /// <param name="commandParameters">命令参数集。</param>
        /// <param name="parameterValues">参数值集。</param>
        protected void AssignParameterValues(IDataParameter[] commandParameters, params  object[] parameterValues)
        {
            if ((commandParameters == null) || (parameterValues == null))
            {
                return;
            }
            if (commandParameters.Length != parameterValues.Length)
            {
                throw new ArgumentException("参数集数量与参数值集数量不相等。");
            }
            for (int i = 0, j = commandParameters.Length, k = 0; i < j; i++)
            {
                if (commandParameters[i].Direction != ParameterDirection.ReturnValue)
                {
                    if (parameterValues[k] is IDataParameter)
                    {
                        IDataParameter paramInstance;
                        paramInstance = (IDataParameter)parameterValues[k];
                        if (paramInstance.Direction == ParameterDirection.ReturnValue)
                        {
                            paramInstance = (IDataParameter)parameterValues[++k];
                        }
                        if (paramInstance.Value == null)
                        {
                            commandParameters[i].Value = DBNull.Value;
                        }
                        else
                        {
                            commandParameters[i].Value = paramInstance.Value;
                        }
                    }
                    else if (parameterValues[k] == null)
                    {
                        commandParameters[i].Value = DBNull.Value;
                    }
                    else
                    {
                        commandParameters[i].Value = parameterValues[k];
                    }
                    k++;
                }
            }
        }

        public List<int> GetWordLengthList()
        {
            IDataReader reader = null;
            List<int> wordLengthList = null;
            try
            {
                string sql = SQL.Get_WordLength_List;
                SQLiteCommand command = new SQLiteCommand(connectionOfDataBase);
                reader = ExecuteReader(command, sql, null);
                wordLengthList = new List<int>();
                while (reader.Read())
                {
                    wordLengthList.Add(Convert.ToInt32(reader[0]));
                }
            }
            catch (Exception e)
            {
                LogManager.GlobalLogManager.CreateLog(e);
                XtraMessageBox.Show("获取单词长度列表出错。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
            return wordLengthList;
        }

        public int GetMaxWordLength()
        {
            IDataReader reader = null;
            int maxWordLength = 0;
            try
            {
                string sql = SQL.Get_Max_WordLength;
                SQLiteCommand command = new SQLiteCommand(connectionOfDataBase);
                reader = ExecuteReader(command, sql, null);
                while (reader.Read())
                {
                    maxWordLength = Convert.ToInt32(reader[0]);
                }
            }
            catch (Exception e)
            {
                LogManager.GlobalLogManager.CreateLog(e);
                XtraMessageBox.Show("获取最大单词长度出错。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
            return maxWordLength;
        }

        public Hashtable GetWordDataSets(List<int> wordLengthList)
        {
            Hashtable htWordDataSetList = new Hashtable();
            try
            {
                for (int i = 0; i < wordLengthList.Count; i++)
                {
                    string sql = string.Format(SQL.Get_DataSets_By_WordLength, wordLengthList[i]);
                    DataSet dataSet = ExecuteDataSet(connectionOfDataBase, sql, null);
                    htWordDataSetList.Add(wordLengthList[i], dataSet);
                }
            }
            catch (Exception e)
            {
                LogManager.GlobalLogManager.CreateLog(e);
                XtraMessageBox.Show("获取分组数据表出错。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            return htWordDataSetList;
        }

        public DataRow[] GetWordDataRows(string filter)
        {
            try
            {
                string sql = string.Format(SQL.Get_DataRows_By_WordLength_And_Filter, filter);
                DataSet dataSet = ExecuteDataSet(connectionOfDataBase, sql, null);
                return dataSet.Tables[0].Select();
            }
            catch (Exception e)
            {
                LogManager.GlobalLogManager.CreateLog(e);
                XtraMessageBox.Show("从数据库中获取信息出错。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}