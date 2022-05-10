# Ecomerce-site


Get@Gate



This is an Ecom site similar to flipkart,amazon where people used to buy items.



frameworks and languages used:



IDE used:

1. Visual studio 2017

2. SQL server 2019

3. SSMS ( sql server management studio)



Requirement:

* Sql Server and SSMS is set properly.



BackEnd:

1. Asp.net (standard)

2. C# coding language.

3. Database - MSSQL



FrontEnt:

1.Html

2.CSS

3.JS

4.Bootstrap



VersionControl:

Git



follow these below instuctions to run the project without any problem.

* Create new database in SSMS Exa- Ecom

* now execute the sql script in this database. It will create tables.

* Remove Dbconnect from project.

* Re-add Dbconnect project. Steps to do that in solution explorer

* right click on Solution explorer

       

       Add new project -> Select class library(.net standard) -> give name as DbConnect ->Add.

  

  Now u can see Dbconnect project along side of OnlineModelsite project.Than We add Entity Framework to DbConnect.

   

   Steps to Add EF to DbConnect:

   

       right click on DbConnect -> Add new item -> select Data -> ADO.NET Entity Data Model -> Give name as "EcomDb" (important).

       Designer tool will open now . Select "Ecom" database. Then Select all the tables inside the Ecom db.

* Add a class to DbConnect -> name it Repository.cs Copy paste the given Repositry code into it.

Now the project is setup. you need to do small two changes now.



1. Add reference. reference of DbConnect to OnlineModelSite project.

2. Copy connection string in App.config of DbConnect then replce the connection string in Web.config file of OnlineModelSite (important)



Build project and Run



If facing any problem pls approach me.
Shashikumar
(shashikumarratagall301@gmail.com)


