using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Diagnostics;
using System.Reflection;

namespace SqlBulkCopyTest
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using var db = new MyDbContext();
            Console.WriteLine($"先预热一下ef连接");
            await db.TestTableEfs.FirstOrDefaultAsync();

            await db.Database.ExecuteSqlRawAsync("delete from TestTableEfs");
            Console.WriteLine($"再清空表");

            using var transaction = db.Database.BeginTransaction();
            try
            {

                //await EfSingleTest(db);
                //await EfMultipleTest(db);
                await SqlBulkCopyTest(db, transaction);
                //throw new Exception("这是测试的异常");
                await transaction.CommitAsync();
                Console.ReadKey();
            }
            catch (Exception)
            {

            }
        }

        static async Task EfSingleTest(MyDbContext db)
        {
            Console.WriteLine($"单条sql执行巨慢可以放弃执行了。。。。。");
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < 30000; i++)
            {
                var t = new TestTableEf
                {
                    Id = Guid.NewGuid(),
                    Field1 = $"这是第{i + 1}张表的数据",
                    Field2 = $"这是第{i + 1}张表的数据",
                    Field3 = $"这是第{i + 1}张表的数据",
                    Field4 = $"这是第{i + 1}张表的数据",
                    Field5 = $"这是第{i + 1}张表的数据",
                    Field6 = $"这是第{i + 1}张表的数据",
                    Field7 = $"这是第{i + 1}张表的数据",
                    Field8 = $"这是第{i + 1}张表的数据",
                    Field9 = $"这是第{i + 1}张表的数据",
                    Field10 = $"这是第{i + 1}张表的数据",
                };

                await db.TestTableEfs.AddAsync(t);
                await db.SaveChangesAsync();
            }
            stopwatch.Stop();

            Console.WriteLine($"这是ef逐条插入的耗时时间：{stopwatch.ElapsedMilliseconds} ms");
        }

        static async Task EfMultipleTest(MyDbContext db)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var list = new List<TestTableEf>();
            for (int i = 0; i < 30000; i++)
            {
                var t = new TestTableEf
                {
                    Id = Guid.NewGuid(),
                    Field1 = $"这是第{i + 1}张表的数据",
                    Field2 = $"这是第{i + 1}张表的数据",
                    Field3 = $"这是第{i + 1}张表的数据",
                    Field4 = $"这是第{i + 1}张表的数据",
                    Field5 = $"这是第{i + 1}张表的数据",
                    Field6 = $"这是第{i + 1}张表的数据",
                    Field7 = $"这是第{i + 1}张表的数据",
                    Field8 = $"这是第{i + 1}张表的数据",
                    Field9 = $"这是第{i + 1}张表的数据",
                    Field10 = $"这是第{i + 1}张表的数据",
                };
                list.Add(t);
            }
            await db.TestTableEfs.AddRangeAsync(list);
            await db.SaveChangesAsync();
            stopwatch.Stop();
            Console.WriteLine($"这是ef批量插入的耗时时间：{stopwatch.ElapsedMilliseconds} ms");
        }

        static async Task SqlBulkCopyTest(MyDbContext db, IDbContextTransaction transaction)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var list = new List<TestTableEf>();
            for (int i = 0; i < 30000; i++)
            {
                var t = new TestTableEf
                {
                    Id = Guid.NewGuid(),
                    Field1 = $"这是第{i + 1}张表的数据的Field1",
                    Field2 = $"这是第{i + 1}张表的数据的Field2",
                    Field3 = $"这是第{i + 1}张表的数据的Field3",
                    Field4 = $"这是第{i + 1}张表的数据的Field4",
                    Field5 = $"这是第{i + 1}张表的数据的Field5",
                    Field6 = $"这是第{i + 1}张表的数据的Field6",
                    Field7 = $"这是第{i + 1}张表的数据的Field7",
                    Field8 = $"这是第{i + 1}张表的数据的Field8",
                    Field9 = $"这是第{i + 1}张表的数据的Field9",
                    Field10 = $"这是第{i + 1}张表的数据的Field10",
                };
                list.Add(t);
            }
            var tableName = db.TestTableEfs.EntityType.GetSchemaQualifiedTableName();
            await BulkInsert((SqlConnection)db.Database.GetDbConnection(), (SqlTransaction)transaction.GetDbTransaction(), tableName, list);
            stopwatch.Stop();
            Console.WriteLine($"这是bulk copy批量插入的耗时时间：{stopwatch.ElapsedMilliseconds} ms");
        }

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <typeparam name="T">泛型集合的类型</typeparam>
        /// <param name="conn">连接对象</param>
        /// <param name="tableName">将泛型集合插入到本地数据库表的表名</param>
        /// <param name="list">要插入大泛型集合</param>
        static async Task BulkInsert<T>(SqlConnection conn, SqlTransaction transaction, string tableName, IList<T> list)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                using var bulkCopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.Default, transaction);
                bulkCopy.BatchSize = list.Count;
                bulkCopy.DestinationTableName = tableName;

                var table = ListToDatable(list);
                foreach (DataColumn col in table.Columns)
                {
                    //设置列的映射，如果不设置，导入到数据库中的数据会按照索引来匹配
                    //数据库A1,A2,A3，DataTable是 A1 A3 A2,那么导入到数据库中的A2 A3就被调换了
                    bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
                }

                await bulkCopy.WriteToServerAsync(table);
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// list to datatable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        static DataTable ListToDatable<T>(IList<T> list)
        {
            var table = new DataTable();

            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(propertyInfo => propertyInfo.PropertyType.Namespace.Equals("System") && !propertyInfo.IsDefined(typeof(NotMappedAttribute), true)).ToArray();

            foreach (var propertyInfo in props)
            {
                table.Columns.Add(propertyInfo.Name, Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType);
            }

            var values = new object[props.Length];
            foreach (var item in list)
            {
                for (var i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }

                table.Rows.Add(values);
            }
            return table;
        }
    }
}