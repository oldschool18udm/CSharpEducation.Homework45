using Microsoft.Data.Sqlite;
namespace Company;

public class DbActions
{
    public void CreateDatabase(string fileDB)
    {
        if (!File.Exists(fileDB))
        {
            using (var connection = new SqliteConnection($"Data Source={fileDB}"))
            {
                connection.Open();
                SqliteCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = @"CREATE TABLE IF NOT EXISTS Users(
                                            _id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, 
                                            Name TEXT NOT NULL, 
                                            Rate INTEGER NOT NULL, 
                                            Hours INTEGER NOT NULL, 
                                            Salary INTEGER NOT NULL)";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO Users (Name, Rate, Hours, Salary) VALUES ('Nastya', 50, 10, 500)";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO Users (Name, Rate, Hours, Salary) VALUES ('Olya', 60, 5, 300)";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO Users (Name, Rate, Hours, Salary) VALUES ('Sveta', 45, 20, 900)";
                command.ExecuteNonQuery();
                connection.Close();
                Console.WriteLine($"All users have been created.");
            }
        }
        else
        {
            Console.WriteLine($"File {fileDB} already exists.");
        }
    }

    public List<User> GetUsers(string fileDB)
    {
        string sqlExpression = "SELECT * FROM Users";
        List<User> users = new List<User>();
        using (var connection = new SqliteConnection($"Data Source={fileDB}"))
        {
            connection.Open();
            SqliteCommand command = new SqliteCommand(sqlExpression, connection);
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        User user = new User();
                        user.Id = int.Parse(reader.GetValue(0).ToString());
                        user.Name = reader.GetValue(1).ToString();
                        user.Rate = int.Parse(reader.GetValue(2).ToString());
                        user.Hours = int.Parse(reader.GetValue(3).ToString());
                        user.Salary = int.Parse(reader.GetValue(4).ToString());
                        users.Add(user);
                    }
                }
            }

            connection.Close();
        }

        return users;
    }

    public void AddUserToFile(string fileDB, User user)
    {
        using (var connection = new SqliteConnection($"Data Source={fileDB}"))
        {
            string sqlExpression =
                $"INSERT INTO Users (Name, Rate, Hours, Salary) VALUES ('{user.Name}', {user.Rate}, '{user.Hours}', '{user.Salary}')";
            connection.Open();
            SqliteCommand command = new SqliteCommand(sqlExpression, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }

    public void UpdateStatus(string fileDB, int id, string name, int rate, int hours)
    {
        User user = SearchUser(fileDB, id);
        if (user != null)
        {
            try
            {
                string sqlExpression =
                    $"UPDATE Users SET Name='{name}', rate={rate}, hours={hours}, salary={rate * hours}  WHERE _id={id}";

                using (var connection = new SqliteConnection($"Data Source={fileDB}"))
                {
                    connection.Open();
                    SqliteCommand command = new SqliteCommand(sqlExpression, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops! Something went wrong!");
                Console.WriteLine(e.Message);
                throw;
            }
        }
        else
        {
            Console.WriteLine("User not found!");
        }
    }

    public void DeleteUserFromDB(string fileDB, int id)
    {
        User user = SearchUser(fileDB, id);
        if (user != null)
        {
            try
            {
                string sqlExpression =
                    $"DELETE  FROM Users WHERE _id={id}";

                using (var connection = new SqliteConnection($"Data Source={fileDB}"))
                {
                    connection.Open();
                    SqliteCommand command = new SqliteCommand(sqlExpression, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops! Something went wrong!");
                Console.WriteLine(e.Message);
                throw;
            }
        }
        else
        {
            Console.WriteLine("User not found!");
        }
    }

    public User SearchUser(string fileDB, int id)
    {
        string sqlExpression = $"SELECT * FROM Users WHERE _Id={id}";
        User user = new User();
        using (var connection = new SqliteConnection($"Data Source={fileDB}"))
        {
            connection.Open();
            SqliteCommand command = new SqliteCommand(sqlExpression, connection);
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    user.Id = int.Parse(reader.GetValue(0).ToString());
                    user.Name = reader.GetValue(1).ToString();
                    user.Rate = int.Parse(reader.GetValue(2).ToString());
                    user.Hours = int.Parse(reader.GetValue(3).ToString());
                    user.Salary = int.Parse(reader.GetValue(4).ToString());
                }
                else
                {
                    connection.Close();
                    return null;
                }
            }

            connection.Close();
        }

        return user;
    }
}