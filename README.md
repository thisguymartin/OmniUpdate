## OmniUpdate

## Starting SQL Server
```powershell
$sa_password = "[SA PASSWORD HERE]"
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=12345" -p 1433:1433 -v sqlvolume:/var/opt/mssql -d --rm --name mssql mcr.microsoft.com/azure-sql-edge
```

## Connecting to SQL Server
```powershell
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost; Database=OmniUpdate; Username=OmniUpdate; Password=OmniUpdate;"
```
