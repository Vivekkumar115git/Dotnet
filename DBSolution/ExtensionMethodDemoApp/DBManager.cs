namespace DAL;
using BOL;
using System.Data;
using MySql.Data.MySqlClient;

public static class DBManager{

    public static List<Department> GetAllDepartments(){

    List<Department> departments=new List<Department>();

    string conString = @"server=localhost;uid=root;" + "pwd=Vivek#123;database=vivek";
    MySqlConnection con=new MySqlConnection(conString);
    string query="SELECT * FROM dept";
    MySqlCommand cmd=new MySqlCommand();
    cmd.Connection=con;
    cmd.CommandText=query;
    con.Open();
    MySqlDataReader reader=cmd.ExecuteReader();
    Console.WriteLine("Records from MySQL database Transflower");
    while(reader.Read())
    {
        int deptId=int.Parse(reader["deptno"].ToString());
        string name=reader["dname"].ToString();
        string location=reader["loc"].ToString();
        Department dept=new Department{
            Id=deptId,
            Name=name,
            Location=location
        };
        departments.Add(dept);
    }
    con.Close();
    return departments;
}

 public static bool Insert(Department dept){
        bool status=false;
        string conString=@"server=localhost;uid=root;" +  "pwd=Vivek#123;database=vivek";
        MySqlConnection con=new MySqlConnection(conString);
        string query="Insert into dept (deptno,dname, loc) values("+dept.Id+",'"+dept.Name+ "','"+ dept.Location+ "')";
        MySqlCommand cmd=new MySqlCommand();
        cmd.Connection=con;
        cmd.CommandText=query;
        con.Open();
        cmd.ExecuteNonQuery();
        Console.WriteLine("Record is inserted...");
        status=true;
        con.Close();
        return status;
    }

    public static bool Delete(int Id){
        bool status=false;
        string conString=@"server=localhost;uid=root;"+"pwd=Vivek#123;database=vivek";
        MySqlConnection con=new MySqlConnection(conString);
        string query="Delete from dept where deptno="+Id;
        MySqlCommand cmd=new MySqlCommand();
        cmd.Connection=con;
        cmd.CommandText=query;
        con.Open();
        cmd.ExecuteNonQuery();
        status=true;
        return status;
        }
         
    public static bool Update(int Id,string Name,string Location){
        bool status=false;
        string conString=@"server=localhost;uid=root;"+"pwd=Vivek#123;database=vivek";
        MySqlConnection con=new MySqlConnection(conString);
        string query="Update dept set dname='"+Name+"',loc='"+Location+"' where deptno="+Id;
        MySqlCommand cmd=new MySqlCommand();
        cmd.Connection=con;
        cmd.CommandText=query;
        con.Open();
       int c= cmd.ExecuteNonQuery();
       System.Console.WriteLine( c);
        status=true;
        return status;

    } 


}



