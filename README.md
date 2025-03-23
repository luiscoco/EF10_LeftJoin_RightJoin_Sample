# EF10_LeftJoin_RightJoin_Sample

## 1. Donwload and run SQL Server docker image

First of all we have to run **Docker Desktop**

![image](https://github.com/user-attachments/assets/716d31d4-88d4-417c-a38f-80db93a74f05)

For a detail explanation visit the github repo:

https://github.com/luiscoco/SQL-Server-Docker-container/blob/main/README.md

We run this command to download **SQL Server** docker image and run it with docker:

```
docker run ^
  -e "ACCEPT_EULA=Y" ^
  -e "MSSQL_SA_PASSWORD=Luiscoco123456" ^
  -p 1433:1433 ^
  -d mcr.microsoft.com/mssql/server:2022-latest
```

## 2. Connect to SQL Server with SSMS 

Download **SSMS (SQL Server Management Studio)** and install it:

https://learn.microsoft.com/en-us/ssms/download-sql-server-management-studio-ssms

We connect to the SSMS with the password: Luiscoco123456

![image](https://github.com/user-attachments/assets/2a30aedc-54b4-42f4-bac5-29a44bc70dfe)

![image](https://github.com/user-attachments/assets/2ddf95dc-aac1-4e0b-8e09-0375deb53a3b)

## 3. Download and Install Visual Studio 2022 v17.4 (Preview version)

Download and Install Visual Studio 2022 Preview version from this site: 

https://visualstudio.microsoft.com/vs/preview/

![image](https://github.com/user-attachments/assets/be8914ff-f78d-4325-9b5b-bf85f0f585d0)

When running the Visual Strudio installer please select and install ASP.NET Core, Azure and Desktop 

![image](https://github.com/user-attachments/assets/a40c34a7-2a1e-49bc-9e84-511da29d1e5a)

## 4. Download and Install .NET 10 

![image](https://github.com/user-attachments/assets/3e1eed60-2476-4c79-a545-57c472491fd9)

Check the installation running this command

```
dotnet --version
```

![image](https://github.com/user-attachments/assets/274068f4-8135-42cf-b0da-76e8fc244643)

## 5. 
