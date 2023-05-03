#
# Script.ps1
#

Param(
   [string] $Server = "(localdb)\MSSQLLocalDb",
   [string] $Database = "rosen"
)

# This script requires the SQL Server module for PowerShell.
# The below commands may be required.

# To check whether the module is installed.
# Get-Module -ListAvailable -Name SqlServer;

# Install the SQL Server Module
# Install-Module -Name SqlServer -Scope CurrentUser

$CurrentDrive = (Get-Location).Drive.Name + ":"

Write-Host ""
Write-Host "Rebuilding database $Database on $Server..."
Import-Module sqlserver
Write-Host "Got Here"

<#
   If on your local machine, you can drop and re-create the database.
#>
# & ".\Scripts\DropDatabase.ps1" -Database $Database
# & ".\Scripts\CreateDatabase.ps1" -Database $Database

<#
   If on the department's server, you don't have permissions to drop or create databases.
   In this case, maintain a script to drop all tables.
#>
Write-Host "Dropping tables..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "560FinalProject\Sql\Tables\DropTables.sql"

Write-Host "Creating schema..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "560FinalProject\Sql\Schemas\MovieOperations.sql"

Write-Host "Creating tables..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "560FinalProject\Sql\Tables\CreateTables.sql"

Write-Host "Stored Operations..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "560FinalProject\Sql\Procedures\MovieOperations.CreateActor.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "560FinalProject\Sql\Procedures\MovieOperations.CreateMovie.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "560FinalProject\Sql\Procedures\MovieOperations.CreateMovieCast.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "560FinalProject\Sql\Procedures\MovieOperations.CreateRoom.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "560FinalProject\Sql\Procedures\MovieOperations.CreateTheater.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "560FinalProject\Sql\Procedures\MovieOperations.RemoveActor.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "560FinalProject\Sql\Procedures\MovieOperations.RemoveFromMovieCast.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "560FinalProject\Sql\Procedures\MovieOperations.RemoveMovie.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "560FinalProject\Sql\Procedures\MovieOperations.RemoveRoom.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "560FinalProject\Sql\Procedures\MovieOperations.RemoveTheater.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "560FinalProject\Sql\Procedures\MovieOperations.UpdateMovie.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "560FinalProject\Sql\Procedures\MovieOperations.UpdateTheater.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "560FinalProject\Sql\Procedures\MovieOperations.UpdateRoom.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "560FinalProject\Sql\Procedures\MovieOperations.UpdateActor.sql"

Write-Host "Inserting data..."
#Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "560FinalProject\Sql\Data\PopulateTables.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "560FinalProject\Sql\Data\PopulateTablesRy.sql"
#Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "560FinalProject\Sql\Data\PopulateTablesSebi.sql"

Write-Host "Rebuild completed."
Write-Host ""

Set-Location $CurrentDrive
