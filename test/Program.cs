using System;
using System.Timers;
using System.Threading;
using MySql.Data.MySqlClient;

public class Test
{

   

    public static void Main()
    {
        System.Timers.Timer myTimer = new System.Timers.Timer();
        myTimer.Elapsed += new ElapsedEventHandler(OnTimer);
        myTimer.Interval = 5000;
        myTimer.Enabled = true;
        myTimer.AutoReset = false;

        System.Timers.Timer myTimer2 = new System.Timers.Timer();
        myTimer2.Elapsed += new ElapsedEventHandler(OnTimer2);
        myTimer2.Interval = 1000;
        myTimer2.Enabled = true;
        myTimer2.AutoReset = false;

        Console.WriteLine(@"Press 'q' and 'Enter' to quit...");

        while (Console.Read() != 'q')
        {
            Console.WriteLine("Do something else meanwhile!!! :)");
            Thread.Sleep(1000);
        }
    }

    public static void OnTimer(Object source, ElapsedEventArgs e)
    {


        Random one = new Random();
        Random two = new Random();

       

        float onef = (float)one.NextDouble();
        float twof = (float)two.NextDouble();

       
        Console.WriteLine(onef);
        Console.WriteLine(twof);
        
        string myConnectionString = "server=pool.roegl.eu;uid=root;pwd=Anja2017!;database=pool;";

        MySqlConnection connection = new MySqlConnection(myConnectionString);
        connection.Open();
        MySqlCommand cmd = connection.CreateCommand();

        cmd.CommandText = "INSERT INTO data(COLL_TEMP, POOL_TEMP) VALUES(?test1,?test2)";
        cmd.Parameters.AddWithValue("?test1", onef);
        cmd.Parameters.AddWithValue("?test2", twof);
        cmd.ExecuteNonQuery();
        Console.WriteLine("Success!");


        System.Timers.Timer theTimer = (System.Timers.Timer)source;
        theTimer.Interval += 0;
        theTimer.Enabled = true;
    }
    public static void OnTimer2(Object source, ElapsedEventArgs e)
    {

        Console.WriteLine("Do some stuff meanwhile!");

        System.Timers.Timer theTimer2 = (System.Timers.Timer)source;
        theTimer2.Interval += 0;
        theTimer2.Enabled = true;
    }
}