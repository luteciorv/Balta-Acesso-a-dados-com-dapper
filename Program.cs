// See https://aka.ms/new-console-template for more information
using Blog.Database;
using Blog.Screens;
using Microsoft.Data.SqlClient;

const string CONNECTION_STRING = "Server=localhost,1433;Database=Blog;User ID=sa;Password=Teste@123;Trusted_Connection=False;TrustServerCertificate=True;";

DataContext.Connection = new SqlConnection(CONNECTION_STRING);
DataContext.Connection.Open();

MenuScreen.Load();

DataContext.Connection.Close();
DataContext.Connection.Dispose();