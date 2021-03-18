using GraphQL_API.Entities;
using GraphQL.Types;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace GraphQL_API.GraphQL
{
  public class FactInterventionType : ObjectGraphType<FactIntervention>
  {

    ///////INTERVENTION Type//////////////
    public FactInterventionType(RailContext db)
    {
      Name = "Intervention";

      Field(x => x.Id);
      Field(x => x.building_id, nullable: true);
      Field(x => x.start_date, nullable: true);
      Field(x => x.end_date, nullable: true);
      Field<BuildingType>(
        "building",

        arguments: 
          new QueryArguments(
            new QueryArgument<IntGraphType> { Name = "id" }),

        resolve: context => 
        {
            var building = db.Buildings
                            .Include(_ => _.Address)
                            //.Include(_ => _.Customer)
                            .FirstOrDefault(i => i.Id == context.Source.building_id);

            return building;
        });


    }    
  }


    //////////////EMPLOYEE TYPE//////////////////////

  public class EmployeeType : ObjectGraphType<Employee>
  {
    public EmployeeType(  warehouseContext _db)
    {
      Name = "Employee";

      Field(x => x.Id);
      Field(x => x.first_name);
      Field(x => x.last_name);
      
    } 
  }

  ///////BUILDING TYPE///////////////////

  public class BuildingType : ObjectGraphType<Building>
  {
    public BuildingType(  warehouseContext _db,   dbContext db)
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
      Field<AddressType>(
        "address",

        arguments: 
          new QueryArguments(
            new QueryArgument<IntGraphType> { Name = "id" }),

        resolve: context => 
        {
            var address = db.Addresses
                            .FirstOrDefault(i => i.Id == context.Source.address_id);

            return address;
        });
        Field<ListGraphType<BatteryType>>(
        "batteries",

        // arguments: 
        //   new QueryArguments(
        //     new QueryArgument<IntGraphType> { Name = "id" }),

        resolve: context => 
        {
            var batteries = db.Batteries
                                .Where(ss => ss.building_id == context.Source.Id)
                                .ToListAsync();

            return batteries;
        });

      Field<ListGraphType<BuildingsDetailType>>(
      "buildingsDetails",

      arguments: 

        new QueryArguments(
          new QueryArgument<IntGraphType> { Name = "id" }),

      resolve: context => 
      {
          var buildingDetails = db.BuildingsDetails
                              .Where(ss => ss.building_id == context.Source.Id)
                              .ToListAsync();

          return buildingDetails;
      });

    }    
  }

  /////////////////ADDRESS TYPE/////////////////////

  
  public class AddressType : ObjectGraphType<Address>
  {
    public AddressType()
    {
      Name = "Address";

      Field(x => x.Id);
      Field(x => x.Address1);
      Field(x => x.Buildings, type: typeof(ListGraphType<BuildingType>));
      

    } 
  }



  //////////////CUSTOMER TYPE////////////////////

   public class CustomerType : ObjectGraphType<Customer>
  {
    public CustomerType(  dbContext _db)
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

      Field<ListGraphType<BuildingType>>(
        "buildings",

        arguments: 
          new QueryArguments(
            new QueryArgument<IntGraphType> { Name = "id" }),

        resolve: context => 
        {
             var buildings =_db.Buildings
                                // .Include(_ => _.Batteries)
                                 .Where(ss => ss.customer_id == context.Source.Id)
                                 .ToListAsync();


            return buildings;
        });
        Field<ListGraphType<BatteryType>>(
        "batteries",

        arguments: 
            new QueryArguments(
            new QueryArgument<IntGraphType> { Name = "id" }),

        resolve: context => 
        {
            
            var batteries = _db.Batteries
                            .Where(_=>_.Building.customer_id == context.Source.Id)
                            .ToListAsync();

            return batteries;
      });
      Field<ListGraphType<ColumnType>>(
        "columns",

        arguments: 
            new QueryArguments(
            new QueryArgument<IntGraphType> { Name = "id" }),

        resolve: context => 
        {
            
            var columns = _db.Columns
                            .Where(_=>_.Battery.Building.customer_id == context.Source.Id)
                            .ToListAsync();

            return columns;
      });
      Field<ListGraphType<ElevatorType>>(
        "elevators",

        arguments: 
            new QueryArguments(
            new QueryArgument<IntGraphType> { Name = "id" }),

        resolve: context => 
        {
            
            var elevators = _db.Elevators
                            .Where(_=>_.Column.Battery.Building.customer_id == context.Source.Id)
                            .ToListAsync();

            return elevators;
      });
    } 
  }


