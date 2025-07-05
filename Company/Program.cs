namespace Company;

class Program
{
    public static DbActions dbActions = new DbActions();
    public static string fileDB = "userdata.db";

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        dbActions.CreateDatabase(fileDB);
        addUserToDb();
        LoadUsers();
        Console.Write("Press number of user to update: ");
        UpdateUser(Console.ReadLine());
        LoadUsers();
        Console.Write("Press number of user to delete: ");
        DeleteUser(Console.ReadLine());
        Console.WriteLine("******");
    }

    public static void LoadUsers()
    {
        foreach (User user in dbActions.GetUsers(fileDB))
        {
            Console.WriteLine($"{user.Id} {user.Name} {user.Hours} {user.Salary}");
        }
    }

    public static void addUserToDb()
    {
        try
        {
            User user = new User();
            Console.WriteLine("Adding new user");
            Console.Write("Name: ");
            user.Name = Console.ReadLine();
            Console.Write("Rate: ");
            user.Rate = int.Parse(Console.ReadLine());
            Console.Write("Hours: ");
            user.Hours = int.Parse(Console.ReadLine());
            user.Salary = user.Hours * user.Rate;
            dbActions.AddUserToFile(fileDB, user);
            Console.WriteLine("User added");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error. User was not added");
        }
    }

    public static void FindUser(string id)
    {
        try
        {
            int userId = int.Parse(id);
            var a = dbActions.SearchUser(fileDB, userId);
            if (a != null)
            {
                Console.WriteLine(a.Name + a.Hours.ToString() + a.Salary.ToString());
            }
            else
            {
                Console.WriteLine("No user found");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error. Uncorrect UserId");
        }
    }

    public static void UpdateUser(string id)
    {
        try
        {
            int userId = int.Parse(id);
            User user = dbActions.SearchUser(fileDB, userId);
            if (user != null)
            {
                Console.Write("Updating user name:");
                user.Name = Console.ReadLine();
                Console.Write("Updating rate value:");
                user.Rate = int.Parse(Console.ReadLine());
                Console.Write("Updating hours:");
                user.Hours = int.Parse(Console.ReadLine());
                user.Salary = user.Hours * user.Rate;
                dbActions.UpdateStatus(fileDB, userId, user.Name, user.Rate, user.Hours);
            }
            else
            {
                Console.WriteLine("No user found");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        {
        }
    }

    public static void DeleteUser(string id)
    {
        try
        {
            int userId = int.Parse(id);
            User user = dbActions.SearchUser(fileDB, userId);
            if (user != null)
            {
                dbActions.DeleteUserFromDB(fileDB, userId);
                Console.WriteLine("User deleted");
            }
            else
            {
                Console.WriteLine("No user found");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error. Something went wrong");
            //throw;
        }
    }
}