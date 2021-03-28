# winforms_mysql_demo
Demonstration on how to use the MySQL DBMS using C# with .NET and WinForms.
1. Download the MySQL .NET Connector from MySQL's download center https://dev.mysql.com/downloads/connector/net/
2. Create a new WinForms project with C# in Visual Studio (tested on 2019 Community edition).
3. Right click on your project in the Solution Explorer and click Add > Reference which opens the Reference Manager.
4. Find the MySql.Data dependency (use the search bar in the ref mgr), check it and hit ok.
5. Connect to the MySQL DBMS using the MySqlConnection object and execute queries using MySqlCommand objects (see the DataManager.cs source code file)
6. Congratulations, you have successfully connected and started using the MySQL DBMS from C# using .NET.