/////////////////BUILDINGS DETAIL TYPE///////////////////
  public class BuildingsDetailType : ObjectGraphType<BuildingsDetail>
  {
    public BuildingsDetailType()
    {
      Name = "BuildingsDetail";

      Field(x => x.Id);
      Field(x => x.information_key);
      Field(x => x.value);
      Field(x => x.building_id, nullable: true);

    } 
  }


  ///BATTERY TYPE ////////////////////

    public class BatteryType : ObjectGraphType<Battery>
    {
      public BatteryType(  dbContext _db)
      {
        Name = "Battery";

        Field(x => x.Id);
        Field(x => x.building_type);
        Field(x => x.status);
        Field(x => x.date_of_commissioning, nullable: true);
        Field(x => x.date_of_last_inspection, nullable: true);
        Field(x => x.certificate_of_operations);
        Field(x => x.building_id, nullable: true);
        Field<CustomerType>(
          "customer",

          arguments: 
            new QueryArguments(
              new QueryArgument<IntGraphType> { Name = "id" }),

          resolve: context => 
          {
              var building = _db.Buildings
                              .FirstOrDefault(i => i.Id == context.Source.building_id);
              var customer = _db.Customers.FirstOrDefault(i => i.Id == building.customer_id);

              return customer;
        });
      Field<BuildingType>(
          "building",

          arguments: 
            new QueryArguments(
              new QueryArgument<IntGraphType> { Name = "id" }),

          resolve: context => 
          {
              var building = _db.Buildings
                              .FirstOrDefault(i => i.Id == context.Source.building_id);

              return building;
        });
      Field<ListGraphType<ColumnType>>(
        "columns",

        arguments: 
            new QueryArguments(
            new QueryArgument<IntGraphType> { Name = "id" }),

        resolve: context => 
        {
            
            var columns = _db.Columns
                            .Where(_=>_.battery_id == context.Source.Id)
                            .ToListAsync();

            return columns;
      });
      } 
    }



    /////COLUMN TYPE /////////////////////

    public class ColumnType : ObjectGraphType<Column>
    {
      public ColumnType(  dbContext _db)
      {
        Name = "Column";

        Field(x => x.Id);
        Field(x => x.building_type);
        Field(x => x.number_of_floors_served, nullable: true);
        Field(x => x.status);
        Field(x => x.information);
        Field(x => x.notes);
        Field(x => x.battery_id, nullable: true);
        Field<CustomerType>(
          "customer",

          arguments: 
            new QueryArguments(
              new QueryArgument<IntGraphType> { Name = "id" }),

          resolve: context => 
          {
              var battery = _db.Batteries
                              .FirstOrDefault(i => i.Id == context.Source.battery_id);
              var customer = _db.Customers
                              .FirstOrDefault(i => i.Id == battery.Building.customer_id);

              return customer;
        });
        Field<BatteryType>(
          "battery",

          arguments: 
            new QueryArguments(
              new QueryArgument<IntGraphType> { Name = "id" }),

          resolve: context => 
          {
              var battery = _db.Batteries
                              .FirstOrDefault(i => i.Id == context.Source.battery_id);

              return battery;
        });
      Field<ListGraphType<ElevatorType>>(
        "elevators",

        arguments: 
            new QueryArguments(
            new QueryArgument<IntGraphType> { Name = "id" }),

        resolve: context => 
        {
            
            var elevators = _db.Elevators
                            .Where(_=>_.column_id == context.Source.Id)
                            .ToListAsync();

            return elevators;
      });

      } 
    }

     ///// ELEVATOR TYPE ////////////////////



    public class ElevatorType : ObjectGraphType<Elevator>
    {
      public ElevatorType(  dbContext _db)
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
        Field<CustomerType>(
          "customer",

          arguments: 
            new QueryArguments(
              new QueryArgument<IntGraphType> { Name = "id" }),

          resolve: context => 
          {
              var column = _db.Columns
                              .FirstOrDefault(i => i.Id == context.Source.column_id);
              var customer = _db.Customers
                              .FirstOrDefault(i => i.Id == column.Battery.Building.customer_id);

              return customer;
        });
        Field<ColumnType>(
          "column",
          arguments: 
            new QueryArguments(
              new QueryArgument<IntGraphType> { Name = "id" }),

          resolve: context => 
          {
              var column = _db.Columns
                              .FirstOrDefault(i => i.Id == context.Source.column_id);

              return column;
        });

      } 
    }



}

