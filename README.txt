----- HOW THE PROJECT IS LAID OUT -----

Our project is organized into folders, what is contained in those folders is as follows:

Forms:
Forms includes our 9 Forms we used in our project, this folder has two subfolders called Input Forms and Other Forms.

Models: 
Models includes all objects used in our project. These include Actor, Genre, Movie, MovieCast, MovieGenre, MovieShowtime, Room, and Theater. 

SQL: 
SQL includes four sub-folders: Data, Operations, Schemeas, Tables These sub folders contain the SQL files we used in our project.
	Data:
	Data includes 4 files that our group used to popuate tables with our own local file path.

	Operations:
	Operations has SQL queries that we used in our project such as CreateActor and UpdateMovie

	Schemas: 
	This folder has one thing it it, and it is our SQL statment to create our Schema

	Tables: 
	This folder contains two SQL commands, CreateTables and DropTables.

The last files in our project is the Operations.cs, Program.cs, and SortByEnum. Operations acts like a controler of sorts, managing the creation and updating/deltion of 
Objects. Program just runs the application and esablishes connection with the databases. SortByEnum is used to set which kind of sort that we are sorting the output by.

----- STEPS TO START THE PROJECT ON YOUR DEVICE -----

To start the project you need to go into the RebuildDatabase.ps1 file. In this file you need to change the database name to the name of your local database, so that this
program can connect to your computer. Next you need to scroll down to the "Inserting data..." section and comment out every line except,

	Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "560FinalProject\Sql\Data\PopulateTables.sql"

From here, you need to go to the PopulateTables.sql file and change all of the file paths to the one on your local device. Example:

	'E:\CIS 560\560FinalProject\Excel Files\movies.csv'  ===>  'C:\Users\[YOUR FILE]\source\repos\560FinalProject\Excel Files\movies.csv'

Next you go to program and find the comment, "MAKE SURE THIS STRING IS SET TO YOUR LOCAL DATABASE!". Under this line you will find a string. where the string says
"Database=..." insert the name of your local database. Example:

	string connectionString = @"Server=(localdb)\MSSQLLocalDb;Database=[YOUR DATABASE];Integrated Security=SSPI;";

Finally, left click on the RebuildDatabase.ps1 and click the "Execute Script" option. This will set up the database on your device for you to use on the project.

Now you are ready to run the program and use the database!