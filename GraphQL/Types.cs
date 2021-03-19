using GraphQL_API.Entities;
using GraphQL.Types;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace GraphQL_API.GraphQL
{
  public class FactInterventionsType : ObjectGraphType<FactInterventions>
  {

    ///////INTERVENTION Type//////////////
    public FactInterventionsType(RailsApp_development_dbContext db)
    {
      Name = "Interventions";

      Field(x => x.Id);
      Field(x => x.building_id, nullable: true);
      Field(x => x.start_date, nullable: true);
      Field(x => x.end_date, nullable: true);
      Field<BuildingsType>(
        "building",

        arguments: 
          new QueryArguments(
            new QueryArgument<IntGraphType> { Name = "id" }),

        resolve: context => 
        {
            var buildings = db.Building
                            .Include(_ => _.Address)
                            //.Include(_ => _.Customer)
                            .FirstOrDefault(i => i.Id == context.Source.building_id);

            return buildings;
        });


    }    
  }


    //////////////EMPLOYEE TYPE//////////////////////

  public class EmployeesType : ObjectGraphType<Employees>
  {
    public EmployeesType(  warehouse_developmentContext _db)
    {
      Name = "Employee";

      Field(x => x.Id);
      Field(x => x.first_name);
      Field(x => x.last_name);
      
    } 
  }

  ///////BUILDING TYPE///////////////////

  public class BuildingsType : ObjectGraphType<Buildings>
  {
    public BuildingsType(warehouse_developmentContext _db, RailsApp_development_dbContext db)
    {
      Name = "Building";

      Field(x => x.Id);
      Field(x => x.technical_contact_phone_for_the_building);
      Field(x => x.technical_contact_email_for_the_building);
      Field(x => x.full_name_of_the_technical_contact_for_the_building);
      Field(x => x.phone_number_of_the_building_administrator);
      Field(x => x.email_of_the_administrator_of_the_building);
      Field(x => x.full_name_of_the_building_administrator);
      Field(x => x.address_id, nullable: true);
      Field(x => x.customer_id, nullable: true);

      //Field(x => x.Address, type: typeof(AddressType));
      Field<AddressesType>(
        "address",

        arguments: 
          new QueryArguments(
            new QueryArgument<IntGraphType> { Name = "id" }),

        resolve: context => 
        {
            var address = db.Address
                            .FirstOrDefault(i => i.Id == context.Source.Address.Id);

            return address;
        });
        Field<ListGraphType<BatteriesType>>(
        "batteries",

        // arguments: 
        //   new QueryArguments(
        //     new QueryArgument<IntGraphType> { Name = "id" }),

        resolve: context => 
        {
            var batteries = db.Battery
                                .Where(ss => ss.building_id == context.Source.Id)
                                .ToListAsync();

            return batteries;
        });

      Field<ListGraphType<BuildingsDetailsType>>(
      "buildingsDetails",

      arguments: 

        new QueryArguments(
          new QueryArgument<IntGraphType> { Name = "id" }),

      resolve: context => 
      {
          var buildingDetails = db.BuildingsDetail
                              .Where(ss => ss.building_id == context.Source.Id)
                              .ToListAsync();

          return buildingDetails;
      });

    }    
  }

  /////////////////ADDRESS TYPE/////////////////////

  
  public class AddressesType : ObjectGraphType<Addresses>
  {
    public AddressesType()
    {
      Name = "Address";

      Field(x => x.Id);
      Field(x => x.Building, type: typeof(ListGraphType<BuildingsType>));
      

    } 
  }



  //////////////CUSTOMER TYPE////////////////////

   public class CustomersType : ObjectGraphType<Customers>
  {
    public CustomersType(RailsApp_development_dbContext _db)
    {
      Name = "Customer";

      Field(x => x.Id);
      Field(x => x.full_name_of_company_contact);
      Field(x => x.company_contact_phone);
      Field(x => x.email_of_company_contact);
      Field(x => x.company_description);
      Field(x => x.full_name_of_service_technical_authority);
      Field(x => x.technical_authority_phone_for_service_);
      Field(x => x.technical_manager_email_for_service);

      Field<ListGraphType<BuildingsType>>(
        "buildings",

        arguments: 
          new QueryArguments(
            new QueryArgument<IntGraphType> { Name = "id" }),

        resolve: context => 
        {
             var buildings =_db.Building
                                // .Include(_ => _.Batteries)
                                 .Where(ss => ss.customer_id == context.Source.Id)
                                 .ToListAsync();


            return buildings;
        });
        Field<ListGraphType<BatteriesType>>(
        "batteries",

        arguments: 
            new QueryArguments(
            new QueryArgument<IntGraphType> { Name = "id" }),

        resolve: context => 
        {
            
            var batteries = _db.Battery
                            .Where(_=>_.Building.customer_id == context.Source.Id)
                            .ToListAsync();

            return batteries;
      });
      Field<ListGraphType<ColumnsType>>(
        "columns",

        arguments: 
            new QueryArguments(
            new QueryArgument<IntGraphType> { Name = "id" }),

        resolve: context => 
        {
            
            var columns = _db.Column
                            .Where(_=>_.Battery.Building.customer_id == context.Source.Id)
                            .ToListAsync();

            return columns;
      });
      Field<ListGraphType<ElevatorsType>>(
        "elevators",

        arguments: 
            new QueryArguments(
            new QueryArgument<IntGraphType> { Name = "id" }),

        resolve: context => 
        {
            
            var elevators = _db.Elevator
                            .Where(_=>_.Column.Battery.Building.customer_id == context.Source.Id)
                            .ToListAsync();

            return elevators;
      });
    } 
  }


/////////////////BUILDINGS DETAIL TYPE///////////////////
  public class BuildingsDetailsType : ObjectGraphType<BuildingsDetails>
  {
    public BuildingsDetailsType()
    {
      Name = "BuildingsDetail";

      Field(x => x.Id);
      Field(x => x.information_key);
      Field(x => x.value);
      Field(x => x.building_id, nullable: true);

    } 
  }


  ///BATTERY TYPE ////////////////////

    public class BatteriesType : ObjectGraphType<Batteries>
    {
      public BatteriesType(RailsApp_development_dbContext _db)
      {
        Name = "Battery";

        Field(x => x.Id);
        Field(x => x.building_type);
        Field(x => x.status);
        Field(x => x.date_of_commissioning, nullable: true);
        Field(x => x.date_of_last_inspection, nullable: true);
        Field(x => x.certificate_of_operations);
        Field(x => x.building_id, nullable: true);
        Field<CustomersType>(
          "customer",

          arguments: 
            new QueryArguments(
              new QueryArgument<IntGraphType> { Name = "id" }),

          resolve: context => 
          {
              var buildings = _db.Building
                              .FirstOrDefault(i => i.Id == context.Source.building_id);
              var customer = _db.Customer.FirstOrDefault(i => i.Id == buildings.customer_id);

              return customer;
        });
      Field<BuildingsType>(
          "building",

          arguments: 
            new QueryArguments(
              new QueryArgument<IntGraphType> { Name = "id" }),

          resolve: context => 
          {
              var buildings = _db.Building
                              .FirstOrDefault(i => i.Id == context.Source.building_id);

              return buildings;
        });
      Field<ListGraphType<ColumnsType>>(
        "columns",

        arguments: 
            new QueryArguments(
            new QueryArgument<IntGraphType> { Name = "id" }),

        resolve: context => 
        {
            
            var columns = _db.Column
                            .Where(_=>_.battery_id == context.Source.Id)
                            .ToListAsync();

            return columns;
      });
      } 
    }



    /////COLUMN TYPE /////////////////////

    public class ColumnsType : ObjectGraphType<Columns>
    {
      public ColumnsType(RailsApp_development_dbContext _db)
      {
        Name = "Column";

        Field(x => x.Id);
        Field(x => x.building_type);
        Field(x => x.number_of_floors_served, nullable: true);
        Field(x => x.status);
        Field(x => x.information);
        Field(x => x.notes);
        Field(x => x.battery_id, nullable: true);
        Field<CustomersType>(
          "customer",

          arguments: 
            new QueryArguments(
              new QueryArgument<IntGraphType> { Name = "id" }),

          resolve: context => 
          {
              var battery = _db.Battery
                              .FirstOrDefault(i => i.Id == context.Source.battery_id);
              var customer = _db.Customer
                              .FirstOrDefault(i => i.Id == battery.Building.customer_id);

              return customer;
        });
        Field<BatteriesType>(
          "battery",

          arguments: 
            new QueryArguments(
              new QueryArgument<IntGraphType> { Name = "id" }),

          resolve: context => 
          {
              var battery = _db.Battery
                              .FirstOrDefault(i => i.Id == context.Source.battery_id);

              return battery;
        });
      Field<ListGraphType<ElevatorsType>>(
        "elevators",

        arguments: 
            new QueryArguments(
            new QueryArgument<IntGraphType> { Name = "id" }),

        resolve: context => 
        {
            
            var elevators = _db.Elevator
                            .Where(_=>_.column_id == context.Source.Id)
                            .ToListAsync();

            return elevators;
      });

      } 
    }

     ///// ELEVATOR TYPE ////////////////////



    public class ElevatorsType : ObjectGraphType<Elevators>
    {
      public ElevatorsType(RailsApp_development_dbContext _db)
      {
        Name = "Elevator";

        Field(x => x.Id);
        Field(x => x.serial_number);
        Field(x => x.model);
        Field(x => x.date_of_last_inspection, nullable: true);
        Field(x => x.date_of_commissioning, nullable: true);
        Field(x => x.building_type);
        Field(x => x.status);
        Field(x => x.certificate_of_inspection);
        Field(x => x.column_id, nullable: true);
        Field<CustomersType>(
          "customer",

          arguments: 
            new QueryArguments(
              new QueryArgument<IntGraphType> { Name = "id" }),

          resolve: context => 
          {
              var column = _db.Column
                              .FirstOrDefault(i => i.Id == context.Source.column_id);
              var customer = _db.Customer
                              .FirstOrDefault(i => i.Id == column.Battery.Building.customer_id);

              return customer;
        });
        Field<ColumnsType>(
          "column",
          arguments: 
            new QueryArguments(
              new QueryArgument<IntGraphType> { Name = "id" }),

          resolve: context => 
          {
              var column = _db.Column
                              .FirstOrDefault(i => i.Id == context.Source.column_id);

              return column;
        });

      } 
    }



}

